namespace Loop.Application.DTOs
{
    public class FrequenciaDTO
    {
        public int Id { get; set; }

        public DateOnly Data { get; set; }

        public TimeOnly HoraChegada { get; set; }

        public TimeOnly? HoraSaida { get; set; }

        public int EstagiarioId { get; set; }
    }
}
