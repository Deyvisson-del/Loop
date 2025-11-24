using Loop.Domain.Entities;

namespace Loop.Domain.Interfaces
{
    
    public interface IGestorRepository 
    {
        Task<Estagiario?> ObterEstagiarioPorIdAsync(int Id);
        
        Task<IEnumerable<Estagiario>> ObterTodosEstagiariosAsync();        
   
        Task<Estagiario?> ObterEstagiarioPorEmailAsync(string email);
   
        Task CriarEstagiarioAsync(Estagiario estagiario);

        Task AtualizarEstagiarioAsync(Estagiario estagiario);
   
        Task RemoverEstagiarioAsync(int id);

        Task<IEnumerable<Frequencia>> VisualizarRelatorioEstagiarios(int id);

    }
}
