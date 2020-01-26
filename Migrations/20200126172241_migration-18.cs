using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SuMovie.Migrations
{
    public partial class migration18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Genres",
                table: "Movies",
                nullable: true,
                oldClrType: typeof(string[]),
                oldType: "text[]",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string[]>(
                name: "Genres",
                table: "Movies",
                type: "text[]",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
