namespace Loop.Domain.Entities
{
    public class Estagiario : Perfil
    {
        public Estagiario(string nome, string email, string senha)
        {
            ValidarPropriedades(nome, email);
            DefinirSenha(senha);

            Nome = nome;
            Email = email;
        }

        public Estagiario()
        {
        }

        public ICollection<Frequencia> Frequencias { get; set; } = new List<Frequencia>();
        public ICollection<Solicitacao> Solicitacoes { get; set; } = new List<Solicitacao>();
    }
}
