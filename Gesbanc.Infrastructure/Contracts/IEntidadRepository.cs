using Gesbanc.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gesbanc.Infrastructure.Contracts
{
    public interface IEntidadRepository : IBaseRepository<EntidadEntity>
    {
        /// <summary>
        /// Get all Grupo entidades
        /// </summary>
        /// <returns>list of grupo entidades</returns>
        Task<List<GrupoEntidadEntity>> GetAllGrupoEntidadesAsync();
    }
}