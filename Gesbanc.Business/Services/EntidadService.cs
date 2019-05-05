using AutoMapper;
using Gesbanc.Business.Contracts;
using Gesbanc.Infrastructure.Contracts;
using Gesbanc.Model.Dtos;
using Gesbanc.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gesbanc.Business.Services
{
    public class EntidadService : BaseService<EntidadEntity>, IEntidadService
    {
        private IEntidadRepository _repository;
        private readonly IMapper _mapper;

        public EntidadService(IEntidadRepository repository, IMapper mapper) : base(repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// get list of active / inactive entities
        /// </summary>
        /// <param name="activo">true / false / null (all)</param>
        /// <returns>list of entities</returns>
        public async Task<List<EntidadDto>> GetAllEntidadesAsync(bool? activo)
        {   
            var entities = await _repository.GetAllEntidadesAsync();

            //if contains param
            if(activo != null)
            {
                entities = entities.Where(x => x.Estado_Activo == activo).ToList(); 
            }

            return _mapper.Map<List<EntidadDto>>(entities); 
        }

        /// <summary>
        /// get list of active / inactive grupo entidades
        /// </summary>
        /// <param name="activo">true / false / null (all)</param>
        /// <returns>list of entities</returns>
        public async Task<List<GrupoEntidadEntity>> GetAllGrupoEntidadAsync()
        {
            return await _repository.GetAllGrupoEntidadesAsync();
        }

    }
}
