using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SorterioDeTimesNew.Migrations
{
    public partial class Equipe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EquipeId",
                table: "Jogadores",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Equipes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    QuantidadeJogadores = table.Column<int>(nullable: false),
                    ContarGoleiro = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jogadores_EquipeId",
                table: "Jogadores",
                column: "EquipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jogadores_Equipes_EquipeId",
                table: "Jogadores",
                column: "EquipeId",
                principalTable: "Equipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jogadores_Equipes_EquipeId",
                table: "Jogadores");

            migrationBuilder.DropTable(
                name: "Equipes");

            migrationBuilder.DropIndex(
                name: "IX_Jogadores_EquipeId",
                table: "Jogadores");

            migrationBuilder.DropColumn(
                name: "EquipeId",
                table: "Jogadores");
        }
    }
}
