using Microsoft.EntityFrameworkCore.Migrations;

namespace SuMovie.Migrations
{
    public partial class migration6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_People_Directorid",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_Directorid",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Directorid",
                table: "Movies");

            migrationBuilder.CreateTable(
                name: "PersonMovie",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false),
                    MovieId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonMovie", x => new { x.MovieId, x.PersonId });
                    table.ForeignKey(
                        name: "FK_PersonMovie_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonMovie_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonMovie_PersonId",
                table: "PersonMovie",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonMovie");

            migrationBuilder.AddColumn<int>(
                name: "Directorid",
                table: "Movies",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movies_Directorid",
                table: "Movies",
                column: "Directorid");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_People_Directorid",
                table: "Movies",
                column: "Directorid",
                principalTable: "People",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
