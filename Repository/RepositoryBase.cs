using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Contracts.Repositories;
using Entities.Context;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private AppDbContext _context { get; }

        protected RepositoryBase(AppDbContext context) => _context = context;

        public async Task<IList<T>> ReadAllAsync(params Expression<Func<T, Object>>[] includeExpressions)
        {
            var query = _context.Set<T>().AsQueryable();
            if (!includeExpressions.Any()) return await query.AsNoTracking().ToListAsync();
            includeExpressions.ToList().ForEach(x => query = query.Include(x));
            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<IList<T>> ReadByConditionAsync(Expression<Func<T, bool>> expression, params Expression<Func<T, Object>>[] includeExpressions)
        {
            var query = _context.Set<T>().Where(expression);
            if (!includeExpressions.Any()) return await query.AsNoTracking().ToListAsync();
            includeExpressions.ToList().ForEach(x => query = query.Include(x));
            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<T> CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            await _context.Entry(entity).ReloadAsync();
            return entity;
        }

        public async Task<IList<T>> CreateMultipleAsync(IEnumerable<T> entities)
        {
            var entityList = entities.ToList();
            await _context.Set<T>().AddRangeAsync(entityList);
            await _context.SaveChangesAsync();
            await _context.Entry(entityList).ReloadAsync();
            return entityList;
        }

        public async Task<T> UpdateAsync(Guid id, T entity)
        {
            var currentEntity = await _context.Set<T>().FindAsync(id);
            _context.Entry(currentEntity).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            await _context.Entry(entity).ReloadAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteMultipleAsync(int quantity)
        {
            var entityList = await ReadAllAsync();
            entityList = entityList.Take(quantity).ToList();
            if (!entityList.Any()) return false;
            _context.Set<T>().RemoveRange(entityList);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}