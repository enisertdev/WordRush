using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Domain.Common;

namespace WebGame.Domain.Entities
{
    public class Lobby : BaseEntity
    {
        public Guid LeaderUserId { get; set; }
        public string Name { get; set; }
        public short? PlayerCount { get; set; }
        public short? MaxPlayers { get; set; } = 4; 
        public bool? IsPrivate { get; set; } = false;
        public ICollection<User>? Players { get; set; } = new List<User>();
    }
}
