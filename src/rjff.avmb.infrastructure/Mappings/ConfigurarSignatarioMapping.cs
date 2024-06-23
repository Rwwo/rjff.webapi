using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using rjff.avmb.core.InputModels;
using rjff.avmb.core.Models;

namespace rjff.avmb.infrastructure.Mappings
{
    public class ConfigurarSignatarioMapping : IEntityTypeConfiguration<ConfigurarSignatario>
    {
        public void Configure(EntityTypeBuilder<ConfigurarSignatario> builder)
        {

            // Chave primária
            builder
                .HasKey(t => t.Id);

            builder
                .Property(r => r.@params)
                .HasConversion(new JsonValueConverter<ParamsConfigurarSignatarioInputModel>());

            builder.ToTable("configurarsignatario");
        }
    }
}
