using Loop.Domain.Entities;

namespace Loop.Domain.Interfaces
{
    public interface IEstagiarioRepository
    {
        Task<Frequencia?> BaterPonto(Frequencia frequencia);

        Task SolicitarAjusteCargaHoraria(int estagiarioId, string justificativa, TimeOnly horaCorrigida);

        Task<IEnumerable<Frequencia?>> VisualizarRelatorio();
    }
}
