﻿// <auto-generated />
using System;
using CVApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CVApp.Migrations
{
    [DbContext(typeof(CVsDbContext))]
    [Migration("20210525191134_DBInit")]
    partial class DBInit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CVApp.Data.CV", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Passwrod")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID");

                    b.ToTable("CVs");
                });

            modelBuilder.Entity("CVApp.Data.Nationality", b =>
                {
                    b.Property<string>("nationality")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("CVId")
                        .HasColumnType("int");

                    b.HasKey("nationality", "CVId");

                    b.HasIndex("CVId");

                    b.ToTable("Nationalities");
                });

            modelBuilder.Entity("CVApp.Data.Skill", b =>
                {
                    b.Property<string>("Language")
                        .HasColumnType("varchar(10)");

                    b.Property<int>("CVId")
                        .HasColumnType("int");

                    b.HasKey("Language", "CVId");

                    b.HasIndex("CVId");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("CVApp.Data.Nationality", b =>
                {
                    b.HasOne("CVApp.Data.CV", null)
                        .WithMany("Nationalities")
                        .HasForeignKey("CVId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CVApp.Data.Skill", b =>
                {
                    b.HasOne("CVApp.Data.CV", null)
                        .WithMany("Skills")
                        .HasForeignKey("CVId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CVApp.Data.CV", b =>
                {
                    b.Navigation("Nationalities");

                    b.Navigation("Skills");
                });
#pragma warning restore 612, 618
        }
    }
}