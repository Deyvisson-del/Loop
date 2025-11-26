using Loop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Loop.Infra.Data.Configurations
{

    public class FrequenciaConfiguration : IEntityTypeConfiguration<Frequencia>
    {

        public void Configure(EntityTypeBuilder<Frequencia> builder)
        {

            builder.ToTable("Frequencias");

            builder.HasKey(x => x.Id);

            builder.Property(f => f.Data)
                .HasColumnType("date")
                .IsRequired();

            builder.Property(f => f.HoraChegada)
                .HasColumnType("time")
                .IsRequired(false);

            builder.Property(f => f.HoraSaida)
                .HasColumnType("time")
                .IsRequired(false);

            builder.Property(f => f.HorasTrabalhadas)
                .HasColumnType("float")
                .IsRequired();

            builder.HasOne(f => f.Estagiario)
                .WithMany(e => e.Frequencias)
                .HasForeignKey(f => f.EstagiarioId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
