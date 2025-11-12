using Microsoft.EntityFrameworkCore;
using Loop.Domain.Entities;

namespace Loop.Infra.Data.Context
{
    /// <summary>
    /// Representa o contexto principal do banco de dados da aplicação Loop.
    /// </summary>
    /// <remarks>
    /// Essa classe herda de <see cref="DbContext"/> e é responsável por mapear e gerenciar
    /// o ciclo de vida das entidades do domínio (<see cref="Estagiario"/>, <see cref="Frequencia"/>,
    /// <see cref="Gestor"/>), além de aplicar as configurações definidas nas classes de configuração
    /// (implementações de <see cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{TEntity}"/>).
    /// </remarks>
    public class LoopDbContext : DbContext
    {
        /// <summary>
        /// Inicializa uma nova instância de <see cref="LoopDbContext"/> com as opções especificadas.
        /// </summary>
        /// <param name="options">
        /// Parâmetros de configuração do <see cref="DbContext"/>, como a string de conexão e o provedor de banco de dados.
        /// </param>
        public LoopDbContext(DbContextOptions<LoopDbContext> options) : base(options) { }

        /// <summary>
        /// Representa a tabela de <see cref="Estagiario"/> no banco de dados.
        /// </summary>
        public DbSet<Estagiario> Estagiarios { get; set; }

        /// <summary>
        /// Representa a tabela de <see cref="Frequencia"/> no banco de dados.
        /// </summary>
        public DbSet<Frequencia> Frequencias { get; set; }

        /// <summary>
        /// Representa a tabela de <see cref="Gestor"/> no banco de dados.
        /// </summary>
        public DbSet<Gestor> Gestores { get; set; }

        /// <summary>
        /// Configura o modelo de dados e aplica automaticamente todas as configurações de entidade
        /// definidas no assembly atual.
        /// </summary>
        /// <param name="modelBuilder">
        /// Instância de <see cref="ModelBuilder"/> usada para configurar o mapeamento das entidades.
        /// </param>
        /// <remarks>
        /// O método <see cref="ModelBuilder.ApplyConfigurationsFromAssembly(System.Reflection.Assembly)"/> 
        /// varre automaticamente o assembly para aplicar todas as classes que implementam 
        /// <see cref="IEntityTypeConfiguration{TEntity}"/> — como 
        /// <see cref="Loop.Infra.Data.Configurations.EstagiarioConfiguration"/>,
        /// <see cref="Loop.Infra.Data.Configurations.FrequenciaConfiguration"/> e 
        /// <see cref="Loop.Infra.Data.Configurations.GestorConfiguration"/>.
        /// </remarks>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LoopDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
