using Loop.Domain.Requests;

namespace Loop.Domain.Entities
{
    public class Estagiario : Usuario
    {
        public Estagiario(string nome, string email, string senha) : base(nome, email) {

            DefinirSenha(senha);
        }
        public Estagiario() { }

        public ICollection<Frequencia> frequencias { get; set; } = new List<Frequencia>();
        public ICollection<Solicitacao> solicitacoes { get; set; } = new List<Solicitacao>();
    }
}