using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Application.Interfaces.LobbyInterface;
using WebGame.Domain.Entities;
using WebGame.Persistance.Context;

namespace WebGame.Persistance.Repositories.LobbyRepository
{
    public class LobbyWriteRepository : WriteRepository<Lobby>, ILobbyWriteRepository
    {
        public LobbyWriteRepository(WebGameDbContext context) : base(context)
        {
        }
    }
}
