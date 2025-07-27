using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebGame.Application.Interfaces;
using WebGame.Application.Interfaces.LobbyInterface;
using WebGame.Application.Interfaces.UserRepository;
using WebGame.Persistance.Configuration;
using WebGame.Persistance.Context;
using WebGame.Persistance.Repositories;
using WebGame.Persistance.Repositories.LobbyRepository;
using WebGame.Persistance.Repositories.UserRepository;

namespace WebGame.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceServices(this IServiceCollection services)
        {
            services.AddDbContext<WebGameDbContext>(options =>
                options.UseSqlServer(ConnectionConfiguration.ConnectionString));
            services.AddScoped<IUserReadRepository, UserReadRepository>();
            services.AddScoped<IUserWriteRepository, UserWriteRepository>();
            services.AddScoped<ILobbyReadRepository, LobbyReadRepository>();
            services.AddScoped<ILobbyWriteRepository, LobbyWriteRepository>();
        }
    }
}
