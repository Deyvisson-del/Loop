using Loop.Application.DTOs;
using Loop.Domain.Entities;

namespace Loop.Application.Interfaces
{
    public interface IEstagiarioService
    {
        Task<Frequencia?> BaterPonto(Frequencia frequencia);

        Task SolicitarAjusteCargaHoraria(int estagiarioId, string justificativa, TimeOnly horaCorrigida);

        Task<IEnumerable<Frequencia?>> VisualizarRelatorio();

        Task<EstagiarioDTO?> ObterPorEmailAsync(string email);

        Task<FrequenciaDTO> RagistrarPonto(FrequenciaDTO frequenciaDTO);

    }
}
