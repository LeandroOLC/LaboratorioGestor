using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LaboratorioGestor.Data.Migrations
{
    public partial class RecebimentosFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cobrancas_Servicos_IDServico",
                table: "Cobrancas");

            migrationBuilder.DropIndex(
                name: "IX_Cobrancas_IDServico",
                table: "Cobrancas");

            migrationBuilder.DropColumn(
                name: "IDServico",
                table: "Cobrancas");

            migrationBuilder.AddColumn<Guid>(
                name: "IDCobranca",
                table: "Servicos",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Servicos_Cobrancas_Id",
                table: "Servicos",
                column: "Id",
                principalTable: "Cobrancas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servicos_Cobrancas_Id",
                table: "Servicos");

            migrationBuilder.DropColumn(
                name: "IDCobranca",
                table: "Servicos");

            migrationBuilder.AddColumn<Guid>(
                name: "IDServico",
                table: "Cobrancas",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cobrancas_IDServico",
                table: "Cobrancas",
                column: "IDServico");

            migrationBuilder.AddForeignKey(
                name: "FK_Cobrancas_Servicos_IDServico",
                table: "Cobrancas",
                column: "IDServico",
                principalTable: "Servicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
