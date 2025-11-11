using Loop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Loop.Infra.Data.Configurations
{
    public class EstagiarioConfiguration : IEntityTypeConfiguration<Estagiario>
    {
        public void Configure(EntityTypeBuilder<Estagiario> builder)
        {

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Nome).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Email).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Senha).IsRequired();

            builder.HasMany(e => e.Frequencias)
                   .WithOne(f => f.Estagiario)
                   .HasForeignKey(f => f.EstagiarioId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(e => e.Email)
                   .IsUnique();
        }
    }
}
