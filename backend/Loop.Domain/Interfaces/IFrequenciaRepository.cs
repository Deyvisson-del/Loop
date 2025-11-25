

using Loop.Domain.Entities;

namespace Loop.Domain.Interfaces
{
    public interface IFrequenciaRepository
    {

        Task<Frequencia> RegistrarEntradaAsync(Frequencia frequencia);
        Task RegistrarSaidaAsync(Frequencia frequencia);
        Task<Frequencia?> ObterPorIdAsync(int id);
        Task<IEnumerable<Frequencia>> ObterPorEstagiarioIdAsync(int estagiarioId);
    }
}
