namespace Loop.Application.Requests
{
    /// <summary>
    /// Representa a solicitação de login enviada pelo usuário para autenticação no sistema.
    /// </summary>
    /// <remarks>
    /// Essa classe é utilizada para transportar os dados de autenticação 
    /// (e-mail e senha) da camada de apresentação (por exemplo, uma API ou UI) 
    /// até a camada de aplicação responsável pela validação do login.
    /// </remarks>
    public class LoginRequest
    {
        /// <summary>
        /// Endereço de e-mail do usuário que está tentando realizar o login.
        /// </summary>
        /// <example>usuario@empresa.com</example>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Senha do usuário em texto puro (será validada e comparada com o hash armazenado no sistema).
        /// </summary>
        /// <example>MinhaSenhaSegura123</example>
        public string Senha { get; set; } = string.Empty;
    }
}
