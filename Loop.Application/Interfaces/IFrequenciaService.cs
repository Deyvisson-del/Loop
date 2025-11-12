using Loop.Application.DTOs;

namespace Loop.Application.Interfaces
{
    public interface IFrequenciaService : IBaseService<FrequenciaDTO>
    {
        Task<IEnumerable<FrequenciaDTO>> ObterPorEstagiarioAsync(Guid estagiarioId);
    }
}
