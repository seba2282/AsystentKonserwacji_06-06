﻿// <auto-generated />
using System;
using AsystentKonserwacji.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AsystentKonserwacji.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240604201612_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AsystentKonserwacji.Models.LubricationPoint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("Interval")
                        .HasColumnType("time");

                    b.Property<int>("MachineId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MachineId");

                    b.ToTable("LubricationPoints");
                });

            modelBuilder.Entity("AsystentKonserwacji.Models.Machine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Machines");
                });

            modelBuilder.Entity("AsystentKonserwacji.Models.MaintenanceSchedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("LastMaintenanceDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("LubricationPointId")
                        .HasColumnType("int");

                    b.Property<DateTime>("NextMaintenanceDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("LubricationPointId");

                    b.ToTable("MaintenanceSchedules");
                });

            modelBuilder.Entity("AsystentKonserwacji.Models.LubricationPoint", b =>
                {
                    b.HasOne("AsystentKonserwacji.Models.Machine", "Machine")
                        .WithMany("LubricationPoints")
                        .HasForeignKey("MachineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Machine");
                });

            modelBuilder.Entity("AsystentKonserwacji.Models.MaintenanceSchedule", b =>
                {
                    b.HasOne("AsystentKonserwacji.Models.LubricationPoint", "LubricationPoint")
                        .WithMany("MaintenanceSchedules")
                        .HasForeignKey("LubricationPointId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LubricationPoint");
                });

            modelBuilder.Entity("AsystentKonserwacji.Models.LubricationPoint", b =>
                {
                    b.Navigation("MaintenanceSchedules");
                });

            modelBuilder.Entity("AsystentKonserwacji.Models.Machine", b =>
                {
                    b.Navigation("LubricationPoints");
                });
#pragma warning restore 612, 618
        }
    }
}
