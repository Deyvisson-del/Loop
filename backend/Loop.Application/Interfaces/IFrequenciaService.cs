using Loop.Application.DTOs;

namespace Loop.Application.Interfaces
{
    /// <summary>
    /// Define os serviços de aplicação relacionados à gestão de frequências dos estagiários.
    /// </summary>
    /// <remarks>
    /// Esta interface herda as operações básicas de <see cref="IBaseService{FrequenciaDTO}"/> 
    /// e adiciona métodos específicos para o gerenciamento de registros de frequência, 
    /// como a obtenção de frequências associadas a um estagiário.
    /// </remarks>
    public interface IFrequenciaService : IBaseService<FrequenciaDTO>
    {
        /// <summary>
        /// Obtém todas as frequências associadas a um determinado estagiário.
        /// </summary>
        /// <param name="estagiarioId">Identificador único do estagiário.</param>
        /// <returns>
        /// Uma coleção de objetos <see cref="FrequenciaDTO"/> representando 
        /// todas as frequências registradas pelo estagiário informado.
        /// </returns>
        /// <example>
        /// Exemplo de uso:
        /// <code>
        /// var frequencias = await _frequenciaService.ObterPorEstagiarioAsync(estagiarioId);
        /// 
        /// foreach (var freq in frequencias)
        /// {
        ///     Console.WriteLine($"{freq.Data}: {freq.HoraChegada} - {freq.HoraSaida}");
        /// }
        /// </code>
        /// </example>
        Task<IEnumerable<FrequenciaDTO>> ObterPorEstagiarioAsync(int estagiarioId);
    }
}
