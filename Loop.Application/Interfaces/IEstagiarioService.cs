using Loop.Application.DTOs;

namespace Loop.Application.Interfaces
{
    /// <summary>
    /// Define os serviços de aplicação relacionados à gestão de estagiários.
    /// </summary>
    /// <remarks>
    /// Esta interface herda as operações básicas de <see cref="IBaseService{EstagiarioDTO}"/> 
    /// e adiciona métodos específicos para manipulação e consulta de estagiários, 
    /// como a busca por endereço de e-mail.
    /// </remarks>
    public interface IEstagiarioService : IBaseService<EstagiarioDTO>
    {
        /// <summary>
        /// Obtém um estagiário com base em seu endereço de e-mail.
        /// </summary>
        /// <param name="email">Endereço de e-mail do estagiário a ser buscado.</param>
        /// <returns>
        /// Um objeto <see cref="EstagiarioDTO"/> correspondente ao e-mail informado, 
        /// ou <see langword="null"/> caso nenhum estagiário seja encontrado.
        /// </returns>
        /// <example>
        /// Exemplo de uso:
        /// <code>
        /// var estagiario = await _estagiarioService.ObterPorEmailAsync("joao.silva@empresa.com");
        /// 
        /// if (estagiario != null)
        /// {
        ///     Console.WriteLine($"Estagiário encontrado: {estagiario.Nome}");
        /// }
        /// else
        /// {
        ///     Console.WriteLine("Nenhum estagiário encontrado para o e-mail informado.");
        /// }
        /// </code>
        /// </example>
        Task<EstagiarioDTO?> ObterPorEmailAsync(string email);
    }
}
