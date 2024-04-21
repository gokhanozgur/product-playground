using ProductPlayground.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductPlayground.Application.Interfaces.Repositories
{
    public interface IWriteRepository<T> where T : class, IEntityBase, new()
    {
        Task AddAsync(T entity);

        Task AddRangeAsync(List<T> entities);

        Task<T> UpdateAsync(T entity);

        Task HardDeleteAsync(T entity);
    }
}
