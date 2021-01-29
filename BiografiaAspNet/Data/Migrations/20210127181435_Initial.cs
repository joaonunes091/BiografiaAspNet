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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    DataNascimento = table.Column<string>(nullable: true),
                    Naturalidade = table.Column<string>(nullable: true),
                    Nacionalidade = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DadosPessoais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExperienciaProfissional",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Entidade = table.Column<string>(nullable: true),
                    Periodo = table.Column<string>(nullable: true),
                    Funcoes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExperienciaProfissional", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Formacao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estabelecimento = table.Column<string>(nullable: true),
                    Detalhes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formacao", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DadosPessoais");

            migrationBuilder.DropTable(
                name: "ExperienciaProfissional");

            migrationBuilder.DropTable(
                name: "Formacao");
        }
    }
}
