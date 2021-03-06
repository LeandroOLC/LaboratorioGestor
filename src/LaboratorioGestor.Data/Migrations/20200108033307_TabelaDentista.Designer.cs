﻿// <auto-generated />
using System;
using LaboratorioGestor.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LaboratorioGestor.Data.Migrations
{
    [DbContext(typeof(MeuDbContext))]
    [Migration("20200108033307_TabelaDentista")]
    partial class TabelaDentista
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LaboratorioGestor.Business.Models.ContasAReceber", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("DateTime");

                    b.Property<Guid>("IDDentista")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IDServico")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double?>("ValorAcrecimo")
                        .IsRequired()
                        .HasColumnType("Float");

                    b.Property<double?>("ValorDesconto")
                        .IsRequired()
                        .HasColumnType("Float");

                    b.Property<double?>("ValorHaver")
                        .HasColumnType("Float");

                    b.Property<double?>("ValorRestante")
                        .IsRequired()
                        .HasColumnType("Float");

                    b.Property<double>("ValorTotal")
                        .HasColumnType("Float");

                    b.HasKey("Id");

                    b.HasIndex("IDServico");

                    b.ToTable("ContasAReceber");
                });

            modelBuilder.Entity("LaboratorioGestor.Business.Models.Contatos", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Celular")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("CelularWhatApp")
                        .HasColumnType("varchar(30)");

                    b.Property<DateTime>("DataDoCadastro")
                        .HasColumnType("DateTime");

                    b.Property<Guid>("DentistaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(80)");

                    b.Property<string>("Fone1")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Fone2")
                        .HasColumnType("varchar(30)");

                    b.Property<Guid>("LaboratorioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProteticoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("TipoContato")
                        .HasColumnType("int")
                        .IsFixedLength(true);

                    b.HasKey("Id");

                    b.ToTable("Contatos");
                });

            modelBuilder.Entity("LaboratorioGestor.Business.Models.Dentistas", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CRO")
                        .HasColumnType("varchar(10)");

                    b.Property<DateTime?>("DataDoCadastro")
                        .HasColumnType("DateTime");

                    b.Property<string>("Documento")
                        .HasColumnType("varchar(50)");

                    b.Property<Guid?>("IDContato")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IDEndereco")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(60)");

                    b.Property<string>("NomeDaClinica")
                        .HasColumnType("varchar(60)");

                    b.Property<int>("TipoPessoa")
                        .HasColumnType("int")
                        .IsFixedLength(true);

                    b.HasKey("Id");

                    b.HasIndex("IDContato");

                    b.HasIndex("IDEndereco");

                    b.ToTable("Dentistas");
                });

            modelBuilder.Entity("LaboratorioGestor.Business.Models.Enderecos", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Bairro")
                        .HasColumnType("varchar(80)");

                    b.Property<string>("Cidade")
                        .HasColumnType("varchar(80)");

                    b.Property<DateTime>("DataDoCadastro")
                        .HasColumnType("DateTime");

                    b.Property<Guid>("DentistaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Endereco")
                        .HasColumnType("varchar(100)");

                    b.Property<Guid>("LaboratorioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Numero")
                        .HasColumnType("varchar(30)");

                    b.Property<Guid>("ProteticoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ReferenciaDoEndereco")
                        .HasColumnType("varchar(500)");

                    b.Property<int>("TipoEndereco")
                        .HasColumnType("int");

                    b.Property<string>("UF")
                        .HasColumnType("varchar(2)");

                    b.HasKey("Id");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("LaboratorioGestor.Business.Models.HaverContasAReceber", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("IDContasAReceber")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IDUsuarios")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TipoHaver")
                        .IsRequired()
                        .HasColumnType("varchar(1)");

                    b.Property<string>("Valor")
                        .IsRequired()
                        .HasColumnType("varchar(80)");

                    b.HasKey("Id");

                    b.HasIndex("IDContasAReceber");

                    b.ToTable("HaverContasAReceber");
                });

            modelBuilder.Entity("LaboratorioGestor.Business.Models.Laboratorios", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CNPJ")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("CPF")
                        .HasColumnType("varchar(30)");

                    b.Property<DateTime?>("DataDoCadastro")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("IDContato")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IDEndereco")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Proprietario")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("TPO")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("TipoPessoa")
                        .IsRequired()
                        .HasColumnType("varchar(2)");

                    b.HasKey("Id");

                    b.HasIndex("IDContato");

                    b.HasIndex("IDEndereco");

                    b.ToTable("Laboratorios");
                });

            modelBuilder.Entity("LaboratorioGestor.Business.Models.Produtos", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(200)");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("LaboratorioGestor.Business.Models.Proteticos", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CPF")
                        .HasColumnType("varchar(30)");

                    b.Property<DateTime?>("DataDoCadastro")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("IDContato")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IDEndereco")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(200)");

                    b.Property<double>("PercentualDaComissao")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("IDContato");

                    b.HasIndex("IDEndereco");

                    b.ToTable("Proteticos");
                });

            modelBuilder.Entity("LaboratorioGestor.Business.Models.Servicos", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cor")
                        .HasColumnType("varchar(200)");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataEntrada")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataEntrega")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("IDDentista")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IDPaciente")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IDProduto")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IDProtetico")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double?>("Idade")
                        .HasColumnType("float");

                    b.Property<string>("NomePaciente")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Observcao")
                        .HasColumnType("varchar(500)");

                    b.Property<double?>("Quantidade")
                        .HasColumnType("float");

                    b.Property<double?>("ReferenciaOS")
                        .HasColumnType("float");

                    b.Property<double?>("Valor")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("IDDentista");

                    b.HasIndex("IDProduto");

                    b.HasIndex("IDProtetico");

                    b.ToTable("Servicos");
                });

            modelBuilder.Entity("LaboratorioGestor.Business.Models.ContasAReceber", b =>
                {
                    b.HasOne("LaboratorioGestor.Business.Models.Servicos", "Servicos")
                        .WithMany("ContasAReceber")
                        .HasForeignKey("IDServico");
                });

            modelBuilder.Entity("LaboratorioGestor.Business.Models.Dentistas", b =>
                {
                    b.HasOne("LaboratorioGestor.Business.Models.Contatos", "Contatos")
                        .WithMany("Dentistas")
                        .HasForeignKey("IDContato");

                    b.HasOne("LaboratorioGestor.Business.Models.Enderecos", "Enderecos")
                        .WithMany("Dentistas")
                        .HasForeignKey("IDEndereco");
                });

            modelBuilder.Entity("LaboratorioGestor.Business.Models.HaverContasAReceber", b =>
                {
                    b.HasOne("LaboratorioGestor.Business.Models.ContasAReceber", "ContasAReceber")
                        .WithMany("HaverContasApagar")
                        .HasForeignKey("IDContasAReceber");
                });

            modelBuilder.Entity("LaboratorioGestor.Business.Models.Laboratorios", b =>
                {
                    b.HasOne("LaboratorioGestor.Business.Models.Contatos", "Contatos")
                        .WithMany("Laboratorios")
                        .HasForeignKey("IDContato");

                    b.HasOne("LaboratorioGestor.Business.Models.Enderecos", "Enderecos")
                        .WithMany("Laboratorios")
                        .HasForeignKey("IDEndereco");
                });

            modelBuilder.Entity("LaboratorioGestor.Business.Models.Proteticos", b =>
                {
                    b.HasOne("LaboratorioGestor.Business.Models.Contatos", "Contatos")
                        .WithMany("Proteticos")
                        .HasForeignKey("IDContato");

                    b.HasOne("LaboratorioGestor.Business.Models.Enderecos", "Enderecos")
                        .WithMany("Proteticos")
                        .HasForeignKey("IDEndereco");
                });

            modelBuilder.Entity("LaboratorioGestor.Business.Models.Servicos", b =>
                {
                    b.HasOne("LaboratorioGestor.Business.Models.Dentistas", "Dentistas")
                        .WithMany("Servicos")
                        .HasForeignKey("IDDentista")
                        .IsRequired();

                    b.HasOne("LaboratorioGestor.Business.Models.Produtos", "Produtos")
                        .WithMany("Servicos")
                        .HasForeignKey("IDProduto")
                        .IsRequired();

                    b.HasOne("LaboratorioGestor.Business.Models.Proteticos", "Proteticos")
                        .WithMany("Servicos")
                        .HasForeignKey("IDProtetico")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
