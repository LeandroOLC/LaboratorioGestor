using Microsoft.EntityFrameworkCore.Migrations;

namespace LaboratorioGestor.Data.Migrations
{
    public partial class AtualizarDocumento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CNPJ",
                table: "Laboratorios");

            migrationBuilder.RenameColumn(
                name: "CPF",
                table: "Laboratorios",
                newName: "Documento");

            migrationBuilder.AlterColumn<string>(
                name: "Documento",
                table: "Dentistas",
                type: "varchar(30)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Documento",
                table: "Laboratorios",
                newName: "CPF");

            migrationBuilder.AddColumn<string>(
                name: "CNPJ",
                table: "Laboratorios",
                type: "varchar(30)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Documento",
                table: "Dentistas",
                type: "varchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldNullable: true);
        }
    }
}
