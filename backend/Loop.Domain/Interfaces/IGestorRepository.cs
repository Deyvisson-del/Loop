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

        Task<IEnumerable<Frequencia>> VisualizarRelatorioEstagiarios(int id);

    }
}
