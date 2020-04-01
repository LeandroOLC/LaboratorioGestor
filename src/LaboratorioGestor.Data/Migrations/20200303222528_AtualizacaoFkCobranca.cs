using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LaboratorioGestor.Data.Migrations
{
    public partial class AtualizacaoFkCobranca : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IDPaciente",
                table: "Servicos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IDPaciente",
                table: "Servicos",
                type: "uniqueidentifier",
                nullable: true);
        }
    }
}
