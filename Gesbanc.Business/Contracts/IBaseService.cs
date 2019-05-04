using Gesbanc.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gesbanc.Business.Contracts
{
    public interface IBaseService<T> where T : BaseEntity
    {
        /// <summary>
        /// Get All entities.
        /// </summary>
        /// <returns>List of Entities</returns>
        Task<List<T>> GetAllAsync();

        /// <summary>
        /// Get T by Id
        /// </summary>
        /// <param name="id">identifier</param>
        /// <returns>Entity filtered by Id</returns>
        Task<T> GetByIdAsync(int id);

        /// <summary>
        /// Post Entity
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Entity with Id</returns>
        Task<T> PostAsync(T entity);

        /// <summary>
        /// Put Entity
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Entity</returns>
        Task<T> PutAsync(T entity);

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <returns><c>True</c>All ok. <c>False</c> was an error</returns>
        Task<bool> DeleteAsync(int id);
    }
}
