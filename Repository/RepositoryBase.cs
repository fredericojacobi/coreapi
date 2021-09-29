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
        protected AppDbContext _context { get; set; }

        public RepositoryBase(AppDbContext context) => _context = context;

        public IQueryable<T> FindAll() => _context.Set<T>().AsNoTracking();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) =>
            _context.Set<T>().Where(expression).AsNoTracking();

        public T Create(T entity)
        {
            // TODO: verificar o ReloadAsync() para retornar o objeto gravado
            // TODO: verificar o SaveChanges() se houve alteracao
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            _context.Entry(entity).ReloadAsync();
            return entity;
        }

        public bool Update(T entity)
        {
            _context.Set<T>().Update(entity);
            return _context.SaveChanges() > 0;
        }

        public bool Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            return _context.SaveChanges() > 0;
        } 
    }
}