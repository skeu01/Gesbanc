using Gesbanc.Infrastructure.Context;
using Gesbanc.Infrastructure.Contracts;
using Gesbanc.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
        /// Get all Grupo entidades
        /// </summary>
        /// <returns>list of grupo entidades</returns>
        public async Task<List<GrupoEntidadEntity>> GetAllGrupoEntidadesAsync()
        {
            return await _dbContext.GrupoEntidad.ToListAsync();
        }

    }
}
