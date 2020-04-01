using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LaboratorioGestor.Data.Migrations
{
    public partial class AtualizacaoTabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DentistaId",
                table: "Enderecos",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "LaboratorioId",
                table: "Enderecos",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ProteticoId",
                table: "Enderecos",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "DentistaId",
                table: "Contatos",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "LaboratorioId",
                table: "Contatos",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ProteticoId",
                table: "Contatos",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DentistaId",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "LaboratorioId",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "ProteticoId",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "DentistaId",
                table: "Contatos");

            migrationBuilder.DropColumn(
                name: "LaboratorioId",
                table: "Contatos");

            migrationBuilder.DropColumn(
                name: "ProteticoId",
                table: "Contatos");
        }
    }
}
