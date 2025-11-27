using Loop.Domain.Entities;

namespace Loop.Application.Interfaces
{
    public interface IGestorService
    {
        Task CriarEstagiarioAsync(Estagiario estagiario);
        Task AtualizarEstagiarioAsync(int estagiarioId, Estagiario estagiario);
        Task<Estagiario?> ObterEstagiarioPorIdAsync(int Id);
        Task<IEnumerable<Estagiario?>> ObterTodosEstagiariosAsync();
        Task<Estagiario?> ObterEstagiarioPorEmailAsync(string email);
        Task RemoverEstagiarioAsync(int id);
        
        Task AprovarSolicitacaoAsync(int solicitacaoId);
        Task RejeitarSolicitacaoAsync(int solicitacaoId, string motivoRejeicao);

        Task<IEnumerable<Solicitacao?>> ObterTodasSolicitacoesAsync();
        Task<IEnumerable<Solicitacao>> ObterSolicitacoesPendentesAsync();
        Task<IEnumerable<Frequencia>> GerarRelatorioFrequencia(int id);

    }
}
