using Loop.Domain.Entities;

namespace Loop.Domain.Interfaces
{
    public interface IFrequenciaRepository
    {
        Task BaterEntradaAsync(Frequencia frequencia);
        Task BaterSaidaAsync(Frequencia frequencia);
        Task<Frequencia> ObterFrequenciaPorIdAsync(int id);
        Task AtualizarFrequenciaAsync(Frequencia frequencia);
        Task RemoverFrequenciaAsync(Frequencia frequencia);
        Task<Frequencia> ObterFrequenciaPorDataAsync(DateTime data);
        Task<IEnumerable<Frequencia>> ObterPorEstagiarioIdAsync(int estagiarioId);
        
        Task <IEnumerable<Frequencia>> ObterTodasFrequenciasAsync();
    
        Task<IEnumerable<Frequencia>> GerarRelatorioAsync(int estagiarioId);
    }
}
