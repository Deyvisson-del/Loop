using Loop.Domain.Entities;
using Loop.Domain.Interfaces;
using Loop.Infra.Data.Context;

namespace Loop.Infra.Data.Repositories
{
    public class GestorRepository : IGestorRepository
    {
        private readonly LoopDbContext _context;

        public GestorRepository(LoopDbContext context)
        {
            _context = context;
        }

        public Task AdicionarGestorAsync(Gestor gestor)
        {
            throw new NotImplementedException();
        }

        public Task AtualizarGestorAsync(Gestor gestor)
        {
            throw new NotImplementedException();
        }

        public Task<Gestor?> ObterGestorPorEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Gestor?> ObterGestorPorIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Gestor>> ObterTodosAsync()
        {
            throw new NotImplementedException();
        }

        public Task RemoverGestorAsync(Gestor gestor)
        {
            throw new NotImplementedException();
        }
    }
}
