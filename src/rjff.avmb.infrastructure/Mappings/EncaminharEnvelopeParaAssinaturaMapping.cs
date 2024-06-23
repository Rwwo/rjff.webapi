using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using rjff.avmb.core.InputModels;
using rjff.avmb.core.Models;

namespace rjff.avmb.infrastructure.Mappings
{
    public class EncaminharEnvelopeParaAssinaturaMapping : IEntityTypeConfiguration<EncaminharEnvelopeParaAssinatura>
    {
        public void Configure(EntityTypeBuilder<EncaminharEnvelopeParaAssinatura> builder)
        {

            // Chave primária
            builder
                .HasKey(t => t.Id);

            builder
                .Property(r => r.@params)
                .HasConversion(new JsonValueConverter<ParamsEncaminharEnvelopeParaAssinaturaInputModel>());

            builder.ToTable("encaminhadosassinar");
        }
    }
}
