using Loop.Domain.Entities;
using Loop.Domain.Interfaces;

namespace Loop.Infra.Data.Repositories
{
    public class FrequenciaRepository : IFrequenciaRepository
    {
        public Task<IEnumerable<Frequencia>> ObterPorEstagiarioIdAsync(int estagiarioId)
        {
            throw new NotImplementedException();
        }

        public Task<Frequencia?> ObterPorIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Frequencia> RegistrarEntradaAsync(Frequencia frequencia)
        {
            throw new NotImplementedException();
        }

        public Task RegistrarSaidaAsync(Frequencia frequencia)
        {
            throw new NotImplementedException();
        }
    }
}
