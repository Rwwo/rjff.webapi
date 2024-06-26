﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using rjff.avmb.core.InputModels;
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
                .Property(r => r.@params)
                .HasConversion(new JsonValueConverter<ParamsCriarEnvelopeInputModel>());

            builder.ToTable("criarenvelope");
        }
    }
}
