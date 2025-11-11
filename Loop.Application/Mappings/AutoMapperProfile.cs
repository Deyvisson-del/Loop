using AutoMapper;
using Loop.Application.DTOs;
using Loop.Domain.Entities;

namespace Loop.Application.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Frequencia, FrequenciaDTO>().ReverseMap();
            CreateMap<Estagiario, EstagiarioDTO>().ReverseMap();
        }
    }
}
