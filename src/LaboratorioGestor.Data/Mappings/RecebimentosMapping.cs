using LaboratorioGestor.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaboratorioGestor.Data.Mappings
{
    public class RecebimentosMapping : IEntityTypeConfiguration<Recebimentos>
    {
        public void Configure(EntityTypeBuilder<Recebimentos> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(c => c.TipoRecebimento)
             .HasColumnType("varchar(1)");

            builder.Property(c => c.DataCadastro)
              .HasColumnType("DateTime");

            builder.Property(c => c.Valor)
             .HasColumnType("float");

            builder.ToTable("Recebimentos");
        }
    }
}
