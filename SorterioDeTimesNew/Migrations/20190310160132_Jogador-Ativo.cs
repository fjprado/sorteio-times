using Microsoft.EntityFrameworkCore.Migrations;

namespace SorterioDeTimesNew.Migrations
{
    public partial class JogadorAtivo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Jogadores",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Jogadores");
        }
    }
}
