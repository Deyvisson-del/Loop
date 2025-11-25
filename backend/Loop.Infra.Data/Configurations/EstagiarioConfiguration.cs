using Loop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Loop.Infra.Data.Configurations
{
 
    public class EstagiarioConfiguration : IEntityTypeConfiguration<Estagiario>
    {
        
        public void Configure(EntityTypeBuilder<Estagiario> builder)
        {
            builder.ToTable("Estagiarios");

            builder.HasMany(e => e.Frequencias)
                .WithOne(f => f.Estagiario)
                .HasForeignKey(f => f.EstagiarioId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
