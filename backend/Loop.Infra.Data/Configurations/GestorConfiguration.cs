using Loop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Loop.Infra.Data.Configurations
{
    /// <summary>
    /// Configuração da entidade <see cref="Gestor"/> para o Entity Framework Core.
    /// </summary>
    /// <remarks>
    /// Define as regras de mapeamento da entidade <see cref="Gestor"/> com o banco de dados,
    /// incluindo chaves, restrições e índices únicos.
    /// Essa configuração é aplicada durante o processo de construção do modelo de dados
    /// no método <c>OnModelCreating</c> da classe <see cref="DbContext"/>.
    /// </remarks>
    public class GestorConfiguration : IEntityTypeConfiguration<Gestor>
    {
        /// <summary>
        /// Configura o mapeamento da entidade <see cref="Gestor"/> para a base de dados.
        /// </summary>
        /// <param name="builder">
        /// Instância de <see cref="EntityTypeBuilder{Gestor}"/> usada para configurar a entidade.
        /// </param>
        public void Configure(EntityTypeBuilder<Gestor> builder)
        {
            /// <summary>
            /// Define a chave primária da entidade.
            /// </summary>
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            /// <summary>
            /// Configura a propriedade <see cref="Gestor.Nome"/> como obrigatória,
            /// com limite máximo de 100 caracteres.
            /// </summary>
            builder.Property(e => e.Nome)
                   .IsRequired()
                   .HasMaxLength(100);

            /// <summary>
            /// Configura a propriedade <see cref="Gestor.Email"/> como obrigatória,
            /// com limite máximo de 100 caracteres.
            /// </summary>
            builder.Property(e => e.Email)
                   .IsRequired()
                   .HasMaxLength(100);

            /// <summary>
            /// Configura a propriedade <see cref="Gestor.Senha"/> como obrigatória.
            /// </summary>
            builder.Property(e => e.Senha)
                   .IsRequired();

            /// <summary>
            /// Cria um índice único para garantir que não existam dois gestores
            /// cadastrados com o mesmo e-mail.
            /// </summary>
            builder.HasIndex(g => g.Email)
                   .IsUnique();
        }
    }
}
