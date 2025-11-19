using MapsterMapper;
using Loop.Application.DTOs;
using Loop.Application.Interfaces;
using Loop.Domain.Entities;
using Loop.Domain.Interfaces;

namespace Loop.Application.Services
{
    /// <summary>
    /// Serviço responsável por gerenciar as operações de aplicação relacionadas à entidade <see cref="Frequencia"/>.
    /// </summary>
    /// <remarks>
    /// A classe <see cref="FrequenciaService"/> atua como intermediária entre as camadas de aplicação e domínio, 
    /// aplicando o padrão <b>Service Layer</b>.  
    /// Ela realiza a conversão entre objetos de transferência de dados (<see cref="FrequenciaDTO"/>) 
    /// e entidades de domínio (<see cref="Frequencia"/>), delegando a persistência ao 
    /// repositório <see cref="IFrequenciaRepository"/>.
    /// </remarks>
    public class FrequenciaService : IFrequenciaService
    {
        private readonly IFrequenciaRepository _frequenciaRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Inicializa uma nova instância do serviço de frequência.
        /// </summary>
        /// <param name="frequenciaRepository">
        /// Repositório responsável pelo acesso e manipulação dos dados de <see cref="Frequencia"/>.
        /// </param>
        /// <param name="mapper">
        /// Componente responsável pela conversão entre entidades de domínio e DTOs.
        /// </param>
        public FrequenciaService(IFrequenciaRepository frequenciaRepository, IMapper mapper)
        {
            _frequenciaRepository = frequenciaRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Obtém todas as frequências cadastradas no sistema.
        /// </summary>
        /// <returns>
        /// Uma coleção de objetos <see cref="FrequenciaDTO"/> representando as frequências registradas.
        /// </returns>
        /// <example>
        /// <code>
        /// var todas = await _frequenciaService.ObterTodosAsync();
        /// foreach (var freq in todas)
        ///     Console.WriteLine(freq.Data);
        /// </code>
        /// </example>
        public async Task<IEnumerable<FrequenciaDTO>> ObterTodosAsync()
        {
            var entidades = await _frequenciaRepository.ObterTodosAsync();
            return _mapper.Map<IEnumerable<FrequenciaDTO>>(entidades);
        }

        /// <summary>
        /// Obtém todas as frequências associadas a um estagiário específico.
        /// </summary>
        /// <param name="estagiarioId">Identificador único do estagiário.</param>
        /// <returns>
        /// Uma coleção de objetos <see cref="FrequenciaDTO"/> pertencentes ao estagiário informado.
        /// </returns>
        /// <example>
        /// <code>
        /// var frequencias = await _frequenciaService.ObterPorEstagiarioAsync(estagiarioId);
        /// </code>
        /// </example>
        public Task<IEnumerable<FrequenciaDTO>> ObterPorEstagiarioAsync(int estagiarioId)
        {
            var entidades = _frequenciaRepository.ObterPorEstagiarioAsync(estagiarioId);
            return _mapper.Map<Task<IEnumerable<FrequenciaDTO>>>(entidades);
        }

        /// <summary>
        /// Obtém uma frequência específica pelo seu identificador.
        /// </summary>
        /// <param name="id">Identificador único da frequência.</param>
        /// <returns>
        /// Um objeto <see cref="FrequenciaDTO"/> correspondente ao registro encontrado, 
        /// ou <see langword="null"/> caso não exista.
        /// </returns>
        /// <example>
        /// <code>
        /// var frequencia = await _frequenciaService.ObterPorIdAsync(frequenciaId);
        /// if (frequencia != null)
        ///     Console.WriteLine(frequencia.HorasTrabalhadas);
        /// </code>
        /// </example>
        public Task<FrequenciaDTO?> ObterPorIdAsync(int id)
        {
            var entidade = _frequenciaRepository.ObterPorIdAsync(id);
            return _mapper.Map<Task<FrequenciaDTO?>>(entidade);
        }

        /// <summary>
        /// Adiciona uma nova frequência no sistema.
        /// </summary>
        /// <param name="dto">Objeto de transferência de dados contendo as informações da nova frequência.</param>
        /// <remarks>
        /// O DTO é convertido para uma entidade de domínio antes de ser persistido.
        /// </remarks>
        /// <example>
        /// <code>
        /// var dto = new FrequenciaDTO { EstagiarioId = estagiarioId, Data = DateTime.UtcNow };
        /// await _frequenciaService.AdicionarAsync(dto);
        /// </code>
        /// </example>
        public async Task<FrequenciaDTO> AdicionarAsync(FrequenciaDTO dto)
        {
            var entidade = _mapper.Map<Frequencia>(dto);
            await _frequenciaRepository.AdicionarAsync(entidade);
            return _mapper.Map<FrequenciaDTO>(entidade);
        }

        /// <summary>
        /// Atualiza uma frequência existente no sistema.
        /// </summary>
        /// <param name="dto">Objeto <see cref="FrequenciaDTO"/> com os novos dados a serem aplicados.</param>
        /// <example>
        /// <code>
        /// dto.HorasTrabalhadas = 8.5;
        /// await _frequenciaService.AtualizarAsync(dto);
        /// </code>
        /// </example>
        public async Task AtualizarAsync(FrequenciaDTO dto)
        {
            var entidade = _mapper.Map<Frequencia>(dto);
            await _frequenciaRepository.AtualizarAsync(entidade);
        }

        /// <summary>
        /// Remove uma frequência existente do sistema.
        /// </summary>
        /// <param name="id">Identificador único da frequência a ser removida.</param>
        /// <example>
        /// <code>
        /// await _frequenciaService.RemoverAsync(frequenciaId);
        /// </code>
        /// </example>
        public async Task RemoverAsync(int id)
        {
            await _frequenciaRepository.RemoverAsync(id);
        }

        public Task<FrequenciaDTO> AtualizarIdAsync(FrequenciaDTO dto, int id)
        {
            throw new NotImplementedException();
        }
    }
}
