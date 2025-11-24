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

        public async Task AtualizarEstagiarioAsync(Estagiario estagiario)
        {
            _context.Estagiarios.Update(estagiario);
            await _context.SaveChangesAsync();
        }

        public async Task CriarEstagiarioAsync(Estagiario estagiario)
        {
            _context.Estagiarios.Add(estagiario);
            await _context.SaveChangesAsync();
        }

        public async Task<Estagiario?> ObterEstagiarioPorEmailAsync(string email)
        {
            var estagiario = _context.Estagiarios.FindAsync(email);
            if (estagiario == null) return (null);

            return await estagiario;

        }

        public async Task<Estagiario?> ObterEstagiarioPorIdAsync(int id)
        {
            var estagiario = _context.Estagiarios.FindAsync(id);
            if (estagiario == null) return null;

            return await _context.Estagiarios.FindAsync(id);

        }

        public async Task<IEnumerable<Estagiario>> ObterTodosEstagiariosAsync()
        {
            return await _context.Estagiarios
                .Include(e => e.Frequencias)
                .ToListAsync();
        }

        public async Task RemoverEstagiarioAsync(int id)
        {
            var estagiario = _context.Estagiarios.FindAsync(id);
            if (estagiario == null) return;

            _context.Estagiarios.Remove(estagiario.Result);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Frequencia>> VisualizarRelatorioEstagiarios(int id)
        {
            return await _context.Frequencias.Where(f => f.EstagiarioId == id).ToListAsync();
        }
    }
}
