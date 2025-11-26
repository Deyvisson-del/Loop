using Loop.Domain.Entities;

namespace Loop.Domain.Interfaces
{
    public interface IEstagiarioRepository
    {

        Task CriarEstagiarioAsync(Estagiario estagiario);

        Task<Estagiario?> ObterEstagiarioPorIdAsync(int Id);
        Task<Estagiario?> ObterEstagiarioPorEmailAsync(string email);
        Task RemoverEstagiarioAsync(int id);
        Task AtualizarEstagiario(int id, Estagiario estagiario);

        Task<IEnumerable<Estagiario>> ObterTodosEstagiariosAsync();

        Task SolicitarAjusteCargaHoraria(int estagiarioId, string justificativa, TimeSpan horaEntrada, TimeSpan horaSaida);

        Task<IEnumerable<Frequencia?>> VisualizarRelatorio(int estagiarioId);
    }
}
