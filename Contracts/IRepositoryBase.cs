using System;
using System.Linq;
using System.Linq.Expressions;

namespace Contracts
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> ReadAll();
        IQueryable<T> ReadByCondition(Expression<Func<T, bool>> expression);
        T Create(T entity);
        T Update(T entity);
        bool Delete(T entity);
    }
}