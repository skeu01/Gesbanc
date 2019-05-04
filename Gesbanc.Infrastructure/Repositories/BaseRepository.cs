using Gesbanc.Infrastructure.Context;
using Gesbanc.Infrastructure.Contracts;
using Gesbanc.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gesbanc.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly GesbancContext _dbContext;

        public BaseRepository(GesbancContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Get All entities.
        /// </summary>
        /// <returns>List of Entities</returns>
        public async Task<List<T>> GetAllAsync()
        {
                return await _dbContext.Set<T>()
                .OrderBy(x => x.Id)
                .ToListAsync();
        }

        /// <summary>
        /// Get T by Id
        /// </summary>
        /// <param name="id">identifier</param>
        /// <returns>Entity filtered by Id</returns>
        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        /// <summary>
        /// Post Entity
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Entity with Id</returns>
        public async Task<T> PostAsync(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        /// <summary>
        /// Put Entity
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Entity</returns>
        public async Task<T> PutAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <returns><c>True</c>All ok. <c>False</c> was an error</returns>
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);

            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
