using Loop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Loop.Infra.Data.Configurations
{
    /// <summary>
    /// Configuração de mapeamento da entidade <see cref="Estagiario"/> para o Entity Framework Core.
    /// Define as chaves, restrições, relacionamentos e índices da tabela correspondente.
    /// </summary>
    public class EstagiarioConfiguration : IEntityTypeConfiguration<Estagiario>
    {
        /// <summary>
        /// Configura a entidade <see cref="Estagiario"/> no modelo de banco de dados.
        /// </summary>
        /// <param name="builder">Construtor responsável por configurar as propriedades e relacionamentos da entidade.</param>
        public void Configure(EntityTypeBuilder<Estagiario> builder)
        {
            // Define a chave primária
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            // Configura propriedades obrigatórias com tamanho máximo
            builder.Property(e => e.Nome)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(e => e.Email)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(e => e.Senha)
                   .IsRequired();

            // Define o relacionamento 1:N entre Estagiário e Frequências
            builder.HasMany(e => e.Frequencias)
                   .WithOne(f => f.Estagiario)
                   .HasForeignKey(f => f.EstagiarioId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Cria um índice único para o campo Email
            builder.HasIndex(e => e.Email)
                   .IsUnique();
        }
    }
}
