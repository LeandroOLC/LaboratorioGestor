using LaboratorioGestor.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaboratorioGestor.Data.Mappings
{
    public class EnderecosMapping : IEntityTypeConfiguration<Enderecos>
    {
        public void Configure(EntityTypeBuilder<Enderecos> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(c => c.Bairro)
              .HasColumnType("varchar(80)");

            builder.Property(c => c.Cidade)
             .HasColumnType("varchar(80)");

            builder.Property(c => c.DataDoCadastro)
             .HasColumnType("DateTime");

            builder.Property(c => c.Endereco)
             .HasColumnType("varchar(100)");

            builder.Property(c => c.Numero)
             .HasColumnType("varchar(30)");

            builder.Property(c => c.ReferenciaDoEndereco)
                .HasColumnType("varchar(500)");

            builder.Property(c => c.TipoEndereco)
                .HasColumnType("int");

            builder.Property(c => c.UF)
              .HasColumnType("varchar(2)");

            builder.HasMany(e => e.Dentistas)
                        .WithOne(e => e.Enderecos)
                        .HasForeignKey(e => e.IDEndereco);

            builder.HasMany(e => e.Laboratorios)
                .WithOne(e => e.Enderecos)
                .HasForeignKey(e => e.IDEndereco);

            builder.HasMany(e => e.Proteticos)
                .WithOne(e => e.Enderecos)
                .HasForeignKey(e => e.IDEndereco);

            builder.ToTable("Enderecos");
        }
    }
}
