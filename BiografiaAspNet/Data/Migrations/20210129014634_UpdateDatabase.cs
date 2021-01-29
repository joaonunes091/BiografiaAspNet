using Microsoft.EntityFrameworkCore.Migrations;

namespace BiografiaAspNet.Migrations
{
    public partial class UpdateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Formacao");

            migrationBuilder.AddColumn<int>(
                name: "DadosPessoaisID",
                table: "ExperienciaProfissional",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ExpProfissional",
                table: "DadosPessoais",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExperienciaProfissional_DadosPessoaisID",
                table: "ExperienciaProfissional",
                column: "DadosPessoaisID");

            migrationBuilder.AddForeignKey(
                name: "FK_ExperienciaProfissional_DadosPessoais_DadosPessoaisID",
                table: "ExperienciaProfissional",
                column: "DadosPessoaisID",
                principalTable: "DadosPessoais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExperienciaProfissional_DadosPessoais_DadosPessoaisID",
                table: "ExperienciaProfissional");

            migrationBuilder.DropIndex(
                name: "IX_ExperienciaProfissional_DadosPessoaisID",
                table: "ExperienciaProfissional");

            migrationBuilder.DropColumn(
                name: "DadosPessoaisID",
                table: "ExperienciaProfissional");

            migrationBuilder.DropColumn(
                name: "ExpProfissional",
                table: "DadosPessoais");

            migrationBuilder.CreateTable(
                name: "Formacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Detalhes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estabelecimento = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formacao", x => x.Id);
                });
        }
    }
}
