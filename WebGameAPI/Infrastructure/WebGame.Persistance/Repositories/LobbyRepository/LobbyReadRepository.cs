using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebGame.Application.Interfaces.LobbyInterface;
using WebGame.Domain.Entities;
using WebGame.Persistance.Context;

namespace WebGame.Persistance.Repositories.LobbyRepository
{
    public class LobbyReadRepository : ReadRepository<Lobby>, ILobbyReadRepository
    {
        public LobbyReadRepository(WebGameDbContext context) : base(context)
        {
        }

        public async Task<Lobby> GetLobbyWithPlayersById(Guid lobbyId)
        {
            return await Table.Include(u => u.Players).FirstOrDefaultAsync(id => id.Id == lobbyId);
        }

        public async Task<List<Lobby>> GetAllLobiesWithPlayers()
        {
            return await Table.Include(p => p.Players).ToListAsync();
        }
    }
}
