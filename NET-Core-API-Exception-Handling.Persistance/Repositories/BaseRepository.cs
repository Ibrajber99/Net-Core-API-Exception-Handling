using Microsoft.EntityFrameworkCore;
using NET_Core_API_Exception_Handling.Application.Repo_Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NET_Core_API_Exception_Handling.Persistance.Repositories
{
    public class BaseRepository<T> : IAsyncBaseRepository<T> where T : class
    {
        protected readonly PersonDbContext _dbContext;

        public BaseRepository(PersonDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();

        }

        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await _dbContext.Set<T>().FindAsync(id);

            return entity;
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            var entityList = await _dbContext.Set<T>().ToListAsync();
            return entityList;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            return entity;
        }

    }
}
