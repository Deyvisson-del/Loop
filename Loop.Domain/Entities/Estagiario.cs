using Loop.Domain.Requests;

namespace Loop.Domain.Entities
{
    public class Estagiario : Usuario
    {
        public Estagiario(string name, string email, string senha) : base(name, email, senha) { }
        public Estagiario() { }

        public ICollection<Frequencia> frequencias { get; set; } = new List<Frequencia>();
        public ICollection<Solicitacao> solicitacoes { get; set; } = new List<Solicitacao>();
    }
}