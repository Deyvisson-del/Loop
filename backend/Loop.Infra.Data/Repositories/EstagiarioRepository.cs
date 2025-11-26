using Loop.Domain.Entities;
using Loop.Domain.Enums;
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

        public async Task AtualizarEstagiario(int id, Estagiario estagiario)
        {
            bool estagiarioExiste = await _context.Estagiarios.AnyAsync(a => a.Id == id);
            if (!estagiarioExiste)
                throw new ArgumentException("Estagiario não existe");

            _context.Estagiarios.Update(estagiario);
            await _context.SaveChangesAsync();
        }

        public async Task CriarEstagiarioAsync(Estagiario estagiario)
        {
            await _context.Estagiarios.AddAsync(estagiario);
            await _context.SaveChangesAsync();
        }

        public async Task<Estagiario?> ObterEstagiarioPorEmailAsync(string email)
        {
            return await _context.Estagiarios.FirstOrDefaultAsync(e => e.Email == email);
        }

        public async Task<Estagiario?> ObterEstagiarioPorIdAsync(int Id)
        {
            return await _context.Estagiarios.FirstOrDefaultAsync(e => e.Id == Id);
        }

        public async Task<IEnumerable<Estagiario>> ObterTodosEstagiariosAsync()
        {
            return await _context.Estagiarios.ToListAsync();
        }

        public async Task RemoverEstagiarioAsync(int id)
        {
            var estagiarioExiste = await _context.Estagiarios.FindAsync(id);

            if (estagiarioExiste == null)
                throw new ArgumentException("Estagiario não existe");

            _context.Estagiarios.Remove(estagiarioExiste);
                await _context.SaveChangesAsync();
        }

        public async Task SolicitarAjusteCargaHoraria(int estagiarioId, string justificativa, TimeSpan horaEntrada, TimeSpan horaSaida)
        {
            var solicitacao = new Solicitacao
            {
                EstagiarioId = estagiarioId,
                Justificativa = justificativa,
                HorarioEntrada = horaEntrada,
                HorarioSaida = horaSaida,
                DataSolicitacao = DateTime.UtcNow,
                Status = StatusSolicitacao.PE
            };

            await _context.Solicitacoes.AddAsync(solicitacao);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<Frequencia?>> VisualizarRelatorio(int estagiarioId)
        {
            return await _context.Frequencias
                .Where(f => f.EstagiarioId == estagiarioId)
                .OrderByDescending(f => f.Data)
                .AsNoTracking()
                .ToListAsync();
        }
    }

}