using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Contracts;
using Contracts.Repositories;
using Entities;
using Entities.Context;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private AppDbContext _context { get; }

        public RepositoryBase(AppDbContext context) => _context = context;

        public IQueryable<T> ReadAll() => _context.Set<T>().AsNoTracking();

        public IQueryable<T> ReadByCondition(Expression<Func<T, bool>> expression) =>
            _context.Set<T>().Where(expression).AsNoTracking();

        public T Create(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            _context.Entry(entity).Reload();
            return entity;
        }

        public IEnumerable<T> CreateMultiples(IEnumerable<T> entities)
        {
            var entityList = entities.ToList();
            _context.Set<T>().AddRange(entityList);
            _context.SaveChanges();
            _context.Entry(entityList).Reload();
            return entityList;
        }

        public T Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
            _context.Entry(entity).Reload();
            return entity;
        }

        public bool Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            return _context.SaveChanges() > 0;
        }

        public bool DeleteMultiples()
        {
            var entityList = ReadAll().ToList();
            if (entityList.Count <= 0) return false;
            _context.Set<T>().RemoveRange(entityList);
            return _context.SaveChanges() > 0;
        }
    }
}