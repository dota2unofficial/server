﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Server.Models;

namespace Server.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20181102181449_ItemReferences_2")]
    partial class ItemReferences_2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Server.Models.Match", b =>
                {
                    b.Property<long>("MatchId")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("Duration");

                    b.Property<DateTime>("EndedAt");

                    b.Property<string>("MapName");

                    b.Property<int>("Winner");

                    b.HasKey("MatchId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("Server.Models.MatchPlayer", b =>
                {
                    b.Property<long>("MatchId");

                    b.Property<decimal>("SteamId")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 20, scale: 0)));

                    b.Property<long>("Assists");

                    b.Property<long>("Deaths");

                    b.Property<string>("Hero");

                    b.Property<long>("Kills");

                    b.Property<long>("LastHits");

                    b.Property<long>("Level");

                    b.Property<string>("PickReason");

                    b.Property<int>("PlayerId");

                    b.Property<int>("Team");

                    b.HasKey("MatchId", "SteamId");

                    b.HasIndex("SteamId");

                    b.ToTable("MatchPlayer");
                });

            modelBuilder.Entity("Server.Models.MatchPlayerItem", b =>
                {
                    b.Property<decimal>("Id")
                        .ValueGeneratedOnAdd()
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 20, scale: 0)));

                    b.Property<long>("Charges");

                    b.Property<long?>("MatchPlayerMatchId");

                    b.Property<decimal?>("MatchPlayerSteamId")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 20, scale: 0)));

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("Slot");

                    b.HasKey("Id");

                    b.HasIndex("MatchPlayerMatchId", "MatchPlayerSteamId");

                    b.ToTable("MatchPlayerItem");
                });

            modelBuilder.Entity("Server.Models.Player", b =>
                {
                    b.Property<decimal>("SteamId")
                        .ValueGeneratedOnAdd()
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 20, scale: 0)));

                    b.Property<string>("Comment");

                    b.Property<int>("PatreonLevel");

                    b.HasKey("SteamId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Server.Models.MatchPlayer", b =>
                {
                    b.HasOne("Server.Models.Match", "Match")
                        .WithMany("Players")
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Server.Models.Player", "Player")
                        .WithMany("Matches")
                        .HasForeignKey("SteamId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Server.Models.MatchPlayerItem", b =>
                {
                    b.HasOne("Server.Models.MatchPlayer")
                        .WithMany("Items")
                        .HasForeignKey("MatchPlayerMatchId", "MatchPlayerSteamId");
                });
#pragma warning restore 612, 618
        }
    }
}
