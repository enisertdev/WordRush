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
    public class UserWriteRepository : WriteRepository<User>, IUserWriteRepository
    {
        public UserWriteRepository(WebGameDbContext context) : base(context)
        {
        }
    }
}
