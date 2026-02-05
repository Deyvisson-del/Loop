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
        public Frequencia(int estagiarioId, DateTime entrada)
        {
            EstagiarioId = estagiarioId;
            HoraChegada = new TimeSpan(entrada.Hour, entrada.Minute, entrada.Second);
        }
        public void RegistrarEntrada(DateTime entrada)
        {
            //if (entrada.Date != Data) throw new InvalidOperationException("A entrada deve ser no mesmo dia");
            if (HoraChegada != null) throw new InvalidOperationException("Entrada já registrada.");
            HoraChegada = new TimeSpan(entrada.Hour, entrada.Minute, entrada.Second);
        }
        public void RegistrarSaida(DateTime saida)
        {
            if (HoraChegada == null) throw new InvalidOperationException("Não e possivel registrar uma saída sem entrada.");
            if (saida.Date != Data) throw new InvalidOperationException("A saída deve ser no mesmo dia frequência.");
            if (HoraSaida != null) throw new InvalidOperationException("Saída já registrada.");
            HoraSaida = new TimeSpan(saida.Hour, saida.Minute, saida.Second);
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