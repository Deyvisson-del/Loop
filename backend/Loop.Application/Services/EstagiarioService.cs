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
        private readonly IMapper _mapper;


        public EstagiarioService(IEstagiarioRepository estagiarioRepository, IMapper mapper)
        {
            _estagiarioRepository = estagiarioRepository;
            _mapper = mapper;
        }

        public Task<Frequencia?> BaterPonto(Frequencia frequencia)
        {

        }

        public Task<EstagiarioDTO?> ObterPorEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<FrequenciaDTO> RagistrarPonto(FrequenciaDTO frequenciaDTO)
        {
            throw new NotImplementedException();
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
