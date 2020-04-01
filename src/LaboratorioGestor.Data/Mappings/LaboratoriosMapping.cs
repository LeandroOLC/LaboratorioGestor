using LaboratorioGestor.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaboratorioGestor.Data.Mappings
{
    public class LaboratoriosMapping : IEntityTypeConfiguration<Laboratorios>
    {
        public void Configure(EntityTypeBuilder<Laboratorios> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(e => e.Nome)
              .HasColumnType("varchar(100)");

            builder.Property(e => e.Proprietario)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.TPO)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.Documento)
                .HasColumnType("varchar(30)");

            builder.Property(e => e.TipoPessoa)
                .HasColumnType("varchar(2)");

            builder.Property(e => e.DataDoCadastro)
                .HasColumnType("DateTime");

            builder.ToTable("Laboratorios");
        }
    }
}
