﻿// <auto-generated />
namespace FootballManager.Data.Migrations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Infrastructure;
    using Microsoft.EntityFrameworkCore.Metadata;
    using Microsoft.EntityFrameworkCore.Migrations;

    using FootballManager.Data;

    [DbContext(typeof(FootballManagerDbContext))]
    [Migration("20220220073806_ExamTables")]
    partial class ExamTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FootballManager.Data.Models.Player", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<byte>("Endurance")
                        .HasColumnType("tinyint");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<byte>("Speed")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("FootballManager.Data.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FootballManager.Data.Models.UserPlayer", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PlayerId")
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("UserId", "PlayerId");

                    b.HasIndex("PlayerId");

                    b.ToTable("UserPlayers");
                });

            modelBuilder.Entity("FootballManager.Data.Models.UserPlayer", b =>
                {
                    b.HasOne("FootballManager.Data.Models.Player", "Player")
                        .WithMany("UserPlayers")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FootballManager.Data.Models.User", "User")
                        .WithMany("UserPlayers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Player");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FootballManager.Data.Models.Player", b =>
                {
                    b.Navigation("UserPlayers");
                });

            modelBuilder.Entity("FootballManager.Data.Models.User", b =>
                {
                    b.Navigation("UserPlayers");
                });
#pragma warning restore 612, 618
        }
    }
}
