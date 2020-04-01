using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LaboratorioGestor.Data.Migrations
{
    public partial class AtualizacaoDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HaverContasAReceber");

            migrationBuilder.DropTable(
                name: "ContasAReceber");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataDoCadastro",
                table: "Proteticos",
                type: "DateTime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "DateTime");

            migrationBuilder.CreateTable(
                name: "Cobrancas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "DateTime", nullable: false),
                    ValorDesconto = table.Column<double>(type: "Float", nullable: false),
                    ValorAcrecimo = table.Column<double>(type: "Float", nullable: false),
                    ValorTotal = table.Column<double>(type: "Float", nullable: false),
                    IDDentista = table.Column<Guid>(nullable: false),
                    ValorRecebimento = table.Column<double>(type: "Float", nullable: true),
                    ValorRestante = table.Column<double>(type: "Float", nullable: false),
                    IDServico = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cobrancas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cobrancas_Servicos_IDServico",
                        column: x => x.IDServico,
                        principalTable: "Servicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Recebimentos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    TipoRecebimento = table.Column<string>(type: "varchar(1)", nullable: false),
                    Valor = table.Column<string>(type: "varchar(80)", nullable: false),
                    IDCobrancas = table.Column<Guid>(nullable: true),
                    IDUsuarios = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recebimentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recebimentos_Cobrancas_Id",
                        column: x => x.Id,
                        principalTable: "Cobrancas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cobrancas_IDServico",
                table: "Cobrancas",
                column: "IDServico");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recebimentos");

            migrationBuilder.DropTable(
                name: "Cobrancas");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataDoCadastro",
                table: "Proteticos",
                type: "DateTime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ContasAReceber",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "DateTime", nullable: false),
                    IDDentista = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDServico = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ValorAcrecimo = table.Column<double>(type: "Float", nullable: false),
                    ValorDesconto = table.Column<double>(type: "Float", nullable: false),
                    ValorHaver = table.Column<double>(type: "Float", nullable: true),
                    ValorRestante = table.Column<double>(type: "Float", nullable: false),
                    ValorTotal = table.Column<double>(type: "Float", nullable: false)
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
                name: "HaverContasAReceber",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IDContasAReceber = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IDUsuarios = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoHaver = table.Column<string>(type: "varchar(1)", nullable: false),
                    Valor = table.Column<string>(type: "varchar(80)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HaverContasAReceber", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HaverContasAReceber_ContasAReceber_IDContasAReceber",
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
                name: "IX_HaverContasAReceber_IDContasAReceber",
                table: "HaverContasAReceber",
                column: "IDContasAReceber");
        }
    }
}
