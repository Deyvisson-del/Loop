using Loop.Domain.Entities;

namespace Loop.Domain.Interfaces
{
    public interface ISolicitacaoRepository
    {

        Task CriarSolicitacaoAsync(Solicitacao solicitacao);
        Task AtualizarSolicitacaoAsync(Solicitacao solicitacao);
        Task RemoverSolicitacaoAsync(int id);

        Task<Solicitacao> ObterSolicitacaoPorId(int id);
        Task<Solicitacao> ObterPorEstagiarioIdAsync(int estagiarioId);
        Task<IEnumerable<Solicitacao>> ObterTodasSolicidacaoAsync();
        Task<IEnumerable<Solicitacao>> ObterPorPendentesAsync();

        Task AprovarSolicitacaoAsync(int solicitacaoId);
        Task RejeitarSolicitacaoAsync(int solicitacaoId, string motivoRejeicao);
    }
}
