using Loop.Domain.Entities;

namespace Loop.Application.Interfaces
{
    public interface IAdministradorService
    {
        Task<IEnumerable<Estagiario>> ObterEstagiariosAsync();
        Task<IEnumerable<Solicitacao>> ObterSolicitacoesPendentesAsync();
        Task AprovarSolicitacaoAsync(int solicitacaoId);
        Task RejeitarSolicitacaoAsync(int solicitacaoId, string motivoRejeicao);
    }
}
