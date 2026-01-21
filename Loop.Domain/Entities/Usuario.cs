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


        protected string EncriptadorDeSenha(string senhaPura)
        {
            return "";
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