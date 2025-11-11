using Loop.Domain.Entities;

namespace Loop.Domain.Interfaces
{
    /// <summary>
    /// Define o contrato para operações de persistência e recuperação de dados
    /// relacionadas à entidade <see cref="Frequencia"/>.
    /// </summary>
    /// <remarks>
    /// Esta interface segue o padrão <b>Repository</b>, fornecendo uma abstração entre
    /// a camada de domínio e a infraestrutura de acesso a dados.  
    /// <br/><br/>
    /// Implementações concretas geralmente residem na camada <c>Infra.Data</c> e utilizam
    /// o <b>Entity Framework Core</b> ou outro provedor ORM para realizar as operações de CRUD.
    /// </remarks>
    public interface IFrequenciaRepository
    {
        /// <summary>
        /// Obtém uma frequência específica a partir do seu identificador único.
        /// </summary>
        /// <param name="id">Identificador único (<see cref="Guid"/>) da frequência.</param>
        /// <returns>
        /// Uma instância de <see cref="Frequencia"/> correspondente ao <paramref name="id"/> informado,
        /// ou <c>null</c> se não for encontrada.
        /// </returns>
        Task<Frequencia?> ObterPorIdAsync(Guid id);

        /// <summary>
        /// Obtém todas as frequências associadas a um determinado estagiário.
        /// </summary>
        /// <param name="estagiarioId">Identificador único (<see cref="Guid"/>) do estagiário.</param>
        /// <returns>
        /// Uma coleção enumerável de objetos <see cref="Frequencia"/> pertencentes ao estagiário informado.
        /// </returns>
        Task<IEnumerable<Frequencia>> ObterPorEstagiarioAsync(Guid estagiarioId);

        /// <summary>
        /// Retorna todas as frequências registradas no sistema.
        /// </summary>
        /// <returns>
        /// Uma coleção enumerável contendo todas as instâncias de <see cref="Frequencia"/> persistidas.
        /// </returns>
        Task<IEnumerable<Frequencia>> ObterTodasAsync();

        /// <summary>
        /// Adiciona uma nova frequência ao repositório.
        /// </summary>
        /// <param name="frequencia">Instância de <see cref="Frequencia"/> a ser persistida.</param>
        /// <returns>Uma tarefa representando a operação assíncrona.</returns>
        /// <exception cref="ArgumentNullException">
        /// Lançada quando o parâmetro <paramref name="frequencia"/> é nulo.
        /// </exception>
        Task AdicionarAsync(Frequencia frequencia);

        /// <summary>
        /// Atualiza os dados de uma frequência existente.
        /// </summary>
        /// <param name="frequencia">Instância de <see cref="Frequencia"/> com os dados atualizados.</param>
        /// <returns>Uma tarefa representando a operação assíncrona.</returns>
        /// <exception cref="ArgumentNullException">
        /// Lançada quando o parâmetro <paramref name="frequencia"/> é nulo.
        /// </exception>
        Task AtualizarAsync(Frequencia frequencia);

        /// <summary>
        /// Remove uma frequência do repositório com base em seu identificador único.
        /// </summary>
        /// <param name="id">Identificador único (<see cref="Guid"/>) da frequência a ser removida.</param>
        /// <returns>Uma tarefa representando a operação assíncrona.</returns>
        Task RemoverAsync(Guid id);
    }
}
