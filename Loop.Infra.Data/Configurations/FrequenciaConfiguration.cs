using Loop.Domain.Entities;
using Loop.Infra.Data.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Loop.Infra.Data.Configurations
{
    public class FrequenciaConfiguration : IEntityTypeConfiguration<Frequencia>
    {
        public void Configure(EntityTypeBuilder<Frequencia> builder)
        {
            builder.HasKey(f => f.Id);

            builder.Property(f => f.Data).IsRequired();

            builder.Property(f => f.HoraChegada)
                .HasConversion<TimeOnlyConverter>()
                   .HasColumnType("time")
                   .IsRequired();

            builder.Property(f => f.HoraSaida)
              .HasConversion<TimeOnlyConverter>()
                .HasColumnType("time")
                   .IsRequired(false);

            builder.HasOne<Estagiario>()
                   .WithMany()
                   .HasForeignKey(f => f.EstagiarioId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(f => new { f.EstagiarioId, f.Data })
                   .IsUnique();
        }
    }
}
