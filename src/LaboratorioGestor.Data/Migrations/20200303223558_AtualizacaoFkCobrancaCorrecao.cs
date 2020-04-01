using Microsoft.EntityFrameworkCore.Migrations;

namespace LaboratorioGestor.Data.Migrations
{
    public partial class AtualizacaoFkCobrancaCorrecao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servicos_Cobrancas_Id",
                table: "Servicos");

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_IDCobranca",
                table: "Servicos",
                column: "IDCobranca");

            migrationBuilder.AddForeignKey(
                name: "FK_Servicos_Cobrancas_IDCobranca",
                table: "Servicos",
                column: "IDCobranca",
                principalTable: "Cobrancas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servicos_Cobrancas_IDCobranca",
                table: "Servicos");

            migrationBuilder.DropIndex(
                name: "IX_Servicos_IDCobranca",
                table: "Servicos");

            migrationBuilder.AddForeignKey(
                name: "FK_Servicos_Cobrancas_Id",
                table: "Servicos",
                column: "Id",
                principalTable: "Cobrancas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
