namespace Loop.Domain.Entities
{
    /// <summary>
    /// Representa um gestor dentro do sistema.
    /// </summary>
    /// <remarks>
    /// O gestor é responsável por supervisionar e gerenciar um conjunto de estagiários.  
    /// Essa classe herda as propriedades e comportamentos básicos de <see cref="Perfil"/>,
    /// como validação e criptografia de senha.
    /// </remarks>
    public class Gestor : Perfil
    {
        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="Gestor"/> com os dados informados.
        /// </summary>
        /// <param name="nome">Nome completo do gestor.</param>
        /// <param name="email">Endereço de e-mail do gestor.</param>
        /// <param name="senha">Senha em texto puro que será validada e convertida em hash.</param>
        /// <exception cref="ArgumentException">
        /// Lançada quando alguma das propriedades informadas não atende aos critérios de validação.
        /// </exception>
        public Gestor(string nome, string email, string senha)
        {
            Id = Guid.NewGuid();
            ValidarPropriedades(nome, email, senha);
            string senhaHash = GerarHash(senha);

            Nome = nome;
            Email = email;
            Senha = senhaHash;
        }

        /// <summary>
        /// Construtor vazio utilizado por frameworks de persistência (como Entity Framework).
        /// </summary>
        public Gestor()
        {
        }

        /// <summary>
        /// Coleção de estagiários supervisionados por este gestor.
        /// </summary>
        /// <remarks>
        /// Essa propriedade representa o relacionamento um-para-muitos entre o gestor e os estagiários.
        /// </remarks>
        public virtual ICollection<Estagiario> Estagiarios { get; set; } = new List<Estagiario>();
    }
}
