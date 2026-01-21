namespace Loop.Domain.Entities
{
    public class Estagiario : Usuario
    {
        public Estagiario(string name, string email, string senha) : base(name, email, senha) { }
        public Estagiario() { }
    }
}