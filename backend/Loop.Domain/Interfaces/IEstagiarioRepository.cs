using Loop.Domain.Entities;

namespace Loop.Domain.Interfaces
{
    /// <summary>
    /// Define o contrato para operações de persistência e consulta
    /// relacionadas à entidade <see cref="Estagiario"/>.
    /// </summary>
    /// <remarks>
    /// Esta interface segue o padrão <b>Repository</b>, promovendo a separação de responsabilidades
    /// entre a camada de domínio e a infraestrutura de dados.  
    /// <br/><br/>
    /// As implementações concretas geralmente são encontradas na camada <c>Infra.Data</c>
    /// e utilizam o <b>Entity Framework Core</b> ou outro provedor ORM para realizar
    /// operações de CRUD de forma assíncrona.
    /// </remarks>
    public interface IEstagiarioRepository
    {
        /// <summary>
        /// Obtém um estagiário a partir do seu identificador único.
        /// </summary>
        /// <param name="id">Identificador único (<see cref="Guid"/>) do estagiário.</param>
        /// <returns>
        /// Uma instância de <see cref="Estagiario"/> correspondente ao identificador informado,
        /// ou <c>null</c> se não for encontrada.
        /// </returns>
        Task<Estagiario?> ObterPorIdAsync(int id);

        /// <summary>
        /// Retorna todos os estagiários cadastrados no sistema.
        /// </summary>
        /// <returns>
        /// Uma coleção enumerável contendo todas as instâncias de <see cref="Estagiario"/> persistidas.
        /// </returns>
        Task<IEnumerable<Estagiario>> ObterTodosAsync();

        /// <summary>
        /// Adiciona um novo estagiário ao repositório.
        /// </summary>
        /// <param name="estagiario">Instância de <see cref="Estagiario"/> a ser persistida.</param>
        /// <returns>Uma tarefa representando a operação assíncrona.</returns>
        /// <exception cref="ArgumentNullException">
        /// Lançada quando o parâmetro <paramref name="estagiario"/> é nulo.
        /// </exception>
        Task AdicionarAsync(Estagiario estagiario);

        /// <summary>
        /// Atualiza as informações de um estagiário existente no repositório.
        /// </summary>
        /// <param name="estagiario">Instância de <see cref="Estagiario"/> com os dados atualizados.</param>
        /// <returns>Uma tarefa representando a operação assíncrona.</returns>
        /// <exception cref="ArgumentNullException">
        /// Lançada quando o parâmetro <paramref name="estagiario"/> é nulo.
        /// </exception>
        Task AtualizarAsync(Estagiario estagiario);

        /// <summary>
        /// Remove um estagiário do repositório com base em seu identificador único.
        /// </summary>
        /// <param name="id">Identificador único (<see cref="Guid"/>) do estagiário a ser removido.</param>
        /// <returns>Uma tarefa representando a operação assíncrona.</returns>
        Task RemoverAsync(int id);

        /// <summary>
        /// Obtém um estagiário com base em seu endereço de e-mail.
        /// </summary>
        /// <param name="email">Endereço de e-mail do estagiário.</param>
        /// <returns>
        /// Uma instância de <see cref="Estagiario"/> correspondente ao e-mail informado,
        /// ou <c>null</c> se não for encontrada.
        /// </returns>
        Task<Estagiario?> ObterPorEmailAsync(string email);
    }
}
