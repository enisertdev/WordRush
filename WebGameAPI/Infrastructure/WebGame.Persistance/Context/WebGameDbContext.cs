using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebGame.Domain.Entities;

namespace WebGame.Persistance.Context
{
    public class WebGameDbContext : DbContext
    {
        public DbSet<Lobby> Lobbies { get; set; }
        public DbSet<User> Users { get; set; }
        public WebGameDbContext(DbContextOptions<WebGameDbContext> options) : base(options)
        {

        }
    }
}
