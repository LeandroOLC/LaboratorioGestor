using LaboratorioGestor.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaboratorioGestor.Data.Mappings
{
    public class CobrancasMapping : IEntityTypeConfiguration<Cobrancas>
    {
        public void Configure(EntityTypeBuilder<Cobrancas> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(c => c.DataCadastro)
                .IsRequired()
                .HasColumnType("DateTime");

            builder.Property(c => c.ValorAcrecimo)
                .IsRequired()
                .HasColumnType("Float");

            builder.Property(c => c.ValorDesconto)
                .IsRequired()
                .HasColumnType("Float");

            builder.Property(c => c.ValorRecebimento)
                .HasColumnType("Float");

            builder.Property(c => c.ValorRestante)
                .IsRequired()
                .HasColumnType("Float");

            builder.Property(c => c.ValorTotal)
                .IsRequired()
                .HasColumnType("Float");

            builder.HasMany(e => e.Recebimentos)
                .WithOne(e => e.Cobrancas)
                .HasForeignKey(e => e.Id);

            builder.HasMany(e => e.Servicos)
                .WithOne(e => e.Cobrancas)
                .HasForeignKey(e => e.IDCobranca);

            builder.ToTable("Cobrancas");
        }
    }
}
