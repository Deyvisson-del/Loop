using Mapster;
using Loop.Application.DTOs;
using Loop.Domain.Entities;

namespace Loop.Application.Mappings
{
    public static class MappingConfig
    {
        public static void RegisterMappings(TypeAdapterConfig config)
        {
            config.NewConfig<Estagiario, EstagiarioDTO>();
            config.NewConfig<EstagiarioDTO, Estagiario>();

            // Frequência
            config.NewConfig<Frequencia, FrequenciaDTO>();
            config.NewConfig<FrequenciaDTO, Frequencia>();
        }
    }
}
