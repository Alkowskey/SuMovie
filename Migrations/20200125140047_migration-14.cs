﻿using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SuMovie.Migrations
{
    public partial class migration14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WatchedMovies_Movies_MovieId",
                table: "WatchedMovies");

            migrationBuilder.DropForeignKey(
                name: "FK_WatchedMovies_Users_UserId",
                table: "WatchedMovies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WatchedMovies",
                table: "WatchedMovies");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "WatchedMovies",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "WatchedMovies",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "MovieId",
                table: "WatchedMovies",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WatchedMovies",
                table: "WatchedMovies",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_WatchedMovies_MovieId",
                table: "WatchedMovies",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_WatchedMovies_Movies_MovieId",
                table: "WatchedMovies",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WatchedMovies_Users_UserId",
                table: "WatchedMovies",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WatchedMovies_Movies_MovieId",
                table: "WatchedMovies");

            migrationBuilder.DropForeignKey(
                name: "FK_WatchedMovies_Users_UserId",
                table: "WatchedMovies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WatchedMovies",
                table: "WatchedMovies");

            migrationBuilder.DropIndex(
                name: "IX_WatchedMovies_MovieId",
                table: "WatchedMovies");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "WatchedMovies",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MovieId",
                table: "WatchedMovies",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "WatchedMovies",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_WatchedMovies",
                table: "WatchedMovies",
                columns: new[] { "MovieId", "UserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_WatchedMovies_Movies_MovieId",
                table: "WatchedMovies",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WatchedMovies_Users_UserId",
                table: "WatchedMovies",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
