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
        public async Task CriarGestorAsync(Gestor gestor)
        {
            await _context.Gestores.AddAsync(gestor);
            await _context.SaveChangesAsync();
        }
        public async Task AtualizarGestorAsync(Gestor gestor)
        {
            _context.Gestores.Update(gestor);
            await _context.SaveChangesAsync();
        }
        public async Task<Gestor?> ObterGestorPorEmailAsync(string email)
        {
            return await _context.Gestores.FirstOrDefaultAsync(e => e.Email == email) ?? 
                throw new InvalidOperationException("Gestores não encontrado");
        }
        public async Task<Gestor?> ObterGestorPorIdAsync(int Id)
        {
            return await _context.Gestores.FirstOrDefaultAsync(e => e.Id == Id) ??
                throw new InvalidOperationException("Gestor não encontrado");
        }
        public async Task<IEnumerable<Gestor>> ObterTodosGestoresAsync()
        {
            return await _context.Gestores.ToListAsync() ??
                throw new InvalidOperationException("Gestores não encontrados");
        }
        public async Task RemoverGestorAsync(Gestor gestor)
        {
            _context.Gestores.Remove(gestor);
            await _context.SaveChangesAsync();
        }
    }
}
