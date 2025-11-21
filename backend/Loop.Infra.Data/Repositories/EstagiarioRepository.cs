using Loop.Domain.Entities;
using Loop.Domain.Interfaces;
using Loop.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Loop.Infra.Data.Repositories
{
    public class EstagiarioRepository : IEstagiarioRepository
    {
        private readonly LoopDbContext _context;

        public EstagiarioRepository(LoopDbContext context)
        {
            _context = context;
        }
        public async Task AdicionarAsync(Estagiario estagiario)
        {
            await _context.Estagiarios.AddAsync(estagiario);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(int id,Estagiario estagiario)
        {
            var IdExiste = await _context.Estagiarios.AnyAsync(e => e.Id == id);
            
            if (!IdExiste)
                throw new KeyNotFoundException("Estagiario não encontrado.");

            id = estagiario.Id;
            _context.Estagiarios.Update(estagiario);
            await _context.SaveChangesAsync();
        }

        public async Task<Estagiario?> ObterPorEmailAsync(string email)
        {
            return await _context.Estagiarios
              .AsNoTracking()
              .FirstOrDefaultAsync(e => e.Email.ToLower() == email.ToLower());
        }

        public async Task<Estagiario?> ObterPorIdAsync(int id)
        {
            return await _context.Estagiarios.FindAsync(id);
        }

        public async Task<IEnumerable<Estagiario>> ObterTodosAsync()
        {
            return await _context.Estagiarios
                           .AsNoTracking()
                           .ToListAsync();
        }

        public async Task RemoverAsync(int id)
        {
            var estagiario = await _context.Estagiarios.FindAsync(id);
            if (estagiario != null)
            {
                _context.Estagiarios.Remove(estagiario);
                await _context.SaveChangesAsync();
            }
        }
    }
}
