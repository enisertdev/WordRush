using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using WebGame.Application.Hubs;
using WebGame.Application.Interfaces.LobbyInterface;
using WebGame.Application.Interfaces.UserRepository;
using WebGame.Domain.Entities;

namespace WebGame.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LobbiesController : ControllerBase
    {
        private readonly ILobbyReadRepository _lobbyReadRepository;
        private readonly ILobbyWriteRepository _lobbyWriteRepository;
        private readonly IUserReadRepository _userReadRepository;
        private readonly IUserWriteRepository _userWriteRepository;
        private readonly IHubContext<GameHub> _hubContext;

        public LobbiesController(ILobbyReadRepository lobbyReadRepository, IUserReadRepository userReadRepository, ILobbyWriteRepository lobbyWriteRepository, IUserWriteRepository userWriteRepository, IHubContext<GameHub> hubContext)
        {
            _lobbyReadRepository = lobbyReadRepository;
            _userReadRepository = userReadRepository;
            _lobbyWriteRepository = lobbyWriteRepository;
            _userWriteRepository = userWriteRepository;
            _hubContext = hubContext;
        }

        public class LobbyCreateRequest
        {
            public Guid LeaderId { get; set; }
            public bool? IsPrivate { get; set; }
            public short? MaxPlayers { get; set; }
            public string? LobbyName { get; set; }
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateLobby([FromBody] LobbyCreateRequest lobbyCreateRequest)
        {
            var exists = _lobbyReadRepository.Table.Any(l => l.LeaderUserId == lobbyCreateRequest.LeaderId);
            if (exists)
                return BadRequest(new { message = "You already created a lobby." });
            try
            {
                Lobby lobby = new()
                {
                    IsPrivate = lobbyCreateRequest.IsPrivate ?? false,
                    MaxPlayers = lobbyCreateRequest.MaxPlayers ?? 5,
                    LeaderUserId = lobbyCreateRequest.LeaderId,
                    Name = lobbyCreateRequest.LobbyName ?? "NewLobby",
                    PlayerCount = 0
                };
                var leader = await _userReadRepository.GetOneByIdAsync(lobbyCreateRequest.LeaderId);
                leader.IsLeader = true;
                _userWriteRepository.Update(leader);
                await _lobbyWriteRepository.AddAsync(lobby);
                await _lobbyWriteRepository.SaveChangesAsync();
                await _hubContext.Clients.All.SendAsync("ReceiveLobby");
                await _userWriteRepository.SaveChangesAsync();
                return Ok(new
                {
                    message = "Lobby Created",
                    lobbyId = lobby.Id
                });
            }
            catch (Exception exception)
            {
                return BadRequest(new {message = exception.Message });
            }
      
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLobbies()
        {
            var lobbies = await _lobbyReadRepository.GetAllLobiesWithPlayers();
            if (lobbies != null)
                return Ok(lobbies);
            return BadRequest("something went wrong");
        }

        [HttpPost("{lobbyId}/join")]
        public async Task<IActionResult> JoinLobby([FromBody] string id, [FromRoute] Guid lobbyId)
        {
            var user = await _userReadRepository.GetOneByIdAsync(Guid.Parse(id));
            if (user == null)
                return BadRequest(new { message = "User is not found with given Id" });
            if (user.LobbyId != null)
                return BadRequest(new { message = "You are already in a lobby, leave it before joining another one." });
            var lobby = await _lobbyReadRepository.GetLobbyWithPlayersById(lobbyId);
            if (lobby.Players.FirstOrDefault(u => u.Id == Guid.Parse(id)) != null)
                return BadRequest(new { message = "You already joined to the lobby" });
            
            lobby.PlayerCount += 1;
            lobby.Players.Add(user);
            _lobbyWriteRepository.Update(lobby);
            await _lobbyWriteRepository.SaveChangesAsync();
            return Ok(new { message = "user joined lobby" });
        }

    }
}
