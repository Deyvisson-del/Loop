using Loop.Domain.Interfaces;
using Loop.Domain.Requests;
using Loop.Infra.Data.Context;

namespace Loop.Infra.Data.Repository
{
    public class FrequenciaRepository : IFrequenciaRepository
    {
        private readonly Contexto _contexto;

        public FrequenciaRepository(Contexto contexto)
        {
            _contexto = contexto;
        }

        public void Adicionar(Frequencia frequencia)
        {
            _contexto.Frequencias.Add(frequencia);
            _contexto.SaveChanges();
        }

        public void Atualizar(Frequencia frequencia)
        {
            _contexto.Frequencias.Update(frequencia);
            _contexto.SaveChanges();
        }

        public Frequencia? ConsultaId(int frequenciaId)
        {
            return _contexto.Frequencias.Find(frequenciaId);
        }

        public IEnumerable<Frequencia?> Listar()
        {
           return _contexto.Frequencias.ToList();
        }

        public Frequencia? ObterPorEstagiarioEData(int estagiarioId, DateTime data)
        {
            return _contexto.Frequencias.FirstOrDefault(f => f.EstagiarioId == estagiarioId && f.Data == data.Date);
        }


    }
}