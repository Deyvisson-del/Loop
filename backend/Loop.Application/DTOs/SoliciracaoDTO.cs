using Loop.Domain.Enums;

namespace Loop.Application.DTOs
{
    public class SoliciracaoDTO
    {
        public int Id { get; set; }
        public int EstagiarioId { get; set; }
        public int FrequenciaId { get; set; }
        public DateTime DataSolicitacao { get; set; }
        public string Justificativa { get; set; }
        public TimeSpan? HorarioEntrada { get; set; }
        public TimeSpan? HorarioSaida { get; set; }
        public StatusSolicitacao Status { get; set; }
        public string? RespostaGestor { get; set; }
        public DateTime? RespostaData { get; set; }
    }
}
