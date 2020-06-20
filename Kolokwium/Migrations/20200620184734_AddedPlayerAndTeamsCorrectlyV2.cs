using Microsoft.EntityFrameworkCore.Migrations;

namespace Kolokwium.Migrations
{
    public partial class AddedPlayerAndTeamsCorrectlyV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    IdTeam = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamName = table.Column<string>(nullable: true),
                    MaxAge = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.IdTeam);
                });

            migrationBuilder.CreateTable(
                name: "PlayerTeams",
                columns: table => new
                {
                    IdPlayer = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTeam = table.Column<int>(nullable: false),
                    NumOnShirt = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    TeamIdTeam = table.Column<int>(nullable: true),
                    PlayerIdPlayer = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerTeams", x => x.IdPlayer);
                    table.ForeignKey(
                        name: "FK_PlayerTeams_Players_PlayerIdPlayer",
                        column: x => x.PlayerIdPlayer,
                        principalTable: "Players",
                        principalColumn: "IdPlayer",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlayerTeams_Teams_TeamIdTeam",
                        column: x => x.TeamIdTeam,
                        principalTable: "Teams",
                        principalColumn: "IdTeam",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerTeams_PlayerIdPlayer",
                table: "PlayerTeams",
                column: "PlayerIdPlayer");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerTeams_TeamIdTeam",
                table: "PlayerTeams",
                column: "TeamIdTeam");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerTeams");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
