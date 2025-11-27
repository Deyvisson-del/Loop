using Loop.Domain.Entities;

namespace Loop.Domain.Interfaces
{

    public interface IGestorRepository
    {
        Task<Gestor?> ObterGestorPorIdAsync(int Id);

        Task<IEnumerable<Gestor>> ObterTodosGestoresAsync();

        Task<Gestor?> ObterGestorPorEmailAsync(string email);

        Task CriarGestorAsync(Gestor gestor);

        Task AtualizarGestorAsync(int gestorId, Gestor gestor);

        Task RemoverGestorAsync(int id);

        Task AprovarSolicitacaoAsync(int solicitacaoId);

        Task RejeitarSolicitacaoAsync(int solicitacaoId, string motivoRejeicao);

        Task<IEnumerable<Frequencia>> GerarRelatorioEstagiariosAsync(int id);

    }
}
