using System.Text;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace Loop.Domain.Entities
{
    /// <summary>
    /// Representa um estagiário dentro do domínio, contendo suas informações de identificação,
    /// credenciais e registros de frequência.
    /// </summary>
    public class Estagiario
    {
        /// <summary>
        /// Identificador único do estagiário.
        /// </summary>
        public Guid Id { get; private set; } = Guid.NewGuid();

        /// <summary>
        /// Nome completo do estagiário.
        /// </summary>
        public string Nome { get; private set; } = string.Empty;

        /// <summary>
        /// Endereço de e-mail do estagiário.
        /// </summary>
        public string Email { get; private set; } = string.Empty;

        /// <summary>
        /// Hash da senha do estagiário.
        /// </summary>
        public string Senha { get; private set; } = string.Empty;

        /// <summary>
        /// Construtor que inicializa um novo estagiário com os dados informados.
        /// </summary>
        /// <param name="nome">Nome completo do estagiário.</param>
        /// <param name="email">Endereço de e-mail do estagiário.</param>
        /// <param name="senha">Senha em texto puro, que será armazenada como hash.</param>
        public Estagiario(string nome, string email, string senha)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Email = email;
            Senha = senha;
        }

        /// <summary>
        /// Construtor sem parâmetros necessário para o Entity Framework.
        /// </summary>
        public Estagiario()
        {
        }

        /// <summary>
        /// Coleção de registros de frequência associados ao estagiário.
        /// </summary>
        public virtual ICollection<Frequencia> Frequencias { get; set; } = default!;

        /// <summary>
        /// Cria uma nova instância de <see cref="Estagiario"/> após validar os dados e gerar o hash da senha.
        /// </summary>
        /// <param name="nome">Nome completo do estagiário.</param>
        /// <param name="email">Endereço de e-mail do estagiário.</param>
        /// <param name="senha">Senha em texto puro, que será convertida em hash.</param>
        /// <returns>Um novo objeto <see cref="Estagiario"/> com os dados validados e senha protegida.</returns>
        /// <exception cref="ArgumentException">Lançado quando algum dos parâmetros é inválido.</exception>
        public static Estagiario CriarNovoEstagiario(string nome, string email, string senha)
        {
            ValidarPropriedades(nome, email, senha);
            string senhaHash = GerarHash(senha);

            return new Estagiario
            {
                Id = Guid.NewGuid(),
                Nome = nome,
                Email = email,
                Senha = senhaHash
            };
        }

        /// <summary>
        /// Valida as propriedades de um estagiário, garantindo que todos os campos obrigatórios
        /// estejam preenchidos corretamente e em formato válido.
        /// </summary>
        /// <param name="nome">Nome completo do estagiário.</param>
        /// <param name="email">Endereço de e-mail do estagiário.</param>
        /// <param name="senha">Senha em texto puro.</param>
        /// <exception cref="ArgumentException">Lançado quando algum dos campos é inválido ou vazio.</exception>
        public static void ValidarPropriedades(string nome, string email, string senha)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome não pode ser vazio.", nameof(nome));

            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("O email não pode ser vazio.", nameof(email));

            if (!email.Contains("@"))
                throw new ArgumentException("O email deve ser válido.", nameof(email));

            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                throw new ArgumentException("E-mail inválido.");

            if (string.IsNullOrWhiteSpace(senha))
                throw new ArgumentException("A senha não pode ser vazia.", nameof(senha));

            if (senha.Length < 6)
                throw new ArgumentException("A senha deve ter pelo menos 6 caracteres.", nameof(senha));
        }

        /// <summary>
        /// Gera um hash criptográfico para a senha informada utilizando o algoritmo SHA256.
        /// </summary>
        /// <param name="senha">Senha em texto puro que será transformada em hash.</param>
        /// <returns>Uma string codificada em Base64 representando o hash da senha.</returns>
        private static string GerarHash(string senha)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(senha));
            string hash = Convert.ToBase64String(bytes);
            return hash;
        }

        /// <summary>
        /// Verifica se a senha digitada corresponde à senha armazenada (comparando os hashes).
        /// </summary>
        /// <param name="senhaDigitada">Senha em texto puro informada pelo usuário.</param>
        /// <returns><c>true</c> se a senha digitada corresponder à senha armazenada; caso contrário, <c>false</c>.</returns>
        public bool VerificarSenha(string senhaDigitada)
        {
            var hashDigitada = GerarHash(senhaDigitada);
            return Senha == hashDigitada;
        }
    }
}
