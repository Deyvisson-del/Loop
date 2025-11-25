using Loop.Domain.Enums;

namespace Loop.Domain.Entities
{
    public class Solicitacoes
    {

        public int Id { get; set; }
        public int EstagiarioId { get; set; }
        public Estagiario Estagiario { get; set; }
        public int FrequenciaId { get; set; }
        public Frequencia Frequencia { get; set; }
        public DateTime DataSolicitacao { get; set; } = DateTime.Now;
        public string Justificativa { get; set; }
        public DateTime? NovaEntrada { get; set; }
        public DateTime? NovaSaida { get; set; }
        public StatusSolicitacao Status { get; set; } = StatusSolicitacao.PE;
        public string? RespostaGestor { get; set; }
        public DateTime? RespostaData { get; set; }

        public Solicitacoes(){}

        public Solicitacoes(int estagiarioId, int frequenciaId, string justificativa, DateTime? novaEntrada, DateTime? novaSaida)
        {
            EstagiarioId = estagiarioId;
            FrequenciaId = frequenciaId;
            Justificativa = justificativa;
            NovaEntrada = novaEntrada;
            NovaSaida = novaSaida;
        }

        public void Aprovar(string respostaGestor)
        {
            if (Status != StatusSolicitacao.PE)
                throw new InvalidOperationException("Solicitação já foi processada. ");

            Status = StatusSolicitacao.AP;
            RespostaGestor = respostaGestor;
            RespostaData = DateTime.Now;
        }

        public void Reprovar(string respostaGestor)
        {
            if (Status != StatusSolicitacao.PE)
                throw new InvalidOperationException("Solicitação já foi processada. ");

            Status = StatusSolicitacao.RP;
            RespostaGestor = respostaGestor;
            RespostaData = DateTime.Now;
        }

        public void AtualizarHorarios(DateTime? entrada, DateTime? saida)
        {
            if (Status != StatusSolicitacao.PE)
                throw new InvalidOperationException("Solicitação já processada.");

            NovaEntrada = entrada;
            NovaSaida = saida;
        }


    }
}
