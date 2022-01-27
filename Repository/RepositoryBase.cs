using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Contracts;
using Contracts.Repositories;
using Entities;
using Entities.Context;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private AppDbContext _context { get; }

        protected RepositoryBase(AppDbContext context) => _context = context;

        public async Task<IList<T>> ReadAllAsync(params Expression<Func<T, bool>>[] includeExpressions)
        {
            var query = _context.Set<T>();
            if (!includeExpressions.Any()) return await query.AsNoTracking().ToListAsync();
            includeExpressions.ToList().ForEach(x => query.Include(x));
            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<IList<T>> ReadByConditionAsync(Expression<Func<T, bool>> expression, params Expression<Func<T, Object>>[] includeExpressions)
        {
            var query = _context.Set<T>().Where(expression);
            if (!includeExpressions.Any()) return await query.AsNoTracking().ToListAsync();
            // foreach (var include in includeExpressions)
            // query = query.Include(include);
            includeExpressions.ToList().ForEach(x => query.Include(x));
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

        public async Task<bool> DeleteMultiplesAsync()
        {
            var entityList = await ReadAllAsync();
            if (!entityList.Any()) return false;
            _context.Set<T>().RemoveRange(entityList);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}