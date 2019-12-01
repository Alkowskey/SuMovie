﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SuMovie.Context;

namespace SuMovie.Migrations
{
    [DbContext(typeof(ImdbDbContext))]
    partial class ImdbDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("SuMovie.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("Directorid")
                        .HasColumnType("integer");

                    b.Property<string>("Language")
                        .HasColumnType("text");

                    b.Property<int>("MetaScore")
                        .HasColumnType("integer");

                    b.Property<string>("Rate")
                        .HasColumnType("text");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Directorid");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("SuMovie.Models.Person", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("MovieId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.HasIndex("MovieId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("SuMovie.Models.Movie", b =>
                {
                    b.HasOne("SuMovie.Models.Person", "Director")
                        .WithMany()
                        .HasForeignKey("Directorid");
                });

            modelBuilder.Entity("SuMovie.Models.Person", b =>
                {
                    b.HasOne("SuMovie.Models.Movie", null)
                        .WithMany("Stars")
                        .HasForeignKey("MovieId");
                });
#pragma warning restore 612, 618
        }
    }
}
