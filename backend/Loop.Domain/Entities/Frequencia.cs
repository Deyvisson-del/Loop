namespace Loop.Domain.Entities
{

    public class Frequencia
    
        public int Id { get; private set; } = default!;

   
        public int EstagiarioId { get; private set; }

   
        public Estagiario Estagiario { get; private set; } = null!;

        public DateTime? Data { get; private set; } = DateTime.UtcNow.Date;

       
        public TimeSpan? HoraChegada { get; private set; }

        
        public TimeSpan? HoraSaida { get; private set; }

        public double HorasTrabalhadas { get; private set; }

      
        protected Frequencia() { }

        public Frequencia(int estagiarioId)
        {
            if (estagiarioId == 0)
                throw new ArgumentNullException(nameof(estagiarioId), "Estagiário Inválido.");

            EstagiarioId = estagiarioId;
            DateTime dateTime = DateTime.UtcNow;
            HoraChegada = DateTime.UtcNow;
        }

      
        public void RegistrarPonto()
        {
            var agora = TimeOnly.FromDateTime(DateTime.UtcNow);

            if (agora < new TimeOnly(8, 0) || agora > new TimeOnly(17, 0))
                throw new InvalidOperationException("Fora do horário permitido de trabalho.");

            if (HoraChegada is null)
            {
                HoraChegada = agora;
                return;
            }

            if (HoraSaida is null)
            {
                if (Math.Abs(agora.ToTimeSpan().TotalMinutes - HoraChegada.Value.ToTimeSpan().TotalMinutes) < 1)
                    throw new InvalidOperationException("Não é possível registrar a saída com menos de 1 minuto após a entrada.");

                HoraSaida = agora;
                HorasTrabalhadas = CalcularHorasTrabalhadas();
                return;
            }

            throw new InvalidOperationException("Ponto já registrado para o dia de hoje.");
        }

        
        private double CalcularHorasTrabalhadas()
        {
            if (HoraChegada is null || HoraSaida is null)
                return 0;

            var diferenca = HoraSaida.Value.ToTimeSpan() - HoraChegada.Value.ToTimeSpan();
            return Math.Round(diferenca.TotalHours, 2);
        }

        public void AtualizarHoras(TimeOnly novaEntrada, TimeOnly novaSaida)
        {
            HoraChegada = novaEntrada;
            HoraSaida = novaSaida;
            HorasTrabalhadas = CalcularHorasTrabalhadas();
        }
    }
}