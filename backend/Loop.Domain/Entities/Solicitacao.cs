using Loop.Domain.Enums;

namespace Loop.Domain.Entities
{
    public class Solicitacao
    {

        public int Id { get; set; }
        public int EstagiarioId { get; set; }
        public int FrequenciaId { get; set; }
        public DateTime DataSolicitacao { get; set; } = DateTime.Now;
        public string Justificativa { get; set; }
        public TimeSpan? HorarioEntrada { get; set; } 
        public TimeSpan? HorarioSaida { get; set; }
        public StatusSolicitacao Status { get; set; } = StatusSolicitacao.PE;
        public string? RespostaGestor { get; set; }
        public DateTime? RespostaData { get; set; }

        public Solicitacao() { }

        public Solicitacao(int estagiarioId, int frequenciaId, string justificativa, TimeSpan? novaEntrada, TimeSpan? novaSaida)
        {
            EstagiarioId = estagiarioId;
            FrequenciaId = frequenciaId;
            Justificativa = justificativa;
            HorarioEntrada = novaEntrada;
            HorarioSaida = novaSaida;
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

        public void AtualizarHorarios(TimeSpan? entrada, TimeSpan? saida)
        {
            if (Status != StatusSolicitacao.PE)
                throw new InvalidOperationException("Solicitação já processada.");

            HorarioEntrada = entrada;
            HorarioSaida = saida;
        }


    }
}
