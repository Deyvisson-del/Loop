namespace Loop.Domain.Entities
{
    public class Gestor : Perfil
    {

        public Gestor(string nome, string email, string senha)
        {
            ValidarPropriedades(nome, email);
            DefinirSenha(senha);

            Nome = nome;
            Email = email;
        }

        public Gestor()
        {
        }

    }
}
