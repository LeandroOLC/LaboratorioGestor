using Microsoft.EntityFrameworkCore.Migrations;

namespace LaboratorioGestor.Data.Migrations
{
    public partial class TabelaDentista : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CNPJ",
                table: "Dentistas");

            migrationBuilder.RenameColumn(
                name: "CPF",
                table: "Dentistas",
                newName: "Documento");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Documento",
                table: "Dentistas",
                newName: "CPF");

            migrationBuilder.AddColumn<string>(
                name: "CNPJ",
                table: "Dentistas",
                type: "varchar(30)",
                nullable: true);
        }
    }
}
