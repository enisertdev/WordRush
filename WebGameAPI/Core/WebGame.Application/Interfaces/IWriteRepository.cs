using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Domain.Common;

namespace WebGame.Application.Interfaces
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T model);
        Task<bool> AddRangeAsync(IEnumerable<T> models);
        bool Remove(T model);
        bool RemoveRange(IEnumerable<T> models);
        bool Update(T model);
        Task<int> SaveChangesAsync();
    }
}
