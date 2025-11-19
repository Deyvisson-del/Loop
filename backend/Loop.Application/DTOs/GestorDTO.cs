namespace Loop.Application.DTOs
{
    /// <summary>
    /// Representa os dados de um gestor utilizados para transferência entre camadas da aplicação.
    /// </summary>
    /// <remarks>
    /// Este DTO é responsável por transportar informações básicas do gestor,
    /// como identificação, credenciais e contato.
    /// </remarks>
    public class GestorDTO
    {
        /// <summary>
        /// Identificador único do gestor.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Nome completo do gestor.
        /// </summary>
        public string Nome { get; set; } = null!;

        /// <summary>
        /// Endereço de e-mail do gestor.
        /// </summary>
        public string Email { get; set; } = null!;

        /// <summary>
        /// Senha do gestor em formato de texto puro.
        /// <para>⚠️ Este campo não deve ser exposto publicamente em APIs ou logs.</para>
        /// </summary>
        public string Senha { get; set; } = null!;
    }
}
