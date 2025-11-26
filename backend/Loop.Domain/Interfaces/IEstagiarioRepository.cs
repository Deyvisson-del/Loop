using Loop.Domain.Entities;

namespace Loop.Domain.Interfaces
{
    public interface IEstagiarioRepository
    {
        Task<Frequencia?> BaterEntradaAsync(int id);
        Task<Frequencia?> BaterSaidaAsync(int id);

        Task SolicitarAjusteCargaHoraria(int estagiarioId, string justificativa, TimeSpan horaEntrada, TimeSpan horaSaida);

        Task<IEnumerable<Frequencia?>> VisualizarRelatorio(int estagiarioId);
    }
}
