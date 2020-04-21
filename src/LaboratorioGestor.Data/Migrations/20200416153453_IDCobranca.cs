using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LaboratorioGestor.Data.Migrations
{
    public partial class IDCobranca : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recebimentos_Cobrancas_IDCobrancas",
                table: "Recebimentos");

            migrationBuilder.DropIndex(
                name: "IX_Recebimentos_IDCobrancas",
                table: "Recebimentos");

            migrationBuilder.DropColumn(
                name: "IDCobrancas",
                table: "Recebimentos");

            migrationBuilder.AddColumn<Guid>(
                name: "IDCobranca",
                table: "Recebimentos",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Recebimentos_IDCobranca",
                table: "Recebimentos",
                column: "IDCobranca");

            migrationBuilder.AddForeignKey(
                name: "FK_Recebimentos_Cobrancas_IDCobranca",
                table: "Recebimentos",
                column: "IDCobranca",
                principalTable: "Cobrancas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recebimentos_Cobrancas_IDCobranca",
                table: "Recebimentos");

            migrationBuilder.DropIndex(
                name: "IX_Recebimentos_IDCobranca",
                table: "Recebimentos");

            migrationBuilder.DropColumn(
                name: "IDCobranca",
                table: "Recebimentos");

            migrationBuilder.AddColumn<Guid>(
                name: "IDCobrancas",
                table: "Recebimentos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Recebimentos_IDCobrancas",
                table: "Recebimentos",
                column: "IDCobrancas");

            migrationBuilder.AddForeignKey(
                name: "FK_Recebimentos_Cobrancas_IDCobrancas",
                table: "Recebimentos",
                column: "IDCobrancas",
                principalTable: "Cobrancas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
