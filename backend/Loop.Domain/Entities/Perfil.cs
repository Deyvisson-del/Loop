using System.Text;
using System.Security.Cryptography;

namespace Loop.Domain.Entities
{
    /// <summary>
    /// Classe base abstrata que representa o perfil genérico de um usuário no sistema.
    /// </summary>
    /// <remarks>
    /// Essa classe contém propriedades e métodos comuns a todos os tipos de perfis,
    /// como <see cref="Gestor"/> e <see cref="Estagiario"/>.  
    /// Inclui validações de dados básicos e manipulação de senha com hash SHA256.
    /// </remarks>
    public abstract class Perfil
    {
        /// <summary>
        /// Identificador único do perfil.
        /// </summary>
        public Guid Id { get; protected set; } = Guid.NewGuid();

        /// <summary>
        /// Nome completo do usuário.
        /// </summary>
        public string Nome { get; protected set; } = string.Empty;

        /// <summary>
        /// Endereço de e-mail do usuário.
        /// </summary>
        public string Email { get; protected set; } = string.Empty;

        /// <summary>
        /// Senha do usuário armazenada em formato de hash (SHA256).
        /// </summary>
        public string Senha { get; protected set; } = string.Empty;

        /// <summary>
        /// Valida as propriedades principais do perfil, garantindo que
        /// nome, e-mail e senha atendam aos critérios mínimos de segurança e formato.
        /// </summary>
        /// <param name="nome">Nome do usuário a ser validado.</param>
        /// <param name="email">Endereço de e-mail a ser validado.</param>
        /// <param name="senha">Senha a ser validada.</param>
        /// <exception cref="ArgumentException">
        /// Lançada quando uma das propriedades não atende aos critérios exigidos.
        /// </exception>
        protected void ValidarPropriedades(string nome, string email, string senha)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome é obrigatório.", nameof(nome));

            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("O e-mail é obrigatório.", nameof(email));

            if (!email.Contains("@"))
                throw new ArgumentException("O e-mail está em formato inválido.", nameof(email));

            if (string.IsNullOrWhiteSpace(senha))
                throw new ArgumentException("A senha é obrigatória.", nameof(senha));

            if (senha.Length < 6)
                throw new ArgumentException("A senha deve ter pelo menos 6 caracteres.", nameof(senha));
        }

        /// <summary>
        /// Gera um hash SHA256 a partir de uma senha em texto puro.
        /// </summary>
        /// <param name="senha">Senha em texto puro a ser criptografada.</param>
        /// <returns>Uma string Base64 representando o hash da senha.</returns>
        protected static string GerarHash(string senha)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(senha));
            return Convert.ToBase64String(bytes);
        }

        /// <summary>
        /// Verifica se a senha digitada corresponde ao hash armazenado.
        /// </summary>
        /// <param name="senhaDigitada">Senha digitada pelo usuário.</param>
        /// <returns>
        /// <see langword="true"/> se a senha digitada gerar o mesmo hash armazenado;
        /// caso contrário, <see langword="false"/>.
        /// </returns>
        public bool VerificarSenha(string senhaDigitada)
        {
            var hashDigitada = GerarHash(senhaDigitada);
            return Senha == hashDigitada;
        }
    }
}
