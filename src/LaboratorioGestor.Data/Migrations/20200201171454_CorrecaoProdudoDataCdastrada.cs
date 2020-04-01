using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LaboratorioGestor.Data.Migrations
{
    public partial class CorrecaoProdudoDataCdastrada : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataDoCadastro",
                table: "Produtos",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataDoCadastro",
                table: "Laboratorios",
                type: "DateTime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataDoCadastro",
                table: "Produtos");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataDoCadastro",
                table: "Laboratorios",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true);
        }
    }
}
