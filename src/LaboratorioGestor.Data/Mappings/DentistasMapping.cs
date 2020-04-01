using LaboratorioGestor.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaboratorioGestor.Data.Mappings
{
    public class DentistasMapping : IEntityTypeConfiguration<Dentistas>
    {
        public void Configure(EntityTypeBuilder<Dentistas> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(c => c.Documento)
             .HasColumnType("varchar(30)");

            builder.Property(c => c.DataDoCadastro)
             .HasColumnType("DateTime");

            builder.Property(c => c.CRO)
             .HasColumnType("varchar(10)");

            builder.Property(c => c.Nome)
             .HasColumnType("varchar(60)");

            builder.Property(c => c.NomeDaClinica)
             .HasColumnType("varchar(60)");

            builder.Property(c => c.TipoPessoa)
             .IsFixedLength()
             .HasColumnType("int");

            builder.HasMany(e => e.Servicos)
              .WithOne(e => e.Dentistas)
              .HasForeignKey(e => e.IDDentista);

            builder.ToTable("Dentistas");

        }
    }
}
