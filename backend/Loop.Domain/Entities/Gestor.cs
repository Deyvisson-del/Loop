namespace Loop.Domain.Entities
{
    /// <summary>
    /// Representa um gestor dentro do sistema.
    /// </summary>
    /// <remarks>
    /// O gestor é responsável por supervisionar e gerenciar um conjunto de estagiários.  
    /// Essa classe herda as propriedades e comportamentos básicos de <see cref="Perfil"/>,
    /// como validação de dados e geração de hash de senha.
    /// </remarks>
    public class Gestor : Perfil
    {
        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="Gestor"/> com os dados informados.
        /// </summary>
        /// <param name="nome">Nome completo do gestor.</param>
        /// <param name="email">Endereço de e-mail do gestor.</param>
        /// <param name="senha">Senha em texto puro que será validada e convertida em hash seguro.</param>
        /// <exception cref="ArgumentException">
        /// Lançada quando alguma das propriedades informadas não atende aos critérios de validação.
        /// </exception>
        public Gestor(string nome, string email, string senha)
        {
            Id = default!;
            ValidarPropriedades(nome, email, senha);
            string senhaHash = GerarHash(senha);

            Nome = nome;
            Email = email;
            Senha = senhaHash;
        }

        /// <summary>
        /// Construtor vazio utilizado por frameworks de persistência (como o Entity Framework).
        /// </summary>
        public Gestor()
        {
        }

        /// <summary>
        /// Corrige os horários de entrada e saída de uma frequência registrada por um estagiário.
        /// </summary>
        /// <param name="frequencia">Instância de <see cref="Frequencia"/> que será atualizada.</param>
        /// <param name="novaEntrada">Novo horário de entrada a ser definido.</param>
        /// <param name="novaSaida">Novo horário de saída a ser definido.</param>
        /// <remarks>
        /// Este método deve ser utilizado quando for necessário ajustar uma frequência já registrada, 
        /// normalmente em casos de erro de marcação de ponto.  
        /// <br/><br/>
        /// ⚙️ **Comportamento:**  
        /// - Valida se a frequência informada não é nula.  
        /// - Garante que a hora de entrada seja anterior à de saída.  
        /// - Atualiza os horários chamando o método <see cref="Frequencia.AtualizarHoras(TimeOnly, TimeOnly)"/>.  
        /// </remarks>
        /// <exception cref="ArgumentNullException">
        /// Lançada quando o parâmetro <paramref name="frequencia"/> é nulo.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Lançada quando a hora de entrada é igual ou posterior à hora de saída.
        /// </exception>
        /// <example>
        /// Exemplo de uso:
        /// <code>
        /// var gestor = new Gestor("Carlos Silva", "carlos@empresa.com", "SenhaSegura123");
        /// var frequencia = new Frequencia(estagiarioId);
        /// 
        /// // Corrige horários incorretos registrados pelo estagiário
        /// gestor.CorrigirFrequencia(frequencia, new TimeOnly(8, 0), new TimeOnly(17, 0));
        /// 
        /// Console.WriteLine(frequencia.HorasTrabalhadas); // Exibe 9,0
        /// </code>
        /// </example>
        public void CorrigirFrequencia(Frequencia frequencia, TimeOnly novaEntrada, TimeOnly novaSaida)
        {
            if (frequencia == null)
                throw new ArgumentNullException(nameof(frequencia), "A frequência não pode ser nula.");

            if (novaEntrada >= novaSaida)
                throw new InvalidOperationException("A hora de entrada deve ser anterior à saída.");

            frequencia.AtualizarHoras(novaEntrada, novaSaida);
        }
    }
}
