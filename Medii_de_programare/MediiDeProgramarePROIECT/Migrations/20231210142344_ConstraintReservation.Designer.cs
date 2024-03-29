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
    [Migration("20231210142344_ConstraintReservation")]
    partial class ConstraintReservation
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

                    b.Property<int>("ScheduleID")
                        .HasColumnType("int");

                    b.Property<int>("TableID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ScheduleID");

                    b.HasIndex("TableID");

                    b.ToTable("BookingSchedule");
                });

            modelBuilder.Entity("MediiDeProgramarePROIECT.Models.Client", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("MediiDeProgramarePROIECT.Models.Reservation", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("ClientID")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReservationDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ReservationID")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReservationTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("TableID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ClientID");

                    b.HasIndex("ReservationID")
                        .IsUnique()
                        .HasFilter("[ReservationID] IS NOT NULL");

                    b.ToTable("Reservation");
                });

            modelBuilder.Entity("MediiDeProgramarePROIECT.Models.Schedule", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("DayOfWeek")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("time");

                    b.Property<string>("ScheduleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("time");

                    b.HasKey("ID");

                    b.ToTable("Schedule");
                });

            modelBuilder.Entity("MediiDeProgramarePROIECT.Models.Table", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("ReservationID")
                        .HasColumnType("int");

                    b.Property<int>("Seats")
                        .HasColumnType("int");

                    b.Property<int?>("WaiterID")
                        .HasColumnType("int");

                    b.Property<int?>("ZoneID")
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
                    b.HasOne("MediiDeProgramarePROIECT.Models.Schedule", "Schedule")
                        .WithMany("BookingSchedules")
                        .HasForeignKey("ScheduleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MediiDeProgramarePROIECT.Models.Table", "Table")
                        .WithMany("BookingSchedules")
                        .HasForeignKey("TableID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Schedule");

                    b.Navigation("Table");
                });

            modelBuilder.Entity("MediiDeProgramarePROIECT.Models.Reservation", b =>
                {
                    b.HasOne("MediiDeProgramarePROIECT.Models.Client", "Client")
                        .WithMany("Reservations")
                        .HasForeignKey("ClientID");

                    b.HasOne("MediiDeProgramarePROIECT.Models.Table", "Table")
                        .WithOne("Reservation")
                        .HasForeignKey("MediiDeProgramarePROIECT.Models.Reservation", "ReservationID");

                    b.Navigation("Client");

                    b.Navigation("Table");
                });

            modelBuilder.Entity("MediiDeProgramarePROIECT.Models.Table", b =>
                {
                    b.HasOne("MediiDeProgramarePROIECT.Models.Waiter", "Waiter")
                        .WithMany("Tables")
                        .HasForeignKey("WaiterID");

                    b.HasOne("MediiDeProgramarePROIECT.Models.Zone", "Zone")
                        .WithMany("Tables")
                        .HasForeignKey("ZoneID");

                    b.Navigation("Waiter");

                    b.Navigation("Zone");
                });

            modelBuilder.Entity("MediiDeProgramarePROIECT.Models.Client", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("MediiDeProgramarePROIECT.Models.Schedule", b =>
                {
                    b.Navigation("BookingSchedules");
                });

            modelBuilder.Entity("MediiDeProgramarePROIECT.Models.Table", b =>
                {
                    b.Navigation("BookingSchedules");

                    b.Navigation("Reservation");
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
