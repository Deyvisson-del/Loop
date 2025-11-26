using Loop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Loop.Infra.Data.Configurations
{
    public class SolicitacoesConfiguration
    {
        public void Configure(EntityTypeBuilder<Solicitacao> builder)
        {
            builder.ToTable("Solicitacoes");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Justificativa)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(s => s.DataSolicitacao)
                .IsRequired();

            builder.Property(e => e.Status)
                .IsRequired();

            builder.Property(s => s.HorarioEntrada)
                .IsRequired(false);

            builder.Property(s => s.HorarioSaida)
                .IsRequired(false);

            builder.Property(s => s.RespostaGestor)
                .HasMaxLength(500);

            builder.Property(s => s.RespostaData)
                .IsRequired(false);

            builder.Property(s => s.EstagiarioId)
                .IsRequired();

            builder.Property(s => s.FrequenciaId)
                .IsRequired();
        }
    }
}
