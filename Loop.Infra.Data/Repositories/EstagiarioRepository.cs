using Loop.Domain.Entities;
using Loop.Domain.Interfaces;
using Loop.Infra.Data.Context;

namespace Loop.Infra.Data.Repositories
{
    public class EstagiarioRepository : IEstagiarioRepository
    {
        private readonly LoopDbContext _context;

        public EstagiarioRepository(LoopDbContext context)
        {
            _context = context;
        }
        public Task AdicionarAsync(Estagiario estagiario)
        {
            throw new NotImplementedException();
        }

        public Task AtualizarAsync(Estagiario estagiario)
        {
            throw new NotImplementedException();
        }

        public Task<Estagiario?> ObterPorEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Estagiario?> ObterPorIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Estagiario>> ObterTodosAsync()
        {
            throw new NotImplementedException();
        }

        public Task RemoverAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
