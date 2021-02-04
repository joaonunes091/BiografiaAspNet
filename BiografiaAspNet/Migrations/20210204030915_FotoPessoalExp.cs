using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BiografiaAspNet.Migrations
{
    public partial class FotoPessoalExp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Foto",
                table: "DadosPessoais");

            migrationBuilder.AddColumn<byte[]>(
                name: "Foto",
                table: "ExperienciaProfissional",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Foto",
                table: "ExperienciaProfissional");

            migrationBuilder.AddColumn<byte[]>(
                name: "Foto",
                table: "DadosPessoais",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
