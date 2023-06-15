using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AE.Application.Repository
{
    public interface IRepository<T>
    {
        Task<T> AddAsync(T entity, CancellationToken cancellationToken);
        Task<T> UpdateAsync(T entity, CancellationToken cancellationToken);
        T FindOne(Func<T, bool> predicate);
        Task SaveChangeAsync(CancellationToken cancellationToken);
        Task<bool> IsExist(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken);
    }
}
