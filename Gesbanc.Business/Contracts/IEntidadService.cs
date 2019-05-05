using Gesbanc.Model.Dtos;
using Gesbanc.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gesbanc.Business.Contracts
{
    public interface IEntidadService : IBaseService<EntidadEntity>
    {

        /// <summary>
        /// Get all entidades with grupo entidad
        /// </summary>
        /// <returns>list of grupo entidades</returns>
        Task<List<EntidadDto>> GetAllEntidadesAsync(bool? activo);
        
        /// <summary>
        /// get list of active / inactive grupo entidades
        /// </summary>
        /// <param name="activo">true / false / null (all)</param>
        /// <returns>list of entities</returns>
        Task<List<GrupoEntidadEntity>> GetAllGrupoEntidadAsync();
    }
}
