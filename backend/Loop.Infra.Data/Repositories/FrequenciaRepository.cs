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

        public async Task AtualizarFrequenciaAsync(int id,Frequencia frequencia)
        {
            bool idExiste = await _contextFrequencia.Frequencias.AnyAsync(f => f.Id == id);
            if (!idExiste)
                throw new InvalidOperationException("Frequência não encontrada.");

            _contextFrequencia.Frequencias.Update(frequencia);
            await _contextFrequencia.SaveChangesAsync();
        }

        public async Task<Frequencia> BaterEntradaAsync(int id)
        {
            var freq = new Frequencia
            {
                EstagiarioId = id,
                Data = DateTime.Now,
                HoraChegada = DateTime.Now.TimeOfDay,
            };

            await _contextFrequencia.Frequencias.AddAsync(freq);
            await _contextFrequencia.SaveChangesAsync();

            return freq;
        }

        public async Task<Frequencia?> BaterSaidaAsync(int id)
        {
            var freq = await _contextFrequencia.Frequencias
            .Where(f => f.EstagiarioId == id && f.HoraSaida == null)
            .OrderByDescending(f => f.Id)
            .FirstOrDefaultAsync();

            if (freq == null)
                throw new InvalidOperationException("Não existe ponto de entrada aberto.");

            freq.HoraSaida = DateTime.Now.TimeOfDay;

            _contextFrequencia.Frequencias.Update(freq);
            await _contextFrequencia.SaveChangesAsync();

            return freq;
        }

        public async Task<IEnumerable<Frequencia>> ObterPorEstagiarioIdAsync(int estagiarioId)
        {
            return await _contextFrequencia.Frequencias.OrderBy(f => f.EstagiarioId).ThenBy(f => f.Data).ToListAsync();
        }

        public async Task<Frequencia?> ObterPorIdAsync(int id)
        {
            return await _contextFrequencia.Frequencias.FirstOrDefaultAsync(f => f.Id == id);
        }

    }
}