using Loop.Domain.Entities;

namespace Loop.Application.Interfaces
{
    public interface IEstagiarioService
    {
        Task<Frequencia> BaterEntradaAsync(int estagiarioId);
        Task<Frequencia> BaterSaidaAsync(int estagiarioId);

        Task SolicitarAjusteDePonto(int estagiarioId, string justificativa, TimeSpan horaEntrada, TimeSpan horaSaida);
        Task<IEnumerable<Frequencia>> VisualizarRelatorio(int estagiarioId);

    }
}
