using Loop.Domain.Entities;
using Loop.Domain.Enums;

namespace Loop.Domain.Interfaces
{
    public interface ISolicitacaoRepository
    {
        Task<Solicitacao?> ObterSolicitacaoPorId(int id);
        Task<Solicitacao?> ObterPorEstagiarioIdAsync(int estagiarioId);
        Task AtualizarAsync(Solicitacao solicitacao);
        Task<IEnumerable<Solicitacao?>> ObterTodasSolicidacaoAsync();
        Task<IEnumerable<Solicitacao?>> ObterPorPendentesAsync();
    }
}
