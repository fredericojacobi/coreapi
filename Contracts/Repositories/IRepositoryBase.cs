using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Contracts.Repositories
{
    public interface IRepositoryBase<T>
    {
        Task<IList<T>> ReadAllAsync(params Expression<Func<T, Object>>[] includeExpressions);
        Task<IList<T>> ReadByConditionAsync(Expression<Func<T, bool>> expression, params Expression<Func<T, Object>>[] includeExpressions);
        Task<T> CreateAsync(T entity);
        Task<IList<T>> CreateMultipleAsync(IEnumerable<T> entities);
        Task<T> UpdateAsync(Guid id, T entity);
        Task<bool> DeleteAsync(T entity);
        Task<bool> DeleteMultipleAsync(int quantity);
    }
}