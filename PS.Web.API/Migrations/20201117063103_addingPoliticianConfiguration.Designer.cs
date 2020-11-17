﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PS.Web.API.Data;

namespace PS.Web.API.Migrations
{
    [DbContext(typeof(PolysenseContext))]
    [Migration("20201117063103_addingPoliticianConfiguration")]
    partial class addingPoliticianConfiguration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("PS.Shared.Models.Bill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("IntroductionDatetime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SponsorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SponsorId");

                    b.ToTable("Bill");
                });

            modelBuilder.Entity("PS.Shared.Models.Politician", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("BillId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.HasIndex("BillId");

                    b.ToTable("Politician");
                });

            modelBuilder.Entity("PS.Shared.Models.Bill", b =>
                {
                    b.HasOne("PS.Shared.Models.Politician", "Sponsor")
                        .WithMany()
                        .HasForeignKey("SponsorId");

                    b.Navigation("Sponsor");
                });

            modelBuilder.Entity("PS.Shared.Models.Politician", b =>
                {
                    b.HasOne("PS.Shared.Models.Bill", null)
                        .WithMany("Cosponsors")
                        .HasForeignKey("BillId");
                });

            modelBuilder.Entity("PS.Shared.Models.Bill", b =>
                {
                    b.Navigation("Cosponsors");
                });
#pragma warning restore 612, 618
        }
    }
}
