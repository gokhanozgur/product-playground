using Microsoft.EntityFrameworkCore;
using ProductPlayground.Application.Interfaces.Repositories;
using ProductPlayground.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductPlayground.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : class, IEntityBase, new()
    {
        private readonly DbContext _dbContext;

        public WriteRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private DbSet<T> Entity { get => _dbContext.Set<T>(); }

        public async Task AddAsync(T entity)
        {
            await Entity.AddAsync(entity);
        }

        public async Task AddRangeAsync(List<T> entities)
        {
            await Entity.AddRangeAsync(entities);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            await Task.Run(() => { Entity.Update(entity); });
            return entity;
        }

        public async Task HardDeleteAsync(T entity)
        {
            await Task.Run(() => { Entity.Remove(entity); });
        }

        public async Task HardDeleteRangeAsync(IList<T> entity)
        {
            await Task.Run(() => { Entity.RemoveRange(entity); });
        }
    }
}
