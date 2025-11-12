namespace Loop.Application.Interfaces
{
    /// <summary>
    /// Define um contrato genérico para os serviços de aplicação responsáveis
    /// por operações básicas de manipulação de dados (<c>CRUD</c>).
    /// </summary>
    /// <typeparam name="T">
    /// Tipo de objeto (geralmente um <c>DTO</c>) que o serviço manipula.
    /// Deve ser uma classe.
    /// </typeparam>
    /// <remarks>
    /// Esta interface representa a base para todos os serviços da camada <b>Application</b>, 
    /// encapsulando a comunicação entre a camada de apresentação (UI/API) e o domínio.
    /// 
    /// <para>
    /// Cada implementação deve realizar validações de regras de negócio e conversões 
    /// necessárias (por exemplo, entre <c>DTOs</c> e entidades de domínio).
    /// </para>
    /// </remarks>
    public interface IBaseService<T> where T : class
    {
        /// <summary>
        /// Obtém todos os registros do tipo especificado.
        /// </summary>
        /// <returns>
        /// Uma coleção de objetos do tipo <typeparamref name="T"/>.
        /// </returns>
        /// <example>
        /// <code>
        /// var estagiarios = await _estagiarioService.ObterTodosAsync();
        /// </code>
        /// </example>
        Task<IEnumerable<T>> ObterTodosAsync();

        /// <summary>
        /// Obtém um registro específico com base em seu identificador único.
        /// </summary>
        /// <param name="id">Identificador único do objeto.</param>
        /// <returns>
        /// O objeto correspondente ao <paramref name="id"/>, 
        /// ou <see langword="null"/> caso não seja encontrado.
        /// </returns>
        /// <example>
        /// <code>
        /// var estagiario = await _estagiarioService.ObterPorIdAsync(estagiarioId);
        /// </code>
        /// </example>
        Task<T?> ObterPorIdAsync(Guid id);

        /// <summary>
        /// Adiciona um novo registro do tipo especificado.
        /// </summary>
        /// <param name="dto">Objeto contendo os dados a serem inseridos.</param>
        /// <remarks>
        /// Implementações devem validar o modelo e aplicar regras de negócio
        /// antes de delegar a persistência à camada de infraestrutura.
        /// </remarks>
        /// <example>
        /// <code>
        /// await _estagiarioService.AdicionarAsync(novoEstagiarioDto);
        /// </code>
        /// </example>
        Task AdicionarAsync(T dto);

        /// <summary>
        /// Atualiza os dados de um registro existente.
        /// </summary>
        /// <param name="dto">Objeto contendo os dados atualizados.</param>
        /// <remarks>
        /// É esperado que o objeto contenha o identificador da entidade a ser atualizada.
        /// </remarks>
        /// <example>
        /// <code>
        /// await _estagiarioService.AtualizarAsync(estagiarioAtualizadoDto);
        /// </code>
        /// </example>
        Task AtualizarAsync(T dto);

        /// <summary>
        /// Remove um registro existente com base em seu identificador único.
        /// </summary>
        /// <param name="id">Identificador único do objeto a ser removido.</param>
        /// <remarks>
        /// Implementações devem garantir a consistência de dados e validar dependências
        /// antes de efetuar a exclusão.
        /// </remarks>
        /// <example>
        /// <code>
        /// await _estagiarioService.RemoverAsync(estagiarioId);
        /// </code>
        /// </example>
        Task RemoverAsync(Guid id);
    }
}
