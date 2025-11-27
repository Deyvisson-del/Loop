using Loop.Domain.Entities;
using Loop.Domain.Enums;
using Loop.Domain.Interfaces;
using Loop.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Loop.Infra.Data.Repositories
{
    public class SolicitacaoRepository : ISolicitacaoRepository
    {

        private readonly LoopDbContext _contextSolicitacao;

        public SolicitacaoRepository(LoopDbContext contcontextSolicitacao)
        {
            _contextSolicitacao = contcontextSolicitacao;
        }

        public async Task CriarSolicitacaoAsync(Solicitacao solicitacao)
        {
            await _contextSolicitacao.Solicitacoes.AddAsync(solicitacao);
            await _contextSolicitacao.SaveChangesAsync();
        }

        public async Task AtualizarSolicitacaoAsync(Solicitacao solicitacao)
        {
            _contextSolicitacao.Solicitacoes.Update(solicitacao);
            await _contextSolicitacao.SaveChangesAsync();
        }

        public async Task RemoverSolicitacaoAsync(int id)
        {
            await _contextSolicitacao.Solicitacoes
                .Where(s => s.Id == id)
                .ExecuteDeleteAsync();
        }

        public async Task<Solicitacao?> ObterPorEstagiarioIdAsync(int estagiarioId)
        {
            return await _contextSolicitacao.Solicitacoes.FirstOrDefaultAsync(a => a.EstagiarioId == estagiarioId);
        }

        public async Task<IEnumerable<Solicitacao>> ObterPorPendentesAsync()
        {
            return await _contextSolicitacao.Solicitacoes
                .Where(s => s.Status == StatusSolicitacao.PE)
                .ToListAsync();
        }

        public async Task<Solicitacao?> ObterSolicitacaoPorId(int id)
        {
            return await _contextSolicitacao.Solicitacoes.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Solicitacao?>> ObterTodasSolicidacaoAsync()
        {
            return await _contextSolicitacao.Solicitacoes.ToListAsync();
        }

        public async Task AprovarSolicitacaoAsync(Solicitacao solicitacao)
        {
            _contextSolicitacao.Solicitacoes.Update(solicitacao);
            await _contextSolicitacao.SaveChangesAsync();
        }

        public Task RejeitarSolicitacaoAsync(Solicitacao solicitacao)
        {
            _contextSolicitacao.Solicitacoes.Update(solicitacao);
            return _contextSolicitacao.SaveChangesAsync();
        }
    }
}
