using Loop.Domain.Entities;
using Loop.Infra.Data.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Loop.Infra.Data.Configurations
{
    /// <summary>
    /// Configuração da entidade <see cref="Frequencia"/> para o Entity Framework Core.
    /// </summary>
    /// <remarks>
    /// Define chaves primárias, tipos de dados, restrições e relacionamentos
    /// da entidade <see cref="Frequencia"/> com outras entidades do domínio.
    /// Essa configuração é aplicada no método <c>OnModelCreating</c> do <see cref="DbContext"/>.
    /// </remarks>
    public class FrequenciaConfiguration : IEntityTypeConfiguration<Frequencia>
    {
        /// <summary>
        /// Configura o mapeamento da entidade <see cref="Frequencia"/> para o banco de dados.
        /// </summary>
        /// <param name="builder">
        /// Instância de <see cref="EntityTypeBuilder{TEntity}"/> usada para configurar a entidade.
        /// </param>
        public void Configure(EntityTypeBuilder<Frequencia> builder)
        {
            /// <summary>
            /// Define a chave primária da entidade.
            /// </summary>
            builder.HasKey(f => f.Id);

            /// <summary>
            /// Configura a propriedade <see cref="Frequencia.Data"/> como obrigatória.
            /// </summary>
            builder.Property(f => f.Data)
                   .IsRequired();

            /// <summary>
            /// Configura a propriedade <see cref="Frequencia.HoraChegada"/> 
            /// com conversão para o tipo <c>time</c> no banco de dados.
            /// </summary>
            builder.Property(f => f.HoraChegada)
                   .HasConversion<TimeOnlyConverter>()
                   .HasColumnType("time")
                   .IsRequired();

            /// <summary>
            /// Configura a propriedade <see cref="Frequencia.HoraSaida"/> 
            /// como opcional e com conversão para o tipo <c>time</c>.
            /// </summary>
            builder.Property(f => f.HoraSaida)
                   .HasConversion<TimeOnlyConverter>()
                   .HasColumnType("time")
                   .IsRequired(false);

            /// <summary>
            /// Define o relacionamento entre <see cref="Frequencia"/> e <see cref="Estagiario"/>.
            /// Cada frequência pertence a um estagiário, e um estagiário pode ter várias frequências.
            /// </summary>
            builder.HasOne(f => f.Estagiario)
                   .WithMany(e => e.Frequencias)
                   .HasForeignKey(f => f.EstagiarioId)
                   .OnDelete(DeleteBehavior.Cascade);

            /// <summary>
            /// Cria um índice único para evitar duplicação de registros
            /// de frequência com a mesma data para o mesmo estagiário.
            /// </summary>
            builder.HasIndex(f => new { f.EstagiarioId, f.Data })
                   .IsUnique();
        }
    }
}
