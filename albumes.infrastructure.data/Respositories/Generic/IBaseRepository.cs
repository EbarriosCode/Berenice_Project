using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace albumes.infrastructure.data.Respositories.Generic
{
    public interface IBaseRepository<T> where T : class
    {
        IEnumerable<T> Get(Expression<Func<T, bool>> whereCondition = null,
                           Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                           string includeProperties = "");
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity, object key);
        Task<int> DeleteAsync(T entity);
    }
}
