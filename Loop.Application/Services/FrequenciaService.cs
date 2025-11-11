using AutoMapper;
using Loop.Application.DTOs;
using Loop.Application.Interfaces;
using Loop.Domain.Entities;
using Loop.Domain.Interfaces;

namespace Loop.Application.Services
{
    public class FrequenciaService : IFrequenciaService
    {
        private readonly IFrequenciaRepository _frequenciaRepository;
        private readonly IMapper _mapper;
        public FrequenciaService(IFrequenciaRepository frequenciaRepository, IMapper mapper)
        {
            _frequenciaRepository = frequenciaRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FrequenciaDTO>> ObterTodasAsync()
        {
            var entidades =  await _frequenciaRepository.ObterTodasAsync();
            return _mapper.Map<IEnumerable<FrequenciaDTO>>(entidades);
        }



        public Task<IEnumerable<FrequenciaDTO>> ObterPorEstagiarioAsync(Guid estagiarioId)
        {
            throw new NotImplementedException();
        }

        public Task<FrequenciaDTO?> ObterPorIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }


        public async Task AdicionarAsync(FrequenciaDTO dto)
        {
            var entidade = _mapper.Map<Frequencia>(dto);
            await _frequenciaRepository.AdicionarAsync(entidade);
        }

        public async Task AtualizarAsync(FrequenciaDTO dto)
        {
            var entidade = _mapper.Map<Frequencia>(dto);
            await _frequenciaRepository.AtualizarAsync(entidade);
        }

     
        public async Task RemoverAsync(Guid id)
        {
           await _frequenciaRepository.RemoverAsync(id);
        }
    }
}
