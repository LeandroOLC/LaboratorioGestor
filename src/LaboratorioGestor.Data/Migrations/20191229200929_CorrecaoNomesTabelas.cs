using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LaboratorioGestor.Data.Migrations
{
    public partial class CorrecaoNomesTabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servicos_Produtos_IDProduto",
                table: "Servicos");

            migrationBuilder.DropTable(
                name: "HaverContasApagar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Produtos",
                table: "Produtos");

            migrationBuilder.RenameTable(
                name: "Produtos",
                newName: "Laboratorio");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Laboratorio",
                table: "Laboratorio",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "HaverContasAReceber",
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
                    table.PrimaryKey("PK_HaverContasAReceber", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HaverContasAReceber_ContasAReceber_IDContasAReceber",
                        column: x => x.IDContasAReceber,
                        principalTable: "ContasAReceber",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HaverContasAReceber_IDContasAReceber",
                table: "HaverContasAReceber",
                column: "IDContasAReceber");

            migrationBuilder.AddForeignKey(
                name: "FK_Servicos_Laboratorio_IDProduto",
                table: "Servicos",
                column: "IDProduto",
                principalTable: "Laboratorio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servicos_Laboratorio_IDProduto",
                table: "Servicos");

            migrationBuilder.DropTable(
                name: "HaverContasAReceber");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Laboratorio",
                table: "Laboratorio");

            migrationBuilder.RenameTable(
                name: "Laboratorio",
                newName: "Produtos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produtos",
                table: "Produtos",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "HaverContasApagar",
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
                    table.PrimaryKey("PK_HaverContasApagar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HaverContasApagar_ContasAReceber_IDContasAReceber",
                        column: x => x.IDContasAReceber,
                        principalTable: "ContasAReceber",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HaverContasApagar_IDContasAReceber",
                table: "HaverContasApagar",
                column: "IDContasAReceber");

            migrationBuilder.AddForeignKey(
                name: "FK_Servicos_Produtos_IDProduto",
                table: "Servicos",
                column: "IDProduto",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
