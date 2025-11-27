using Loop.Domain.Entities;
using Loop.Domain.Interfaces;
using Loop.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Loop.Infra.Data.Repositories
{
    public class FrequenciaRepository : IFrequenciaRepository
    {

        private readonly LoopDbContext _contextFrequencia;

        public FrequenciaRepository(LoopDbContext repositoryFrequencia)
        {
            _contextFrequencia = repositoryFrequencia;
        }

        public async Task AtualizarFrequenciaAsync(Frequencia frequencia)
        {
            _contextFrequencia.Frequencias.Update(frequencia);
            await _contextFrequencia.SaveChangesAsync();
        }

        public async Task BaterEntradaAsync(Frequencia frequencia)
        {
            await _contextFrequencia.Frequencias.AddAsync(frequencia);
            await _contextFrequencia.SaveChangesAsync();
        }

        public async Task BaterSaidaAsync(Frequencia frequencia)
        {
            _contextFrequencia.Frequencias.Update(frequencia);
            await _contextFrequencia.SaveChangesAsync();
        }

        public async Task<IEnumerable<Frequencia>> ObterPorEstagiarioIdAsync(int estagiarioId)
        {
            return await _contextFrequencia.Frequencias.OrderBy(f => f.EstagiarioId).ThenBy(f => f.Data).ToListAsync();
        }

        public async Task<Frequencia?> ObterFrequenciaPorIdAsync(int id)
        {
            return await _contextFrequencia.Frequencias.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task RemoverFrequenciaAsync(Frequencia frequencia)
        {
            _contextFrequencia.Frequencias.Remove(frequencia);
            await _contextFrequencia.SaveChangesAsync();
        }

        public async Task<Frequencia> ObterFrequenciaPorDataAsync(DateTime data)
        {
            return await _contextFrequencia.Frequencias.FirstOrDefaultAsync(f => f.Data == data.Date);
        }
    }
}