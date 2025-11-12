namespace Loop.Application.Requests
{
    /// <summary>
    /// Representa a solicitação de registro de um novo estagiário no sistema.
    /// </summary>
    /// <remarks>
    /// Essa classe é utilizada para transportar os dados necessários à criação 
    /// de um novo estagiário da camada de apresentação (API/UI) até a camada 
    /// de aplicação responsável pelo processamento e validação do cadastro.
    /// </remarks>
    public class RegistrarEstagiarioRequest
    {
        /// <summary>
        /// Nome completo do estagiário que está sendo cadastrado.
        /// </summary>
        /// <example>João da Silva</example>
        public string Nome { get; set; } = string.Empty;

        /// <summary>
        /// Endereço de e-mail do estagiário.
        /// </summary>
        /// <remarks>
        /// O e-mail deve ser único e servirá como identificador de login no sistema.
        /// </remarks>
        /// <example>joao.silva@empresa.com</example>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Senha de acesso do estagiário em texto puro (será validada e convertida em hash antes do armazenamento).
        /// </summary>
        /// <example>SenhaForte@123</example>
        public string Senha { get; set; } = string.Empty;
    }
}
