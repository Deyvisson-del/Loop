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

        public async Task CriarEstagiarioAsync(Estagiario estagiario)
        {
            await _context.Estagiarios.AddAsync(estagiario);
            await _context.SaveChangesAsync();
        }
        public async Task AtualizarEstagiarioAsync(Estagiario estagiario)
        {
            _context.Estagiarios.Update(estagiario);
            await _context.SaveChangesAsync();
        }
        public async Task RemoverEstagiarioAsync(Estagiario estagiario)
        {
            _context.Estagiarios.Remove(estagiario);
            await _context.SaveChangesAsync();
        }

        public async Task<Estagiario> ObterEstagiarioPorEmailAsync(string email)
        {
            return await _context.Estagiarios.FirstOrDefaultAsync(e => e.Email == email) ??
                throw new InvalidOperationException("Estagiário não encontrado");
        }
        public async Task<Estagiario> ObterEstagiarioPorIdAsync(int Id)
        {
            return await _context.Estagiarios.FirstOrDefaultAsync(e => e.Id == Id) ??
                throw new InvalidOperationException("Estagiario não encontrado");
        }
        public async Task<IEnumerable<Estagiario>> ObterTodosEstagiariosAsync()
        {
            return await _context.Estagiarios.ToListAsync() ??
                throw new InvalidOperationException("Estagiario não encontrado");
        }
    }
}