namespace Loop.Domain.Requests
{
    public class Solicitacao
    {
        public int Id { get; set; }
        public int EstagiarioId { get; set; }
        public int FrequenciaId { get; set; }
        public DateTime DataSolicitacao { get; set; } = DateTime.Now;
        public string Justificativa { get; set; } = string.Empty;
        public TimeSpan? HorarioEntrada { get; set; }
        public TimeSpan? HorarioSaida { get; set; }
        public StatusSolicitacao Status { get; set; } = StatusSolicitacao.PE;
        public string? RespostaGestor { get; set; }
        public DateTime? RespostaData { get; set; }

        public Solicitacao() { }

        public Solicitacao(int estagiarioId, int frequenciaId, string justificativa, TimeSpan? novaEntrada, TimeSpan? novasaida)
        {
            EstagiarioId = estagiarioId;
            FrequenciaId = frequenciaId;
            Justificativa = justificativa;
            HorarioEntrada = novaEntrada;
            HorarioSaida = novasaida;
        }

    }
}
