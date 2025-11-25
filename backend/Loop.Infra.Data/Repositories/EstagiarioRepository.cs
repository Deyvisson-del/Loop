using Loop.Domain.Entities;
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

        public async Task<Frequencia?> BaterPonto(Frequencia frequencia)
        {
            await _context.Frequencias.AddAsync(frequencia);
            await _context.SaveChangesAsync();
            return frequencia;
        }

        public async Task SolicitarAjusteCargaHoraria(int estagiarioId, string justificativa, TimeSpan novaHoraEntrada, TimeSpan novaHoraSaida)
        {
   
                var solicitacao = new Solicitacao
                {
                    EstagiarioId = estagiarioId,
                    Justificativa = justificativa,
                    NovaEntrada = novaHoraEntrada,
                    NovaSaida =
                    DataSolicitacao = DateTime.UtcNow,
                    Status = "Pendente"
                };
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