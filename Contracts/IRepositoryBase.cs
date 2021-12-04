using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Contracts
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> ReadAll();
        IQueryable<T> ReadByCondition(Expression<Func<T, bool>> expression);
        T Create(T entity);
        bool CreateMultiples(IList<T> entities);
        T Update(T entity);
        bool Delete(T entity);
    }
}