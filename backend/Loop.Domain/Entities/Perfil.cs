using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Loop.Domain.Entities
{

    public abstract class Perfil
    {
    
        public int Id { get; protected set; } 

        
        public string Nome { get; protected set; } = string.Empty;

      
        public string Email { get; protected set; } = string.Empty;

        
        public string SenhaHash { get; protected set; } = string.Empty;

        protected void DefinirSenha(string senha)
        {
            if (string.IsNullOrWhiteSpace(senha))
                throw new ArgumentException("A senha é Obrigatória.");
            if (senha.Length < 6)
                throw new ArgumentException("A senha deve ter pelo menos 6 caracreres.");
            SenhaHash = GerarHashSeguro(senha);
        }

        protected void ValidarPropriedades(string nome, string email)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome é obrigatório.", nameof(nome));

            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("O e-mail é obrigatório.", nameof(email));

            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                throw new ArgumentException("O e-mail está em formato inválido.", nameof(email));

        }

        public bool VerificarSenha(string senhaDigitada)
        {
            return VerificarHashSeguro(senhaDigitada, SenhaHash);
        }

        private static string GerarHashSeguro(string senha)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(16);

            const int iterations = 10000;

            using var pbkdf2 = new Rfc2898DeriveBytes(senha, salt, iterations, HashAlgorithmName.SHA256);
            byte[] hash = pbkdf2.GetBytes(32);

            return $"{iterations}:{Convert.ToBase64String(salt)}:{Convert.ToBase64String(hash)}";

        }

        private static bool VerificarHashSeguro(string senhaDigitada,string senhaArmazenada)
        {
            var partes = senhaArmazenada.Split(':');
            int iterations = int.Parse(partes[0]);
            byte[] salt = Convert.FromBase64String(partes[1]);
            byte[] hashOriginal = Convert.FromBase64String(partes[2]);

            using var pbkdf2 = new Rfc2898DeriveBytes(senhaDigitada, salt, iterations, HashAlgorithmName.SHA256);
            byte[] hashDigitado = pbkdf2.GetBytes(32);

            return CryptographicOperations.FixedTimeEquals(hashDigitado, hashOriginal);
        }
    }
}
