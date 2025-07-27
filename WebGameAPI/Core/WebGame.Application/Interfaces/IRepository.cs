using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebGame.Domain.Common;

namespace WebGame.Application.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        public DbSet<T> Table { get;}
    }
}
