using Loop.Domain.Entities;
using Loop.Domain.Enums;
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

        public async Task AtualizarGestorAsync(int gestorId, Gestor gestor)
        {
            bool gestorExiste = await _context.Gestores.AnyAsync(a => a.Id == gestorId);
            if (!gestorExiste)
                throw new ArgumentException("Gestor não existe");

            _context.Gestores.Update(gestor);
            await _context.SaveChangesAsync();

        }

        public async Task<Gestor?> ObterGestorPorEmailAsync(string email)
        {
            return await _context.Gestores.FirstOrDefaultAsync(e => e.Email == email);
        }

        public async Task<Gestor?> ObterGestorPorIdAsync(int Id)
        {
            return await _context.Gestores.FirstOrDefaultAsync(e => e.Id == Id);
        }

        public async Task<IEnumerable<Gestor>> ObterTodosGestoresAsync()
        {
            return await _context.Gestores.ToListAsync();
        }

        public async Task RemoverGestorAsync(int id)
        {
            var user = await _context.Gestores.FindAsync(id);
            if (user == null)
                throw new ArgumentException("Gestor não encontrado");

            _context.Gestores.Remove(user);
            await _context.SaveChangesAsync();
            
        }

        public async Task<IEnumerable<Frequencia>> GerarRelatorioEstagiariosAsync(int id)
        {
            await _context.Estagiarios.FindAsync(id);
            return await _context.Frequencias
                .Where(f => f.EstagiarioId == id)
                .Include(f => f.Estagiario)
                .ToListAsync();
        }

        public Task AprovarSolicitacaoAsync(int solicitacaoId)
        {
            bool idExiste = _context.Solicitacoes.Any(s => s.Id == solicitacaoId);
            if (!idExiste)
                throw new ArgumentException("Solicitação não existe");

            var solicitacao = _context.Solicitacoes.First(s => s.Id == solicitacaoId);
            solicitacao.Status = StatusSolicitacao.AP;
            _context.Solicitacoes.Update(solicitacao);
            return _context.SaveChangesAsync();
        }

        public Task RejeitarSolicitacaoAsync(int solicitacaoId, string motivoRejeicao)
        {
            bool idExiste = _context.Solicitacoes.Any(s => s.Id == solicitacaoId);
            if (!idExiste)
                throw new ArgumentException("Solicitação não existe");

            var solicitacao = _context.Solicitacoes.First(s => s.Id == solicitacaoId);
            solicitacao.Status = StatusSolicitacao.RP;
            solicitacao.Justificativa = motivoRejeicao;
            _context.Solicitacoes.Update(solicitacao);
            return _context.SaveChangesAsync();
        }


    }
}
