using Microsoft.EntityFrameworkCore.Migrations;

namespace BiografiaAspNet.Migrations
{
    public partial class Correcao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpProfissional",
                table: "DadosPessoais");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ExpProfissional",
                table: "DadosPessoais",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
