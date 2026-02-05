using Loop.Domain.Entities;

namespace Loop.Domain.Requests
{
    public class Frequencia
    {
        public int Id { get; set; }
        public Estagiario? Estagiario { get; set; }
        public DateTime Data { get; set; }
        public int? EstagiarioId { get; set; }
        public TimeSpan? HoraChegada { get; set; }
        public TimeSpan? HoraSaida { get; set; }
        public TimeSpan? HorasTrabalhadas { get; set; }
        public Frequencia() { }

        public Frequencia(Estagiario estagiario, DateTime data, int estagiarioId, TimeSpan horaChegada, TimeSpan horaSaida, TimeSpan horasTrabalhaadas)
        {
            Estagiario = estagiario;
            Data = data;
            EstagiarioId = estagiarioId;
            HoraChegada = horaChegada;
            HoraSaida = horaSaida;
            HorasTrabalhadas = horasTrabalhaadas;
        }

        public void RegistrarEntrada(DateTime entrada)
        {
            if (HoraChegada != null) throw new InvalidOperationException("Entrada já registrada.");

            Data = entrada.Date;
            HoraChegada = entrada.TimeOfDay;
        }

        public void RegistrarSaida(DateTime saida)
        {
            if (HoraChegada == null) throw new InvalidOperationException("Não e possivel registrar uma saída sem entrada.");
            if (HoraSaida != null) throw new InvalidOperationException("Saída já registrada.");
            HoraSaida = saida.TimeOfDay;

            CalcularHorasTrabalhadas();
        }
        public void AjustarPonto(TimeSpan novaEntrada, TimeSpan novaSaida)
        {
            HoraChegada = novaEntrada;
            HoraSaida = novaSaida;

            CalcularHorasTrabalhadas();
        }
        private void CalcularHorasTrabalhadas()
        {
            if (HoraChegada != null && HoraSaida != null)
            {
                HorasTrabalhadas = (TimeSpan)(HoraSaida.Value - HoraChegada);
            }
        }
    }
}
