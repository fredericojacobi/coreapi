using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Contracts.Repositories
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> ReadAll();
        IQueryable<T> ReadByCondition(Expression<Func<T, bool>> expression);
        T Create(T entity);
        IEnumerable<T> CreateMultiples(IEnumerable<T> entities);
        T Update(T entity);
        bool Delete(T entity);
        bool DeleteMultiples();
    }
}