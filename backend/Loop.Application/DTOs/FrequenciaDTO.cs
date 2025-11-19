namespace Loop.Application.DTOs
{
    /// <summary>
    /// Representa os dados de uma frequência registrada por um estagiário.
    /// </summary>
    /// <remarks>
    /// Este DTO é utilizado para transferir informações de frequência entre camadas da aplicação,
    /// como datas, horários e vínculo com o estagiário responsável.
    /// </remarks>
    public class FrequenciaDTO
    {
        /// <summary>
        /// Identificador único da frequência.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Data referente à frequência registrada.
        /// </summary>
        public DateOnly Data { get; set; }

        /// <summary>
        /// Horário de chegada do estagiário.
        /// </summary>
        public TimeOnly HoraChegada { get; set; }

        /// <summary>
        /// Horário de saída do estagiário (pode ser nulo caso ainda não tenha sido registrado).
        /// </summary>
        public TimeOnly? HoraSaida { get; set; }

        /// <summary>
        /// Identificador do estagiário ao qual esta frequência pertence.
        /// </summary>
        public int EstagiarioId { get; set; }
    }
}
