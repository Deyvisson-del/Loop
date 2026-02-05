namespace Loop.Application.DTOs
{
    public class FrequenciaDTO
    {
        public int EstagiarioId { get; set; }
        public DateTime? dataHoraEntrada { get; set; }
        public FrequenciaDTO(int estagiarioId)
        {
            EstagiarioId = estagiarioId;
        }
    }
}