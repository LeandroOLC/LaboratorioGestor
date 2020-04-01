using Microsoft.EntityFrameworkCore.Migrations;

namespace LaboratorioGestor.Data.Migrations
{
    public partial class CorrecaoProdutos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servicos_Laboratorio_IDProduto",
                table: "Servicos");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Servicos_Produtos_IDProduto",
                table: "Servicos",
                column: "IDProduto",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servicos_Produtos_IDProduto",
                table: "Servicos");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Servicos_Laboratorio_IDProduto",
                table: "Servicos",
                column: "IDProduto",
                principalTable: "Laboratorio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
