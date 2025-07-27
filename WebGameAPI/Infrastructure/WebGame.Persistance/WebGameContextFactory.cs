using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using WebGame.Persistance.Configuration;
using WebGame.Persistance.Context;

namespace WebGame.Persistance
{
    public class WebGameContextFactory : IDesignTimeDbContextFactory<WebGameDbContext>
    {
        public WebGameDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<WebGameDbContext>();
            optionsBuilder.UseSqlServer(ConnectionConfiguration.ConnectionString);
            return new WebGameDbContext(optionsBuilder.Options);
        }
    }
}
