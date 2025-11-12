using Mapster;
using Loop.Application.DTOs;
using Loop.Domain.Entities;

namespace Loop.Application.Mappings
{
    /// <summary>
    /// Classe responsável por registrar as configurações de mapeamento
    /// entre entidades de domínio e objetos de transferência de dados (DTOs).
    /// </summary>
    /// <remarks>
    /// Utiliza a biblioteca <see cref="Mapster"/> para simplificar o processo de
    /// conversão entre objetos de diferentes camadas da aplicação, como
    /// <see cref="Estagiario"/> ↔ <see cref="EstagiarioDTO"/> e
    /// <see cref="Frequencia"/> ↔ <see cref="FrequenciaDTO"/>.
    /// </remarks>
    public static class MappingConfig
    {
        /// <summary>
        /// Registra os mapeamentos entre entidades e DTOs na configuração global do Mapster.
        /// </summary>
        /// <param name="config">Instância de <see cref="TypeAdapterConfig"/> utilizada
        /// para registrar as regras de conversão.</param>
        /// <example>
        /// Exemplo de uso:
        /// <code>
        /// var config = TypeAdapterConfig.GlobalSettings;
        /// MappingConfig.RegisterMappings(config);
        /// </code>
        /// </example>
        public static void RegisterMappings(TypeAdapterConfig config)
        {
            // Mapeamentos para Estagiário
            config.NewConfig<Estagiario, EstagiarioDTO>();
            config.NewConfig<EstagiarioDTO, Estagiario>();

            // Mapeamentos para Frequência
            config.NewConfig<Frequencia, FrequenciaDTO>();
            config.NewConfig<FrequenciaDTO, Frequencia>();
        }
    }
}
