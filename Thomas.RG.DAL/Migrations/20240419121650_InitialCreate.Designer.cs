﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Thomas.RG.DAL;

#nullable disable

namespace Thomas.RG.DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240419121650_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("EspionMission", b =>
                {
                    b.Property<int>("EspionsId")
                        .HasColumnType("int");

                    b.Property<int>("MissionsId")
                        .HasColumnType("int");

                    b.HasKey("EspionsId", "MissionsId");

                    b.HasIndex("MissionsId");

                    b.ToTable("EspionMission");
                });

            modelBuilder.Entity("Thomas.RG.DAL.Models.Espion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CodeNom")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Espions");
                });

            modelBuilder.Entity("Thomas.RG.DAL.Models.Mission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Annee")
                        .HasColumnType("int");

                    b.Property<string>("Ville")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Missions");
                });

            modelBuilder.Entity("EspionMission", b =>
                {
                    b.HasOne("Thomas.RG.DAL.Models.Espion", null)
                        .WithMany()
                        .HasForeignKey("EspionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Thomas.RG.DAL.Models.Mission", null)
                        .WithMany()
                        .HasForeignKey("MissionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
