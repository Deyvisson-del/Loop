using Loop.Domain.Entities;
namespace Loop.Domain.Interfaces
{
    public interface IGestorRepository
    {
        Task<bool> ValidarCredenciaisAsync(string email, string senha);
        void AdicionarEstagiario(object estagiario);
        void RemoverEstagiario(Guid estagiarioId);
        void AtualizarEstagiario(object estagiario); 
        object ObterEstagiarioPorId(Guid estagiarioId);
        Task<IEnumerable<Estagiario>> ListarEstagiariosAsync();

    }
}