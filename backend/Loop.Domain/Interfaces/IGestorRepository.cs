using Loop.Domain.Entities;

namespace Loop.Domain.Interfaces
{
    public interface IGestorRepository
    {
        Task CriarGestorAsync(Gestor gestor);
        Task AtualizarGestorAsync(Gestor gestor);
        Task RemoverGestorAsync(Gestor gestor);

        Task<Gestor> ObterGestorPorIdAsync(int Id);
        Task<Gestor> ObterGestorPorEmailAsync(string email);
        Task<IEnumerable<Gestor>> ObterTodosGestoresAsync();

    }
}
