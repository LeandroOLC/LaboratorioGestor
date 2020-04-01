using LaboratorioGestor.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaboratorioGestor.Data.Mappings
{
    public class ServicosMapping : IEntityTypeConfiguration<Servicos>
    {
        public void Configure(EntityTypeBuilder<Servicos> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(e => e.NomePaciente)
              .HasColumnType("varchar(200)");

            builder.Property(e => e.Cor)
                .HasColumnType("varchar(200)");

            builder.Property(e => e.Observcao)
                 .HasColumnType("varchar(500)");

            builder.Property(e => e.IDCobranca)
                 .HasColumnType("UniqueIdentifier");

            //builder.HasMany(e => e.Cobrancas)
            //    .WithOne(e => e.Servicos)
            //    .HasForeignKey(e => e.IDServico);

            builder.ToTable("Servicos");
        }
    }
}
