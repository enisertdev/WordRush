using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Domain.Common;

namespace WebGame.Domain.Entities
{
    public class User : BaseEntity
    {

        public string? Name { get; set; }
        public string? ConnectionId { get; set; }
        public Guid? LobbyId { get; set; }
        public Lobby? Lobby { get; set; }
        public bool IsLeader { get; set; } = false ;
    }
}
