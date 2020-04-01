using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LaboratorioGestor.Data.Migrations
{
    public partial class InitialCreateTabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contatos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Fone1 = table.Column<string>(type: "varchar(30)", nullable: true),
                    Fone2 = table.Column<string>(type: "varchar(30)", nullable: true),
                    Celular = table.Column<string>(type: "varchar(30)", nullable: true),
                    CelularWhatApp = table.Column<string>(type: "varchar(30)", nullable: true),
                    DataDoCadastro = table.Column<DateTime>(type: "DateTime", nullable: false),
                    TipoContato = table.Column<int>(type: "int", fixedLength: true, nullable: false),
                    Email = table.Column<string>(type: "varchar(80)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contatos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Endereco = table.Column<string>(type: "varchar(100)", nullable: true),
                    Numero = table.Column<string>(type: "varchar(30)", nullable: true),
                    Bairro = table.Column<string>(type: "varchar(80)", nullable: true),
                    UF = table.Column<string>(type: "varchar(2)", nullable: true),
                    Cidade = table.Column<string>(type: "varchar(80)", nullable: true),
                    ReferenciaDoEndereco = table.Column<string>(type: "varchar(500)", nullable: true),
                    DataDoCadastro = table.Column<DateTime>(type: "DateTime", nullable: false),
                    TipoEndereco = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: true),
                    Valor = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dentistas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(60)", nullable: true),
                    NomeDaClinica = table.Column<string>(type: "varchar(60)", nullable: true),
                    DataDoCadastro = table.Column<DateTime>(type: "DateTime", nullable: true),
                    CRO = table.Column<string>(type: "varchar(10)", nullable: true),
                    CPF = table.Column<string>(type: "varchar(50)", nullable: true),
                    CNPJ = table.Column<string>(type: "varchar(30)", nullable: true),
                    TipoPessoa = table.Column<int>(type: "int", fixedLength: true, nullable: false),
                    IDEndereco = table.Column<Guid>(nullable: true),
                    IDContato = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dentistas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dentistas_Contatos_IDContato",
                        column: x => x.IDContato,
                        principalTable: "Contatos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Dentistas_Enderecos_IDEndereco",
                        column: x => x.IDEndereco,
                        principalTable: "Enderecos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Laboratorios",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: true),
                    Proprietario = table.Column<string>(type: "varchar(100)", nullable: true),
                    TPO = table.Column<string>(type: "varchar(50)", nullable: true),
                    CPF = table.Column<string>(type: "varchar(30)", nullable: true),
                    CNPJ = table.Column<string>(type: "varchar(30)", nullable: true),
                    TipoPessoa = table.Column<string>(type: "varchar(2)", nullable: false),
                    DataDoCadastro = table.Column<DateTime>(nullable: true),
                    IDEndereco = table.Column<Guid>(nullable: true),
                    IDContato = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laboratorios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Laboratorios_Contatos_IDContato",
                        column: x => x.IDContato,
                        principalTable: "Contatos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Laboratorios_Enderecos_IDEndereco",
                        column: x => x.IDEndereco,
                        principalTable: "Enderecos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Proteticos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: true),
                    PercentualDaComissao = table.Column<double>(nullable: false),
                    DataDoCadastro = table.Column<DateTime>(nullable: true),
                    CPF = table.Column<string>(type: "varchar(30)", nullable: true),
                    IDContato = table.Column<Guid>(nullable: true),
                    IDEndereco = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proteticos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proteticos_Contatos_IDContato",
                        column: x => x.IDContato,
                        principalTable: "Contatos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Proteticos_Enderecos_IDEndereco",
                        column: x => x.IDEndereco,
                        principalTable: "Enderecos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Servicos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    Idade = table.Column<double>(nullable: true),
                    NomePaciente = table.Column<string>(type: "varchar(200)", nullable: true),
                    Cor = table.Column<string>(type: "varchar(200)", nullable: true),
                    DataEntrada = table.Column<DateTime>(nullable: true),
                    DataEntrega = table.Column<DateTime>(nullable: true),
                    ReferenciaOS = table.Column<double>(nullable: true),
                    Quantidade = table.Column<double>(nullable: true),
                    Valor = table.Column<double>(nullable: true),
                    Observcao = table.Column<string>(type: "varchar(500)", nullable: true),
                    IDProduto = table.Column<Guid>(nullable: false),
                    IDProtetico = table.Column<Guid>(nullable: false),
                    IDDentista = table.Column<Guid>(nullable: false),
                    IDPaciente = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Servicos_Dentistas_IDDentista",
                        column: x => x.IDDentista,
                        principalTable: "Dentistas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Servicos_Produtos_IDProduto",
                        column: x => x.IDProduto,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Servicos_Proteticos_IDProtetico",
                        column: x => x.IDProtetico,
                        principalTable: "Proteticos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContasAReceber",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "DateTime", nullable: false),
                    ValorDesconto = table.Column<double>(type: "Float", nullable: false),
                    ValorAcrecimo = table.Column<double>(type: "Float", nullable: false),
                    ValorTotal = table.Column<double>(type: "Float", nullable: false),
                    IDDentista = table.Column<Guid>(nullable: false),
                    ValorHaver = table.Column<double>(type: "Float", nullable: true),
                    ValorRestante = table.Column<double>(type: "Float", nullable: false),
                    IDServico = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContasAReceber", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContasAReceber_Servicos_IDServico",
                        column: x => x.IDServico,
                        principalTable: "Servicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HaverContasApagar",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    TipoHaver = table.Column<string>(type: "varchar(1)", nullable: false),
                    Valor = table.Column<string>(type: "varchar(80)", nullable: false),
                    IDContasAReceber = table.Column<Guid>(nullable: true),
                    IDUsuarios = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HaverContasApagar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HaverContasApagar_ContasAReceber_IDContasAReceber",
                        column: x => x.IDContasAReceber,
                        principalTable: "ContasAReceber",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContasAReceber_IDServico",
                table: "ContasAReceber",
                column: "IDServico");

            migrationBuilder.CreateIndex(
                name: "IX_Dentistas_IDContato",
                table: "Dentistas",
                column: "IDContato");

            migrationBuilder.CreateIndex(
                name: "IX_Dentistas_IDEndereco",
                table: "Dentistas",
                column: "IDEndereco");

            migrationBuilder.CreateIndex(
                name: "IX_HaverContasApagar_IDContasAReceber",
                table: "HaverContasApagar",
                column: "IDContasAReceber");

            migrationBuilder.CreateIndex(
                name: "IX_Laboratorios_IDContato",
                table: "Laboratorios",
                column: "IDContato");

            migrationBuilder.CreateIndex(
                name: "IX_Laboratorios_IDEndereco",
                table: "Laboratorios",
                column: "IDEndereco");

            migrationBuilder.CreateIndex(
                name: "IX_Proteticos_IDContato",
                table: "Proteticos",
                column: "IDContato");

            migrationBuilder.CreateIndex(
                name: "IX_Proteticos_IDEndereco",
                table: "Proteticos",
                column: "IDEndereco");

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_IDDentista",
                table: "Servicos",
                column: "IDDentista");

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_IDProduto",
                table: "Servicos",
                column: "IDProduto");

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_IDProtetico",
                table: "Servicos",
                column: "IDProtetico");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HaverContasApagar");

            migrationBuilder.DropTable(
                name: "Laboratorios");

            migrationBuilder.DropTable(
                name: "ContasAReceber");

            migrationBuilder.DropTable(
                name: "Servicos");

            migrationBuilder.DropTable(
                name: "Dentistas");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Proteticos");

            migrationBuilder.DropTable(
                name: "Contatos");

            migrationBuilder.DropTable(
                name: "Enderecos");
        }
    }
}
