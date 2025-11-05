namespace Loop.Domain.Entities
{
    public class Gestor
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nome = string.Empty;
        public string Email = string.Empty;
        public string Senha = string.Empty;

        public Gestor(string nome, string email, string senha)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Email = email;
            Senha = senha;
        }
    }
}
