using AE.Application.Extensions;
using AE.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AE.Application.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AECCodeChallangeContext _dbContext;
        public Repository(AECCodeChallangeContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> IsExist(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
        {
            return await _dbContext.Set<T>().AnyAsync(predicate, cancellationToken);
        } 
        public async Task<T> AddAsync(T entity, CancellationToken cancellationToken)
        {
            await _dbContext.Set<T>().AddAsync(entity, cancellationToken);
            await SaveChangeAsync(cancellationToken);
            return entity;
        }

        public async Task SaveChangeAsync(CancellationToken cancellationToken)
        {
            _dbContext.ChangeTracker.UpdateAuditProperties();
           await  _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<T> UpdateAsync(T entity, CancellationToken cancellationToken)
        {
            _dbContext.Set<T>().Update(entity);
            await SaveChangeAsync(cancellationToken);
            return entity;
        }

        public async Task<int> Delete(T entity, CancellationToken cancellationToken)
        {
           _dbContext.Set<T>().Remove(entity);
           return await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public T FindOne(Func<T, bool> predicate)
        {
            return  _dbContext.Set<T>().Where(predicate).FirstOrDefault();
        }

        public IQueryable<T> GetAll()
        {
            return _dbContext.Set<T>();
        }
    }
}
