using MapsterMapper;
using Loop.Application.DTOs;
using Loop.Application.Interfaces;
using Loop.Domain.Entities;
using Loop.Domain.Interfaces;

namespace Loop.Application.Services
{
    public class EstagiarioService : IBaseService<EstagiarioDTO>
    {
        private readonly IEstagiarioRepository _estagiarioRepository;
        private readonly IMapper _mapper;
        public EstagiarioService(IEstagiarioRepository estagiarioRepository, IMapper mapper)
        {
            _estagiarioRepository = estagiarioRepository;
            _mapper = mapper;
        }
        public Task AdicionarAsync(EstagiarioDTO dto)
        {
            var estagiario = _mapper.Map<Estagiario>(dto);
            return _estagiarioRepository.AdicionarAsync(estagiario);

        }

        public Task AtualizarAsync(EstagiarioDTO dto)
        {
            var estagiario = _mapper.Map<Estagiario>(dto);
            return _estagiarioRepository.AtualizarAsync(estagiario);
        }

        public Task<EstagiarioDTO?> ObterPorIdAsync(Guid id)
        {
            var estagiario = _estagiarioRepository.ObterPorIdAsync(id);
            return _mapper.Map<Task<EstagiarioDTO?>>(estagiario);
        }

        public Task<IEnumerable<EstagiarioDTO>> ObterTodosAsync()
        {
            var estagiarios = _estagiarioRepository.ObterTodosAsync();
            return _mapper.Map<Task<IEnumerable<EstagiarioDTO>>>(estagiarios);
        }

        public async Task RemoverAsync(Guid id)
        {
            await _estagiarioRepository.RemoverAsync(id);

        }
    }
}
