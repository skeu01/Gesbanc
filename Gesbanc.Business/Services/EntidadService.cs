using Gesbanc.Business.Contracts;
using Gesbanc.Infrastructure.Contracts;
using Gesbanc.Model.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gesbanc.Business.Services
{
    public class EntidadService : BaseService<EntidadEntity>, IEntidadService
    {
        private IEntidadRepository _repository;

        public EntidadService(IEntidadRepository repository) : base(repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// get list of active / inactive entities
        /// </summary>
        /// <param name="activo">true / false / null (all)</param>
        /// <returns>list of entities</returns>
        public async Task<List<EntidadEntity>> GetAllAsync(bool? activo)
        {
            var entities = await GetAllAsync();

            //if contains param
            if(activo != null)
            {
                entities = entities.Where(x => x.Estado_Activo == activo).ToList(); 
            }

            return entities;
        }

    }
}
