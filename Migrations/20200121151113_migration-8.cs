using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SuMovie.Migrations
{
    public partial class migration8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Language",
                table: "Movies");

            migrationBuilder.AddColumn<List<string>>(
                name: "Genres",
                table: "Movies",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Genres",
                table: "Movies");

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "Movies",
                type: "text",
                nullable: true);
        }
    }
}
