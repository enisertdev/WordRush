using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Domain.Entities;

namespace WebGame.Application.Interfaces.LobbyInterface
{
    public interface ILobbyReadRepository : IReadRepository<Lobby>
    {
        Task<Lobby> GetLobbyWithPlayersById(Guid lobbyId);
        Task<List<Lobby>> GetAllLobiesWithPlayers();
    }
}
