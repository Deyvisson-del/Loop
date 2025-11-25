using Loop.Domain.Entities;

namespace Loop.Domain.Interfaces
{
    public interface ISolicitacaoRepository
    {
        Task<Solicitacao> CriarSolicitacaoAsync(Solicitacao solicitacao);
        Task<Solicitacao> ObterSolicitacaoPorId(int id);
        Task<IEnumerable<Solicitacao>> ObterPorEstagiarioIdAsync(int estagiarioId);
        Task<IEnumerable<Solicitacao>> ObterPorPendentesAsync();
        Task AtualizarAsync(Solicitacao);

    }
}
