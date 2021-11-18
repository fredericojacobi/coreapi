using System;
using System.Linq;
using System.Linq.Expressions;
using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected AppDbContext _context { get; }

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
    }
}