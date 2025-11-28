using Loop.Domain.Entities;

namespace Loop.Application.Interfaces
{
    public interface IAdministradorService
    {
        Task CriarEstagiarioAsync(Estagiario estagiario);
        Task CriarGestorAsync(Gestor gestor);

        //Task<Gestor?> ObterGestorPorIdAsync(int Id);
        //Task<Estagiario?> ObterEstagiarioPorIdAsync(int Id);
        //Task<Frequencia?> ObterFrequenciaPorIdAsync(int Id);


        //Task<Gestor?> ObterGestorPorEmailAsync(string email);
        //Task<Estagiario?> ObterEstagiarioPorEmailAsync(string email);

        //Task AtualizarGestorAsync(int gestorId, Gestor gestor);
        //Task AtualizarEstagiarioAsync(int estagiarioId, Estagiario estagiario);
        //Task AtualizarFrequenciasync(int frequenciaId, Frequencia frequencia);


        //Task RemoverGestorAsync(int id);
        //Task RemoverEstagiarioAsync(int id);


        //Task<IEnumerable<Gestor?>> ObterTodosGestoresAsync();
        //Task<IEnumerable<Estagiario?>> ObterTodosEstagiariosAsync();
        //Task<IEnumerable<Solicitacao?>> ObterTodasSolicitacoesAsync();


        //Task<IEnumerable<Solicitacao>> ObterSolicitacoesPendentesAsync();
        //Task<IEnumerable<Frequencia?>> GerarRelatorioFrequencia(int id);

        //Task AprovarSolicitacaoAsync(int solicitacaoId);
        //Task RejeitarSolicitacaoAsync(int solicitacaoId, string motivoRejeicao);

    }
}
