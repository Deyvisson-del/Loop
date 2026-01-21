namespace Loop.Domain.Entities
{
    public class Gestor : Usuario
    {
        public Gestor(string name, string email, string senha) : base(name, email, senha) { }
        public Gestor() { }
    }
}
