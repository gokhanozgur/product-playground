using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using ProductPlayground.Application.Interfaces.Repositories;
using ProductPlayground.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProductPlayground.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : class, IEntityBase, new()
    {

        private readonly DbContext _dbContext;

        public ReadRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private DbSet<T> Entity { get => _dbContext.Set<T>(); }

        public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool enableTracking = false)
        {
            IQueryable<T> queryableEntity = Entity;
            if (!enableTracking) queryableEntity = queryableEntity.AsNoTracking();
            if (include is not null) queryableEntity = include(queryableEntity);
            if (predicate is not null) queryableEntity.Where(predicate);
            if (orderBy is not null) return await orderBy(queryableEntity).ToListAsync();

            return await queryableEntity.ToListAsync();
        }

        public async Task<IList<T>> GetAllByPagingAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool enableTracking = false, int currentPage = 1, int pageSize = 3)
        {
            IQueryable<T> queryableEntity = Entity;
            if (!enableTracking) queryableEntity = queryableEntity.AsNoTracking();
            if (include is not null) queryableEntity = include(queryableEntity);
            if (predicate is not null) queryableEntity.Where(predicate);
            if (orderBy is not null) return await orderBy(queryableEntity).Skip((currentPage - 1) * pageSize).Take(pageSize).ToListAsync();

            return await queryableEntity.ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool enableTracking = false)
        {
            IQueryable<T> queryableEntity = Entity;
            if (!enableTracking) queryableEntity = queryableEntity.AsNoTracking();
            if (include is not null) queryableEntity = include(queryableEntity);
            //queryableEntity.Where(predicate);
            //if (orderBy is not null) return await orderBy(queryableEntity).ToListAsync();

            return await queryableEntity.FirstOrDefaultAsync(predicate);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null)
        {
            Entity.AsNoTracking();
            if (predicate is not null) Entity.Where(predicate);
            return await Entity.CountAsync();
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate, bool enableTracking = false)
        {
            if (!enableTracking) Entity.AsNoTracking();
            return Entity.Where(predicate);
        }
    }
}
