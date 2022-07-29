using Microsoft.EntityFrameworkCore.Migrations;

namespace JogosNet.Migrations
{
    public partial class Adicionandorelacionamentoentrelocadoraejogo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClassificacaoEtaria",
                table: "Jogos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClassificacaoEtaria",
                table: "Jogos");
        }
    }
}
