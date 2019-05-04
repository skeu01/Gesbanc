using Gesbanc.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gesbanc.Business.Contracts
{
    public interface IEntidadService : IBaseService<EntidadEntity>
    {
        /// <summary>
        /// get list of active / inactive entities
        /// </summary>
        /// <param name="activo">true / false / null (all)</param>
        /// <returns>list of entities</returns>
        Task<List<EntidadEntity>> GetAllAsync(bool? activo);
    }
}
