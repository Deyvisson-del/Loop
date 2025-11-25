namespace Loop.Domain.Entities
{
    public class Administrador : Perfil
    {

        public Administrador(string nome, string email, string senha)
        {
            ValidarPropriedades(nome, email);
            DefinirSenha(senha);

            Nome = nome;
            Email = email;
        }

        public Administrador() { }
    }
}
