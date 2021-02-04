using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BiografiaAspNet.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DadosPessoais",
                columns: table => new
                {
                    DadosPessoaisID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: false),
                    DataNascimento = table.Column<string>(nullable: true),
                    Naturalidade = table.Column<string>(nullable: true),
                    Nacionalidade = table.Column<string>(nullable: true),
                    Foto = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DadosPessoais", x => x.DadosPessoaisID);
                });

            migrationBuilder.CreateTable(
                name: "ExperienciaProfissional",
                columns: table => new
                {
                    ExpProfissionalID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DadosPessoaisID = table.Column<int>(nullable: false),
                    Entidade = table.Column<string>(nullable: true),
                    Periodo = table.Column<string>(nullable: true),
                    Funcoes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExperienciaProfissional", x => x.ExpProfissionalID);
                    table.ForeignKey(
                        name: "FK_ExperienciaProfissional_DadosPessoais_DadosPessoaisID",
                        column: x => x.DadosPessoaisID,
                        principalTable: "DadosPessoais",
                        principalColumn: "DadosPessoaisID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExperienciaProfissional_DadosPessoaisID",
                table: "ExperienciaProfissional",
                column: "DadosPessoaisID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExperienciaProfissional");

            migrationBuilder.DropTable(
                name: "DadosPessoais");
        }
    }
}
