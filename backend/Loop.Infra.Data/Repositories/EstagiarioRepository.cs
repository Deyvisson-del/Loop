using Loop.Domain.Entities;
using Loop.Domain.Enums;
using Loop.Domain.Interfaces;
using Loop.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace Loop.Infra.Data.Repositories
{
    public class EstagiarioRepository : IEstagiarioRepository
    {
        private readonly LoopDbContext _context;

        public EstagiarioRepository(LoopDbContext context)
        {
            _context = context;
        }

        public async Task<Frequencia?> BaterEntradaAsync(int id)
        {
            var freq = new Frequencia
            {
                EstagiarioId = id,
                Data = DateTime.Now,
                HoraChegada = DateTime.Now.TimeOfDay,

            };

            await _context.Frequencias.AddAsync(freq);
            await _context.SaveChangesAsync();

            return freq;
        }

        public async Task<Frequencia?> BaterSaidaAsync(int id)
        {
            var freq = await _context.Frequencias
            .Where(f => f.EstagiarioId == id && f.HoraSaida == null)
            .OrderByDescending(f => f.Id)
            .FirstOrDefaultAsync();

            if (freq == null)
                throw new InvalidOperationException("Não existe ponto de entrada aberto.");

            freq.HoraSaida = DateTime.Now.TimeOfDay;

            _context.Frequencias.Update(freq);
            await _context.SaveChangesAsync();

            return freq;
        }

        public async Task SolicitarAjusteCargaHoraria(int estagiarioId, string justificativa, TimeSpan horaEntrada,TimeSpan horaSaida)
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

            await  _context.Solicitacoes.AddAsync(solicitacao);
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