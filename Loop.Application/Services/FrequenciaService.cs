using Loop.Domain.Interfaces;
using Loop.Domain.Requests;
namespace Loop.Application.Services
{
    public class FrequenciaService
    {
        private readonly IFrequenciaRepository _frequenciaRepository;
        public FrequenciaService(IFrequenciaRepository frequenciaRepository)
        {
            _frequenciaRepository = frequenciaRepository;
        }
        public Frequencia RegistrarEntrada(int estagiarioId, DateTime entrada)
        {
            var data = entrada.Date;
            var frequencia = _frequenciaRepository.ObterPorEstagiarioEData(estagiarioId, data);
            if (frequencia == null)
            {
                frequencia = new Frequencia(estagiarioId, data);
                _frequenciaRepository.Adicionar(frequencia);
            }
            frequencia.RegistrarEntrada(entrada);
            _frequenciaRepository.Atualizar(frequencia);
            return frequencia;
        }
        public Frequencia RegistrarSaida(int estagiarioId, DateTime saida)
        {
            var data = saida.Date;
            var frequencia = _frequenciaRepository.ObterPorEstagiarioEData(estagiarioId, data);
            if (frequencia == null) throw new InvalidOperationException("Não existe frequência para hoje. Registre a entrada primeiro.");
            frequencia.RegistrarSaida(saida);
            _frequenciaRepository.Atualizar(frequencia);
            return frequencia;
        }
        public Frequencia AjustarPonto(int estagiarioId, DateTime data, TimeSpan novaEntrada, TimeSpan novaSaida)
        {
            var frequencia = _frequenciaRepository.ObterPorEstagiarioEData(estagiarioId, data);
            if (frequencia == null) throw new InvalidOperationException("Frequência não encontrada.");
            frequencia.AjustarPonto(novaEntrada, novaSaida);
            _frequenciaRepository.Atualizar(frequencia);
            return frequencia;
        }
    }
}