using Loop.Domain.Entities;

namespace Loop.Domain.Interfaces
{
    /// <summary>
    /// Define o contrato para operações de persistência e recuperação de dados da entidade <see cref="Gestor"/>.
    /// </summary>
    /// <remarks>
    /// Esta interface segue o padrão <b>Repository</b>, permitindo que a camada de domínio
    /// trabalhe de forma independente da infraestrutura de dados.  
    /// <br/><br/>
    /// Implementações típicas residem na camada <c>Infra.Data</c> e utilizam
    /// o <b>Entity Framework Core</b> ou outro mecanismo de acesso a dados.
    /// </remarks>
    public interface IGestorRepository
    {
        /// <summary>
        /// Obtém um gestor específico a partir do seu identificador único.
        /// </summary>
        /// <param name="Id">Identificador único (<see cref="Guid"/>) do gestor.</param>
        /// <returns>
        /// Uma instância de <see cref="Gestor"/> correspondente ao identificador informado,
        /// ou <c>null</c> se não for encontrada.
        /// </returns>
        Task<Gestor?> ObterGestorPorIdAsync(Guid Id);

        /// <summary>
        /// Retorna todos os gestores cadastrados no sistema.
        /// </summary>
        /// <returns>
        /// Uma coleção enumerável contendo todas as instâncias de <see cref="Gestor"/> persistidas.
        /// </returns>
        Task<IEnumerable<Gestor>> ObterTodosAsync();

        /// <summary>
        /// Adiciona um novo gestor ao repositório.
        /// </summary>
        /// <param name="gestor">Instância de <see cref="Gestor"/> a ser adicionada.</param>
        /// <returns>Uma tarefa representando a operação assíncrona.</returns>
        /// <exception cref="ArgumentNullException">
        /// Lançada quando o parâmetro <paramref name="gestor"/> é nulo.
        /// </exception>
        Task AdicionarGestorAsync(Gestor gestor);

        /// <summary>
        /// Atualiza os dados de um gestor existente no repositório.
        /// </summary>
        /// <param name="gestor">Instância de <see cref="Gestor"/> com os dados atualizados.</param>
        /// <returns>Uma tarefa representando a operação assíncrona.</returns>
        /// <exception cref="ArgumentNullException">
        /// Lançada quando o parâmetro <paramref name="gestor"/> é nulo.
        /// </exception>
        Task AtualizarGestorAsync(Gestor gestor);

        /// <summary>
        /// Remove um gestor do repositório.
        /// </summary>
        /// <param name="gestor">Instância de <see cref="Gestor"/> a ser removida.</param>
        /// <returns>Uma tarefa representando a operação assíncrona.</returns>
        /// <exception cref="ArgumentNullException">
        /// Lançada quando o parâmetro <paramref name="gestor"/> é nulo.
        /// </exception>
        Task RemoverGestorAsync(Gestor gestor);

        /// <summary>
        /// Obtém um gestor a partir do endereço de e-mail.
        /// </summary>
        /// <param name="email">Endereço de e-mail do gestor.</param>
        /// <returns>
        /// Uma instância de <see cref="Gestor"/> correspondente ao e-mail informado,
        /// ou <c>null</c> se não for encontrada.
        /// </returns>
        Task<Gestor?> ObterGestorPorEmailAsync(string email);
    }
}
