using MapsterMapper;
using Loop.Application.Interfaces;
using Loop.Domain.Entities;
using Loop.Domain.Interfaces;
using Loop.Domain.Enums;

namespace Loop.Application.Services
{

    public class EstagiarioService : IEstagiarioService
    {
        private readonly IEstagiarioRepository _estagiarioRepository;
        private readonly IFrequenciaRepository _frequenciaRepository;
        private readonly ISolicitacaoRepository _solicitacaoRepository;
        private readonly IGestorRepository _gestorRepository;
        private readonly IMapper _mapper;


        public EstagiarioService(
            IEstagiarioRepository estagiarioRepository, 
            IFrequenciaRepository frequenciaRepository, 
            ISolicitacaoRepository solicitacaoRepository,    
            IGestorRepository gestorRepositor, 
            IMapper mapper)
        {
            _gestorRepository = gestorRepositor;
            _solicitacaoRepository = solicitacaoRepository;
            _frequenciaRepository = frequenciaRepository;
            _estagiarioRepository = estagiarioRepository;
            _mapper = mapper;
        }

        public async Task<Frequencia> BaterEntradaAsync(int estagiarioId)
        {
            var frequencia = new Frequencia
            {
                EstagiarioId = estagiarioId,
                Data = DateTime.Now.Date,
                HoraChegada = DateTime.Now.TimeOfDay
            }; 

            await _frequenciaRepository.BaterEntradaAsync(frequencia);
            return frequencia;
        }

        public async Task<Frequencia> BaterSaidaAsync(int estagiarioId)
        {
            var frequencia = await _frequenciaRepository.ObterFrequenciaPorDataAsync(DateTime.Now.Date);

            if(frequencia == null)
            {
                throw new Exception("Nenhum registro de entrada encontrado para o dia de hoje.");
            } 

            frequencia.HoraSaida = DateTime.Now.TimeOfDay;
            frequencia.HorasTrabalhadas = frequencia.HoraSaida.Value - frequencia.HoraChegada;

             await _frequenciaRepository.BaterSaidaAsync(frequencia);
            return frequencia;
        }

        public async Task SolicitarAjusteDePonto(int estagiarioId, string justificativa, TimeSpan horaEntrada, TimeSpan horaSaida)
        {

            var solicitacao = new Solicitacao
            {
                EstagiarioId = estagiarioId,
                Justificativa = justificativa,
                HorarioEntrada = horaEntrada,
                HorarioSaida = horaSaida,
                Status = StatusSolicitacao.PE,
                DataSolicitacao = DateTime.Now
            };

            await _solicitacaoRepository.CriarSolicitacaoAsync(solicitacao);
        
        }

        public async Task<IEnumerable<Frequencia>> VisualizarRelatorio(int estagiarioId)
        {
            var estagiario = _estagiarioRepository.ObterEstagiarioPorIdAsync(estagiarioId);

            if(estagiario.Id == estagiarioId)
                {
                throw new Exception("Estagiario não encontrado.");
            }

            return await _frequenciaRepository.GerarRelatorioAsync(estagiarioId);

        }
    }
}
