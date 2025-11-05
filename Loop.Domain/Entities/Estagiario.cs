namespace Loop.Domain.Entities
{
    public class Estagiario
    {

        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nome { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string Senha { get; private set; } = string.Empty;

        public Estagiario(string nome, string email, string senha)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Email = email;
            Senha = senha;
        }

    }
}
