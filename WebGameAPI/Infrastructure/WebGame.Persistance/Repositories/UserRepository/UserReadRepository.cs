using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Application.Interfaces.UserRepository;
using WebGame.Domain.Entities;
using WebGame.Persistance.Context;

namespace WebGame.Persistance.Repositories.UserRepository
{
    public class UserReadRepository : ReadRepository<User>, IUserReadRepository
    {
        public UserReadRepository(WebGameDbContext context) : base(context)
        {
        }
    }
}
