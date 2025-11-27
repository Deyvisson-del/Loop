using Loop.Domain.Entities;

namespace Loop.Domain.Interfaces
{
    public interface IEstagiarioRepository
    {
        Task CriarEstagiarioAsync(Estagiario estagiario);
        Task AtualizarEstagiarioAsync(Estagiario estagiario);
        Task RemoverEstagiarioAsync(Estagiario estagiario);


        Task<Estagiario?> ObterEstagiarioPorIdAsync(int Id);
        Task<Estagiario?> ObterEstagiarioPorEmailAsync(string email);
        Task<IEnumerable<Estagiario>> ObterTodosEstagiariosAsync();
    }
}