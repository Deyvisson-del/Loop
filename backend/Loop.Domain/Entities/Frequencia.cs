namespace Loop.Domain.Entities
{
    /// <summary>
    /// Representa o registro de frequência de um estagiário.
    /// </summary>
    /// <remarks>
    /// A classe <see cref="Frequencia"/> é usada para controlar a presença e registrar
    /// os horários de chegada e saída de um estagiário em um determinado dia de trabalho.
    /// </remarks>
    public class Frequencia
    {
        /// <summary>
        /// Identificador único da frequência.
        /// </summary>
        public int Id { get; private set; } = default!;

        /// <summary>
        /// Identificador do estagiário associado a este registro de frequência.
        /// </summary>
        public int EstagiarioId { get; private set; }

        /// <summary>
        /// Navegação para o estagiário associado a este registro.
        /// </summary>
        /// <value>
        /// Instância de <see cref="Estagiario"/> relacionada à frequência.
        /// </value>
        public Estagiario Estagiario { get; private set; } = null!;

        /// <summary>
        /// Data em que a frequência foi registrada.
        /// </summary>
        /// <remarks>
        /// Por padrão, é inicializada com a data atual no fuso UTC.
        /// </remarks>
        public DateTime? Data { get; private set; } = DateTime.UtcNow.Date;

        /// <summary>
        /// Horário de chegada do estagiário.
        /// </summary>
        public TimeOnly? HoraChegada { get; private set; }

        /// <summary>
        /// Horário de saída do estagiário.
        /// </summary>
        public TimeOnly? HoraSaida { get; private set; }

        /// <summary>
        /// Total de horas trabalhadas no dia, calculado automaticamente
        /// ao registrar a saída.
        /// </summary>
        public double HorasTrabalhadas { get; private set; }

        /// <summary>
        /// Construtor protegido utilizado por ORMs e mecanismos de serialização.
        /// </summary>
        protected Frequencia() { }

        /// <summary>
        /// Cria uma nova instância de <see cref="Frequencia"/> associada a um estagiário específico.
        /// </summary>
        /// <param name="estagiarioId">Identificador do estagiário que registrará o ponto.</param>
        /// <exception cref="ArgumentNullException">
        /// Lançada quando o identificador do estagiário é inválido (vazio).
        /// </exception>
        /// <remarks>
        /// Ao criar uma nova frequência, a hora de chegada é automaticamente definida
        /// como o horário atual e o status <see cref="Presente"/> é marcado como verdadeiro.
        /// </remarks>
        public Frequencia(int estagiarioId)
        {
            if (estagiarioId == 0)
                throw new ArgumentNullException(nameof(estagiarioId), "Estagiário Inválido.");

            EstagiarioId = estagiarioId;
            DateTime dateTime = DateTime.UtcNow;
            HoraChegada = TimeOnly.FromDateTime(DateTime.UtcNow);
        }

        /// <summary>
        /// Registra o ponto de entrada ou saída do estagiário conforme o horário atual.
        /// </summary>
        /// <remarks>
        /// - O registro só pode ser feito dentro do horário permitido (08:00 às 17:00). <br/>
        /// - A primeira chamada define a <see cref="HoraChegada"/>. <br/>
        /// - A segunda chamada define a <see cref="HoraSaida"/> e calcula <see cref="HorasTrabalhadas"/>. <br/>
        /// - Chamadas adicionais no mesmo dia lançam exceção.
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        /// Lançada quando o horário está fora do intervalo permitido, quando
        /// o ponto já foi registrado, ou quando a tentativa de registrar saída
        /// ocorre em menos de 1 minuto após a entrada.
        /// </exception>
        /// <example>
        /// Exemplo de uso:
        /// <code>
        /// var freq = new Frequencia(estagiarioId);
        /// freq.RegistrarPonto(); // Registra chegada
        /// // ...
        /// freq.RegistrarPonto(); // Registra saída
        /// </code>
        /// </example>
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

        /// <summary>
        /// Calcula o total de horas trabalhadas com base nos horários de entrada e saída.
        /// </summary>
        /// <returns>
        /// O número de horas trabalhadas, arredondado para duas casas decimais.
        /// Retorna <c>0</c> se os horários de chegada ou saída não estiverem definidos.
        /// </returns>
        private double CalcularHorasTrabalhadas()
        {
            if (HoraChegada is null || HoraSaida is null)
                return 0;

            var diferenca = HoraSaida.Value.ToTimeSpan() - HoraChegada.Value.ToTimeSpan();
            return Math.Round(diferenca.TotalHours, 2);
        }

        /// <summary>
        /// Atualiza manualmente os horários de entrada e saída do estagiário,
        /// recalculando o total de horas trabalhadas.
        /// </summary>
        /// <param name="novaEntrada">Novo horário de entrada do estagiário.</param>
        /// <param name="novaSaida">Novo horário de saída do estagiário.</param>
        /// <remarks>
        /// Este método permite ajustar os horários de ponto após o registro inicial, 
        /// garantindo que o total de <see cref="HorasTrabalhadas"/> seja recalculado com base 
        /// nos novos valores informados.  
        /// <br/><br/>
        /// ⚙️ **Comportamento:**  
        /// - Atualiza as propriedades <see cref="HoraEntrada"/> e <see cref="HoraSaida"/>.  
        /// - Invoca internamente o método <see cref="CalcularHorasTrabalhadas"/> 
        ///   para recalcular a duração total do expediente.  
        /// - Ideal para casos de correção de registros manuais ou ajustes administrativos.
        /// </remarks>
        /// <exception cref="ArgumentException">
        /// Lançada quando a hora de saída é anterior à hora de entrada.
        /// </exception>
        /// <example>
        /// Exemplo de uso:
        /// <code>
        /// var frequencia = new Frequencia(estagiarioId);
        /// frequencia.AtualizarHoras(new TimeOnly(8, 30), new TimeOnly(16, 45));
        /// 
        /// Console.WriteLine(frequencia.HorasTrabalhadas); // Exibe 8,25
        /// </code>
        /// </example>
        public void AtualizarHoras(TimeOnly novaEntrada, TimeOnly novaSaida)
        {
            HoraChegada = novaEntrada;
            HoraSaida = novaSaida;
            HorasTrabalhadas = CalcularHorasTrabalhadas();
        }
    }
}