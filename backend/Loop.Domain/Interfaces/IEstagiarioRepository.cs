using Loop.Domain.Entities;

namespace Loop.Domain.Interfaces
{
    public interface IEstagiarioRepository
    {
        Task<Frequencia?> BaterPonto(Frequencia frequencia);

        Task SolicitarAjusteCargaHoraria(int estagiarioId, string justificativa, TimeSpan novaHoraEntrada, TimeSpan novaHoraSaida);

        Task<IEnumerable<Frequencia?>> VisualizarRelatorio(int estagiarioId);
    }
}
