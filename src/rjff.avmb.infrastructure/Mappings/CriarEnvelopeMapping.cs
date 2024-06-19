using System.Reflection.Emit;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;

using rjff.avmb.core.InputModels;
using rjff.avmb.core.Interfaces;
using rjff.avmb.core.Models;

namespace rjff.avmb.infrastructure.Mappings
{
    public class CriarEnvelopeMapping : IEntityTypeConfiguration<CriarEnvelope>
    {
        public void Configure(EntityTypeBuilder<CriarEnvelope> builder)
        {

            // Chave primária
            builder
                .HasKey(t => t.Id);


            builder
                .Property(r => r.Params)
                .HasConversion(new JsonValueConverter<CriarEnvelopeInputModel>());

            builder.ToTable("criarenvelope");
        }
    }

    public class JsonValueConverter<T> : ValueConverter<T, string>
    {
        public JsonValueConverter() : base(
            v => JsonConvert.SerializeObject(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
            v => JsonConvert.DeserializeObject<T>(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }))
        {
        }
    }
}
