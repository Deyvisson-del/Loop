namespace Loop.Domain.Entities
{
    public class Administrador : Usuario
    {
        public Administrador(string nome, string email, string senha) : base(nome, email)
        {
            DefinirSenha(senha);
        }
        public Administrador() { }
    }
}
