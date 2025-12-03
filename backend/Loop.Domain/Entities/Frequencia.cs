namespace Loop.Domain.Entities
{
    public class Frequencia
    {
        public int Id { get; private set; } = default!;
        public int EstagiarioId { get; set; }
        public Estagiario Estagiario { get; private set; } = null!;

        public DateTime Data { get; set; } 
        public TimeSpan HoraChegada { get; set; } 
        public TimeSpan? HoraSaida { get; set; }
        public TimeSpan HorasTrabalhadas { get; set; }
        public Frequencia() { }

        public Frequencia(int estagiarioId, DateTime data)
        {
            EstagiarioId = estagiarioId;
            Data = data.Date;
        }

        public void RegistrarEntrada(DateTime entrada)
        {
            if (HoraChegada != null) 
                throw new InvalidOperationException("Entrada já registrada. ");

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
                HorasTrabalhadas = HoraSaida.Value - HoraChegada;
            }
        }

    }
}