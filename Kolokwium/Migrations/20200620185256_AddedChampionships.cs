using Microsoft.EntityFrameworkCore.Migrations;

namespace Kolokwium.Migrations
{
    public partial class AddedChampionships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Championships",
                columns: table => new
                {
                    IdChampionship = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfficialName = table.Column<string>(nullable: true),
                    Year = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Championships", x => x.IdChampionship);
                });

            migrationBuilder.CreateTable(
                name: "ChampionshipTeams",
                columns: table => new
                {
                    IdChampionship = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTeam = table.Column<int>(nullable: false),
                    TeamIdTeam = table.Column<int>(nullable: true),
                    ChampionshipIdChampionship = table.Column<int>(nullable: true),
                    Score = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChampionshipTeams", x => x.IdChampionship);
                    table.ForeignKey(
                        name: "FK_ChampionshipTeams_Championships_ChampionshipIdChampionship",
                        column: x => x.ChampionshipIdChampionship,
                        principalTable: "Championships",
                        principalColumn: "IdChampionship",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChampionshipTeams_Teams_TeamIdTeam",
                        column: x => x.TeamIdTeam,
                        principalTable: "Teams",
                        principalColumn: "IdTeam",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChampionshipTeams_ChampionshipIdChampionship",
                table: "ChampionshipTeams",
                column: "ChampionshipIdChampionship");

            migrationBuilder.CreateIndex(
                name: "IX_ChampionshipTeams_TeamIdTeam",
                table: "ChampionshipTeams",
                column: "TeamIdTeam");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChampionshipTeams");

            migrationBuilder.DropTable(
                name: "Championships");
        }
    }
}
