using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace Loop.Domain.Entities
{
    public abstract class Usuario
    {
        public int Id { get; protected set; }
        public string Nome { get; protected set; } = string.Empty;
        public string Email { get; protected set; } = string.Empty;
        public string Senha { get; protected set; } = string.Empty;

        protected Usuario(string nome, string email, string senha)
        {
            ValidaNome(nome);
            ValidaEmail(email);
            EncriptadorDeSenha(senha);
            Nome = nome;
            Email = email;
            Senha = senha;
        }

        protected void ValidaNome(string nome)
        {
            if (string.IsNullOrEmpty(nome) || string.IsNullOrWhiteSpace(nome))
                throw new ArgumentNullException("A nome não pode ser nulo ou vazio !!!");
        }

        protected Usuario(){}
        protected void ValidaEmail(string email)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrWhiteSpace(email))
                throw new ArgumentNullException("A senha não pode ser nula ou vazia !!!");

            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                throw new ArgumentException("O email está em formato inválido.", nameof(email));
        }

        protected void ValidaSenha(string senhaPura)
        {
            if (!senhaPura.Any(char.IsDigit))
                throw new ArgumentException("A senha teve conter ao menos um número");

            if (!senhaPura.Any(char.IsLower))
                throw new ArgumentException("A senha teve ter ao menos uma letra minúscula");

            if (!senhaPura.Any(char.IsUpper))
                throw new ArgumentException("A senha teve ter ao menos uma letra mainúscula");

            if (string.IsNullOrEmpty(senhaPura) || string.IsNullOrWhiteSpace(senhaPura))
                throw new ArgumentNullException("A senha não pode ser nula ou vazia !!!");

            if (senhaPura.Length < 6)
                throw new InvalidOperationException("A senha não pode ser menor que 6 dígitos");

            char[] caracteresEspeciais = { '!', '@', '#', '$', '%', '¨', '&', '*', '(', ')', '-', '_', '+', '=', '/', '+', '.' };
            if (!senhaPura.Any(c => caracteresEspeciais.Contains(c)))
                throw new InvalidOperationException("A senha deve conter ao menos 1 caracter especial");

            Senha = EncriptadorDeSenha(senhaPura);
        }


        public bool VerificacaoSenha(string senhaPura)
        {
            return AutentificacaoHashSeguro(senhaPura, Senha);
        }

        private static string EncriptadorDeSenha(string senhaPura)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(16);
            const int interacoes = 10000;
            using var pbkdf2 = new Rfc2898DeriveBytes(senhaPura, salt, interacoes, HashAlgorithmName.SHA3_384);
            byte[] hash = pbkdf2.GetBytes(32);

            return $"{interacoes}:{Convert.ToBase64String(salt)}:{Convert.ToBase64String(hash)}";
        }

        private static bool AutentificacaoHashSeguro(string senhaPura, string senhaCriptografada)
        {
            var partes = senhaCriptografada.Split(':');
            int interacoes = int.Parse(partes[0]);
            byte[] salt = Convert.FromBase64String(partes[1]);
            byte[] hashOriginal = Convert.FromBase64String(partes[2]);
            using var pbkdf2 = new Rfc2898DeriveBytes(senhaPura, salt, interacoes, HashAlgorithmName.SHA256);
            byte[] hashDigitado = pbkdf2.GetBytes(32);

            return CryptographicOperations.FixedTimeEquals(hashOriginal, hashDigitado);
        }

        public void AtualizarPropriedades(string nomeAtualizado, string emailAtualizado, string senhaAtualizada)
        {
            ValidaNome(nomeAtualizado);
            ValidaEmail(emailAtualizado);
            EncriptadorDeSenha(senhaAtualizada);
            Nome = nomeAtualizado;
            Email = emailAtualizado;
        }
    }
}