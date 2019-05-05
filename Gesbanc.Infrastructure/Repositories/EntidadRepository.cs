using Gesbanc.Infrastructure.Context;
using Gesbanc.Infrastructure.Contracts;
using Gesbanc.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gesbanc.Infrastructure.Repositories
{
    public class EntidadRepository : BaseRepository<EntidadEntity>, IEntidadRepository
    {
        protected new readonly GesbancContext _dbContext;

        public EntidadRepository(GesbancContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Get All entities.
        /// </summary>
        /// <returns>List of Entities</returns>
        public async Task<List<EntidadEntity>> GetAllEntidadesAsync()
        {
            return await _dbContext.Set<EntidadEntity>()
            .Include(x => x.GrupoEntidad)
            .OrderBy(x => x.Id)
            .ToListAsync();
        }

        /// <summary>
        /// Get all Grupo entidades
        /// </summary>
        /// <returns>list of grupo entidades</returns>
        public async Task<List<GrupoEntidadEntity>> GetAllGrupoEntidadesAsync()
        {
            return await _dbContext.GrupoEntidad.ToListAsync();
        }

    }
}
