using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LaboratorioGestor.Data.Migrations
{
    public partial class AddRecebimentos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recebimentos_Cobrancas_Id",
                table: "Recebimentos");

            migrationBuilder.DropColumn(
                name: "IDUsuarios",
                table: "Recebimentos");

            migrationBuilder.AlterColumn<double>(
                name: "Valor",
                table: "Recebimentos",
                type: "float",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(80)");

            migrationBuilder.AlterColumn<Guid>(
                name: "IDCobrancas",
                table: "Recebimentos",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCadastro",
                table: "Recebimentos",
                type: "DateTime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<Guid>(
                name: "IDProtetico",
                table: "Recebimentos",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "IDDentista",
                table: "Cobrancas",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Recebimentos_IDCobrancas",
                table: "Recebimentos",
                column: "IDCobrancas");

            migrationBuilder.CreateIndex(
                name: "IX_Recebimentos_IDProtetico",
                table: "Recebimentos",
                column: "IDProtetico");

            migrationBuilder.AddForeignKey(
                name: "FK_Recebimentos_Cobrancas_IDCobrancas",
                table: "Recebimentos",
                column: "IDCobrancas",
                principalTable: "Cobrancas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Recebimentos_Proteticos_IDProtetico",
                table: "Recebimentos",
                column: "IDProtetico",
                principalTable: "Proteticos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recebimentos_Cobrancas_IDCobrancas",
                table: "Recebimentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Recebimentos_Proteticos_IDProtetico",
                table: "Recebimentos");

            migrationBuilder.DropIndex(
                name: "IX_Recebimentos_IDCobrancas",
                table: "Recebimentos");

            migrationBuilder.DropIndex(
                name: "IX_Recebimentos_IDProtetico",
                table: "Recebimentos");

            migrationBuilder.DropColumn(
                name: "IDProtetico",
                table: "Recebimentos");

            migrationBuilder.AlterColumn<string>(
                name: "Valor",
                table: "Recebimentos",
                type: "varchar(80)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<Guid>(
                name: "IDCobrancas",
                table: "Recebimentos",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCadastro",
                table: "Recebimentos",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DateTime");

            migrationBuilder.AddColumn<Guid>(
                name: "IDUsuarios",
                table: "Recebimentos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "IDDentista",
                table: "Cobrancas",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Recebimentos_Cobrancas_Id",
                table: "Recebimentos",
                column: "Id",
                principalTable: "Cobrancas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
