using Microsoft.EntityFrameworkCore;
using Sales.Application.Interfaces;
using Sales.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.DataAccess.Shared
{
    public class Repository<T> : UnitOfWork, IRepository<T> where T : class, IEntity
    {
        private readonly IAppContext _appContext;
        private readonly DbSet<T>? _dbSet;
        public Repository(IAppContext appContext) : base(appContext)
        {
            _appContext = appContext;
            _dbSet = appContext?.Set<T>();
        }
        public async Task<List<T>> GetAllAsync()
        {
            return _dbSet is null ? new List<T>() : await _dbSet.ToListAsync();
        }
        public async Task<T?> GetAsync(int id)
        {
            return _dbSet is null ? null : await _dbSet
                                                 .Where(e => e.Id == id)
                                                 .FirstOrDefaultAsync();
        }
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity).ConfigureAwait(false);
            await _appContext.Save();
        }
        public async Task UpdateAsync(T entity)
        {
            _dbSet.UpdateRange(entity);
            await _appContext.Save();
        }
    }
}
