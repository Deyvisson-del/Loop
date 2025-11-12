using Loop.Domain.Entities;
using Loop.Domain.Interfaces;
using Loop.Infra.Data.Context;
using Microsoft.EntityFrameworkCore; // Adicione este using

namespace Loop.Infra.Data.Repositories
{
    public class FrequenciaRepository : IFrequenciaRepository
    {
        private readonly LoopDbContext _context;

        public FrequenciaRepository(LoopDbContext context)
        {
            _context = context;
        }

        public async Task AdicionarAsync(Frequencia frequencia)
        {
            await _context.Set<Frequencia>().AddAsync(frequencia);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Frequencia frequencia)
        {
            _context.Set<Frequencia>().Update(frequencia);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Frequencia>> ObterPorEstagiarioAsync(Guid estagiarioId)
        {
            return await _context.Set<Frequencia>()
                .Where(f => f.EstagiarioId == estagiarioId)
                .ToListAsync();
        }

        public async Task<Frequencia?> ObterPorIdAsync(Guid id)
        {
            return await _context.Frequencias.FindAsync(id);
        }

        public Task<IEnumerable<Frequencia>> ObterTodosAsync()
        {
            throw new NotImplementedException();
        }

        public async Task RemoverAsync(Guid id)
        {
            var frequencia = _context.Frequencias.Find(id);
            if (frequencia != null)
            {
                _context.Frequencias.Remove(frequencia);
                await _context.SaveChangesAsync();
            }
        }
    }
}
