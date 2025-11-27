using MapsterMapper;
using Loop.Application.DTOs;
using Loop.Application.Interfaces;
using Loop.Domain.Entities;
using Loop.Domain.Interfaces;

namespace Loop.Application.Services
{

    public class EstagiarioService : IEstagiarioService
    {
        private readonly IEstagiarioRepository _estagiarioRepository;
        private readonly IFrequenciaRepository _frequenciaRepository;
        private readonly IMapper _mapper;


        public EstagiarioService(IEstagiarioRepository estagiarioRepository, IMapper mapper)
        {
            _estagiarioRepository = estagiarioRepository;
            _mapper = mapper;
        }

        public async Task<Frequencia> BaterEntradaAsync(int estagiarioId)
        {
            return await _frequenciaRepository.BaterEntradaAsync(estagiarioId);
        }

        public async Task<Frequencia> BaterSaidaAsync(int estagiarioId)
        {
            return await _frequenciaRepository.BaterSaidaAsync(estagiarioId);
        }

        public Task SolicitarAjusteDePonto()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Frequencia?>> VisualizarRelatorio(int estagiarioId)
        {
            return await _estagiarioRepository.VisualizarRelatorio(estagiarioId);
        }
    }
}
