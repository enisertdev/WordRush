using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebGame.Application.Interfaces.UserRepository;
using WebGame.Domain.Entities;

namespace WebGame.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserReadRepository _userReadRepository;
        private readonly IUserWriteRepository _userWriteRepository;

        public UsersController(IUserReadRepository userReadRepository, IUserWriteRepository userWriteRepository)
        {
            _userReadRepository = userReadRepository;
            _userWriteRepository = userWriteRepository;
        }

        public class CreateUserRequest
        {
            public string ConnectionId { get; set; }
            public string? Name { get; set; }
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest userRequest)
        {
            try
            {
                User user = new()
                {
                    ConnectionId = userRequest.ConnectionId,
                    Name = userRequest.Name ?? "Player"
                };
                await _userWriteRepository.AddAsync(user);
                await _userWriteRepository.SaveChangesAsync();
                return Ok(new{userId = user.Id});
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
