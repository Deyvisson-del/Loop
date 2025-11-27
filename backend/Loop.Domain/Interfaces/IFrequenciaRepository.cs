using Loop.Domain.Entities;

namespace Loop.Domain.Interfaces
{
    public interface IFrequenciaRepository
    {
        Task<Frequencia?> BaterEntradaAsync(int id);
        Task<Frequencia?> BaterSaidaAsync(int id);
        Task<Frequencia?> ObterPorIdAsync(int id);
        Task AtualizarFrequenciaAsync(int id,Frequencia frequencia);
        Task<IEnumerable<Frequencia>> ObterPorEstagiarioIdAsync(int estagiarioId);
    }
}
