using MapsterMapper;
using Loop.Application.DTOs;
using Loop.Application.Interfaces;
using Loop.Domain.Entities;
using Loop.Domain.Interfaces;

namespace Loop.Application.Services
{
    /// <summary>
    /// Serviço responsável por gerenciar as operações de estagiários.
    /// Implementa os métodos definidos na interface <see cref="IBaseService{T}"/>.
    /// </summary>
    public class EstagiarioService : IEstagiarioService
    {
        private readonly IEstagiarioRepository _estagiarioRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Inicializa uma nova instância de <see cref="EstagiarioService"/>.
        /// </summary>
        /// <param name="estagiarioRepository">Repositório responsável pelas operações de dados do estagiário.</param>
        /// <param name="mapper">Instância do mapeador para conversão entre entidades e DTOs.</param>
        public EstagiarioService(IEstagiarioRepository estagiarioRepository, IMapper mapper)
        {
            _estagiarioRepository = estagiarioRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Adiciona um novo estagiário ao sistema.
        /// </summary>
        /// <param name="dto">Objeto DTO contendo os dados do estagiário a ser adicionado.</param>
        public async Task<EstagiarioDTO> AdicionarAsync(EstagiarioDTO dto)
        {
            var estagiarioExistente = _estagiarioRepository.ObterPorEmailAsync(dto.Email);
            if (estagiarioExistente.Result != null)
            {
                throw new InvalidOperationException("Já existe um estagiário cadastrado com este email");
            }
            var estagiarioNovo = new Estagiario(dto.Nome, dto.Email, dto.Senha);

            await _estagiarioRepository.AdicionarAsync(estagiarioNovo);

            return _mapper.Map<EstagiarioDTO>(estagiarioNovo);

        }

        /// <summary>
        /// Atualiza os dados de um estagiário existente.m
        /// </summary>
        /// <param name="dto">Objeto DTO contendo os novos dados do estagiário.</param>
        public Task AtualizarAsync(int id, EstagiarioDTO dto)
        {
            var estagiarioExistente = _estagiarioRepository.ObterPorIdAsync(id);

            if (id != estagiarioExistente.Id)
            {
                throw new ArgumentException("O ID fornecido não corresponde ao ID do estagiário.");
            }

            var estagiario = _mapper.Map<Estagiario>(dto);
            return _estagiarioRepository.AtualizarAsync(id, estagiario);
        }

        public Task<EstagiarioDTO?> ObterPorEmailAsync(string email)
        {
            var estagiario = _estagiarioRepository.ObterPorEmailAsync(email);
            return estagiario.ContinueWith(task =>
                task.Result == null ? null : _mapper.Map<EstagiarioDTO>(task.Result));
        }

        /// <summary>
        /// Obtém um estagiário pelo identificador único.
        /// </summary>
        /// <param name="id">Identificador único do estagiário.</param>
        /// <returns>O DTO do estagiário correspondente, ou <c>null</c> se não encontrado.</returns>
        public async Task<EstagiarioDTO?> ObterPorIdAsync(int id)
        {
            var estagiario = await _estagiarioRepository.ObterPorIdAsync(id);
            if (estagiario == null)
                return null;
            return _mapper.Map<EstagiarioDTO>(estagiario);
        }

        /// <summary>
        /// Obtém todos os estagiários cadastrados.
        /// </summary>
        /// <returns>Uma coleção enumerável contendo os DTOs dos estagiários.</returns>
        public async Task<IEnumerable<EstagiarioDTO>> ObterTodosAsync()
        {
            var estagiarios = await _estagiarioRepository.ObterTodosAsync();
            return _mapper.Map<IEnumerable<EstagiarioDTO>>(estagiarios);
        }

        public Task<FrequenciaDTO> RagistrarPonto(FrequenciaDTO frequenciaDTO)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Remove um estagiário do sistema com base no identificador informado.
        /// </summary>
        /// <param name="id">Identificador único do estagiário a ser removido.</param>
        public async Task RemoverAsync(int id)
        {
            await _estagiarioRepository.RemoverAsync(id);
        }
    }
}
