using LaboratorioGestor.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaboratorioGestor.Data.Mappings
{
    public class ProdutosMapping : IEntityTypeConfiguration<Produtos>
    {
        public void Configure(EntityTypeBuilder<Produtos> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(e => e.Nome)
                .HasColumnType("varchar(200)");

            builder.Property(e => e.Valor)
                .HasColumnType("float");

            builder.Property(e => e.DataDoCadastro)
                   .HasColumnType("DateTime");

            builder.HasMany(e => e.Servicos)
                .WithOne(e => e.Produtos)
                .HasForeignKey(e => e.IDProduto);

            builder.ToTable("Produtos");
        }
    }
}
