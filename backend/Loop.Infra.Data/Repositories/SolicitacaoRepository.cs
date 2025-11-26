using Loop.Domain.Entities;
using Loop.Domain.Enums;
using Loop.Domain.Interfaces;
using Loop.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Loop.Infra.Data.Repositories
{
    public class SolicitacaoRepository : ISolicitacaoRepository
    {

        private readonly LoopDbContext _context;

        public SolicitacaoRepository(LoopDbContext context)
        {
            _context = context;
        }

        public async Task AtualizarAsync(Solicitacao solicitacao)
        {
             _context.Solicitacoes.Update(solicitacao);
            await _context.SaveChangesAsync();
        }

        public async Task<Solicitacao?> ObterPorEstagiarioIdAsync(int estagiarioId)
        {
            return await _context.Solicitacoes.FirstOrDefaultAsync(a => a.EstagiarioId == estagiarioId);
        }

        public async Task<IEnumerable<Solicitacao>> ObterPorPendentesAsync()
        {
            return await _context.Solicitacoes
                .Where(s => s.Status == StatusSolicitacao.PE)
                .ToListAsync();
        }

        public async Task<Solicitacao?> ObterSolicitacaoPorId(int id)
        {
            return await _context.Solicitacoes.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Solicitacao?>> ObterTodasSolicidacaoAsync()
        {
            return await _context.Solicitacoes.ToListAsync();
        }
    }
}
