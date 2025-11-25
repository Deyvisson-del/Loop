using Loop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Loop.Infra.Data.Configurations
{
    
    public class GestorConfiguration : IEntityTypeConfiguration<Gestor>
    {
        
        public void Configure(EntityTypeBuilder<Gestor> builder)
        {
            builder.ToTable("Gestores");
                
        }
    }
}
