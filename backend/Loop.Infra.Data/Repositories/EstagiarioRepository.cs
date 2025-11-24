using Loop.Domain.Entities;
using Loop.Domain.Interfaces;
using Loop.Infra.Data.Context;

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
            _context.Frequencias.Add(frequencia);  
            await _context.SaveChangesAsync();
            return frequencia;
        }

        public Task SolicitarAjusteCargaHoraria(int estagiarioId, string justificativa, TimeOnly horaCorrigida)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Frequencia?>> VisualizarRelatorio()
        {
            throw new NotImplementedException();
        }
    }

}