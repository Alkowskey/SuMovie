using Microsoft.EntityFrameworkCore.Migrations;

namespace SuMovie.Migrations
{
    public partial class secondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Persons_Directorid",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Movies_MovieId",
                table: "Persons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Persons",
                table: "Persons");

            migrationBuilder.RenameTable(
                name: "Persons",
                newName: "People");

            migrationBuilder.RenameIndex(
                name: "IX_Persons_MovieId",
                table: "People",
                newName: "IX_People_MovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_People",
                table: "People",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_People_Directorid",
                table: "Movies",
                column: "Directorid",
                principalTable: "People",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_People_Movies_MovieId",
                table: "People",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_People_Directorid",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_People_Movies_MovieId",
                table: "People");

            migrationBuilder.DropPrimaryKey(
                name: "PK_People",
                table: "People");

            migrationBuilder.RenameTable(
                name: "People",
                newName: "Persons");

            migrationBuilder.RenameIndex(
                name: "IX_People_MovieId",
                table: "Persons",
                newName: "IX_Persons_MovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persons",
                table: "Persons",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Persons_Directorid",
                table: "Movies",
                column: "Directorid",
                principalTable: "Persons",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Movies_MovieId",
                table: "Persons",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
