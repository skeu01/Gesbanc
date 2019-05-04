using Gesbanc.Business.Contracts;
using Gesbanc.Infrastructure.Contracts;
using Gesbanc.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gesbanc.Business.Services
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        private IBaseRepository<T> _repository;

        public BaseService(IBaseRepository<T> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Get All entities.
        /// </summary>
        /// <returns>List of Entities</returns>
        public async Task<List<T>> GetAllAsync()
        {
            try
            {
                return await _repository.GetAllAsync();
            }
            catch
            {
                return null;
            }
        }


        /// <summary>
        /// Get T by Id
        /// </summary>
        /// <param name="id">identifier</param>
        /// <returns>Entity filtered by Id</returns>
        public async Task<T> GetByIdAsync(int id)
        {
            try
            {
                return await _repository.GetByIdAsync(id);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Post Entity
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Entity with Id</returns>
        public async Task<T> PostAsync(T entity)
        {
            try
            {
                return await _repository.PostAsync(entity);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Put Entity
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Entity</returns>
        public async Task<T> PutAsync(T entity)
        {
            try
            {
                return await _repository.PutAsync(entity);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <returns><c>True</c>All ok. <c>False</c> was an error</returns>
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                return await _repository.DeleteAsync(id);
            }
            catch
            {
                return false;
            }
        }
    }
}
