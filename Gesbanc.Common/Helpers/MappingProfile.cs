using AutoMapper;
using Gesbanc.Model.Dtos;
using Gesbanc.Model.Entities;

namespace Gesbanc.Common.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Entidad
            CreateMap<EntidadEntity, EntidadDto>()
                .ForMember(x => x.GrupoEntidadNombre, opt => opt.MapFrom(src => src.GrupoEntidad.Nombre));

            CreateMap<EntidadDto, EntidadEntity>();
        }
    }
}
