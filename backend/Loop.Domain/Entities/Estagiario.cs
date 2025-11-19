namespace Loop.Domain.Entities
{
    /// <summary>
    /// Representa um estagiário dentro do sistema.
    /// </summary>
    /// <remarks>
    /// O estagiário herda de <see cref="Perfil"/>, possuindo propriedades básicas como 
    /// <c>Nome</c>, <c>Email</c> e <c>Senha</c> com criptografia de hash.  
    /// Além disso, mantém um relacionamento com as entidades de <see cref="Frequencia"/>,
    /// que registram suas presenças ou atividades.
    /// </remarks>
    public class Estagiario : Perfil
    {
        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="Estagiario"/> com os dados informados.
        /// </summary>
        /// <param name="nome">Nome completo do estagiário.</param>
        /// <param name="email">Endereço de e-mail do estagiário.</param>
        /// <param name="senha">Senha em texto puro que será validada e transformada em hash.</param>
        /// <exception cref="ArgumentException">
        /// Lançada quando uma das propriedades não atende aos critérios de validação definidos em <see cref="Perfil"/>.
        /// </exception>
        public Estagiario(string nome, string email, string senha)
        {
            Id = default!;
            ValidarPropriedades(nome, email, senha);
            string senhaHash = GerarHash(senha);

            Nome = nome;
            Email = email;
            Senha = senhaHash;
        }

        /// <summary>
        /// Construtor sem parâmetros utilizado por frameworks de persistência (como o Entity Framework).
        /// </summary>
        public Estagiario()
        {
        }

        /// <summary>
        /// Coleção de registros de frequência associados ao estagiário.
        /// </summary>
        /// <remarks>
        /// Essa propriedade representa o relacionamento um-para-muitos entre 
        /// o estagiário e suas frequências registradas.
        /// </remarks>
        public virtual ICollection<Frequencia> Frequencias { get; set; } = new List<Frequencia>();

        public void AdicionarFrequencia(Frequencia frequencia)
        {
            if (frequencia == null)
            {
                throw new ArgumentNullException(nameof(frequencia), "A frequência não pode ser nula.");
            }
            Frequencias.Add(frequencia);
        }
    }
}
