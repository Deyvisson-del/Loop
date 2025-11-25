using Loop.Domain.Entities;
using Loop.Domain.Interfaces;
using Loop.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Loop.Infra.Data.Repositories
{
    public class GestorRepository : IGestorRepository
    {
        private readonly LoopDbContext _context;

        public GestorRepository(LoopDbContext context)
        {
            _context = context;
        }

        public Task AtualizarEstagiarioAsync(Estagiario estagiario)
        {
            throw new NotImplementedException();
        }

        public Task CriarEstagiarioAsync(Estagiario estagiario)
        {
            throw new NotImplementedException();
        }

        public Task<Estagiario?> ObterEstagiarioPorEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Estagiario?> ObterEstagiarioPorIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Estagiario>> ObterTodosEstagiariosAsync()
        {
            throw new NotImplementedException();
        }

        public Task RemoverEstagiarioAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Frequencia>> VisualizarRelatorioEstagiarios(int id)
        {
            throw new NotImplementedException();
        }
    }
}
