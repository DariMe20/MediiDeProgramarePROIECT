﻿// <auto-generated />
using System;
using MediiDeProgramarePROIECT.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MediiDeProgramarePROIECT.Migrations
{
    [DbContext(typeof(MediiDeProgramarePROIECTContext))]
    [Migration("20231205090247_tables2")]
    partial class tables2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MediiDeProgramarePROIECT.Models.BookingSchedule", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("DayOfWeek")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("time");

                    b.Property<int?>("TableID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("TableID");

                    b.ToTable("BookingSchedule");
                });

            modelBuilder.Entity("MediiDeProgramarePROIECT.Models.Table", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("Seats")
                        .HasColumnType("int");

                    b.Property<int>("WaiterID")
                        .HasColumnType("int");

                    b.Property<int>("ZoneID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("WaiterID");

                    b.HasIndex("ZoneID");

                    b.ToTable("Table");
                });

            modelBuilder.Entity("MediiDeProgramarePROIECT.Models.Waiter", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Waiter");
                });

            modelBuilder.Entity("MediiDeProgramarePROIECT.Models.Zone", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Zone");
                });

            modelBuilder.Entity("MediiDeProgramarePROIECT.Models.BookingSchedule", b =>
                {
                    b.HasOne("MediiDeProgramarePROIECT.Models.Table", null)
                        .WithMany("BookingSchedules")
                        .HasForeignKey("TableID");
                });

            modelBuilder.Entity("MediiDeProgramarePROIECT.Models.Table", b =>
                {
                    b.HasOne("MediiDeProgramarePROIECT.Models.Waiter", "Waiter")
                        .WithMany("Tables")
                        .HasForeignKey("WaiterID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MediiDeProgramarePROIECT.Models.Zone", "Zone")
                        .WithMany("Tables")
                        .HasForeignKey("ZoneID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Waiter");

                    b.Navigation("Zone");
                });

            modelBuilder.Entity("MediiDeProgramarePROIECT.Models.Table", b =>
                {
                    b.Navigation("BookingSchedules");
                });

            modelBuilder.Entity("MediiDeProgramarePROIECT.Models.Waiter", b =>
                {
                    b.Navigation("Tables");
                });

            modelBuilder.Entity("MediiDeProgramarePROIECT.Models.Zone", b =>
                {
                    b.Navigation("Tables");
                });
#pragma warning restore 612, 618
        }
    }
}
