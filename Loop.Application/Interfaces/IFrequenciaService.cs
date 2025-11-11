using Loop.Application.DTOs;

namespace Loop.Application.Interfaces
{
    public interface IFrequenciaService
    {
        Task<IEnumerable<FrequenciaDTO>> ObterTodasAsync();
        Task<FrequenciaDTO?> ObterPorIdAsync(Guid id);
        Task<IEnumerable<FrequenciaDTO>> ObterPorEstagiarioAsync(Guid estagiarioId);
        Task AdicionarAsync(FrequenciaDTO dto);
        Task AtualizarAsync(FrequenciaDTO dto);
        Task RemoverAsync(Guid id);
    }
}
