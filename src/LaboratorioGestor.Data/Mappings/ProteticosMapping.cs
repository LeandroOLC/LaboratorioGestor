using LaboratorioGestor.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaboratorioGestor.Data.Mappings
{
    public class ProteticosMapping : IEntityTypeConfiguration<Proteticos>
    {
        public void Configure(EntityTypeBuilder<Proteticos> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(e => e.Nome)
            .HasColumnType("varchar(200)");

            builder.Property(e => e.CPF)
              .HasColumnType("varchar(30)");

            builder.Property(c => c.DataDoCadastro)
                    .HasColumnType("DateTime");

            builder.HasMany(e => e.Servicos)
                .WithOne(e => e.Proteticos)
                .HasForeignKey(e => e.IDProtetico);

            builder.HasMany(e => e.Recebimentos)
             .WithOne(e => e.Proteticos)
             .HasForeignKey(e => e.IDProtetico);

            builder.ToTable("Proteticos");
        }
    }
}
