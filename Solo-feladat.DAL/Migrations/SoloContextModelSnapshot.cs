﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Solo_feladat.DAL.Context;

namespace Solo_feladat.DAL.Migrations
{
    [DbContext(typeof(SoloContext))]
    partial class SoloContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Solo_feladat.Model.Models.Administrator", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id");

                    b.ToTable("Administrators");
                });

            modelBuilder.Entity("Solo_feladat.Model.Models.Airport", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("LatitudeCoord");

                    b.Property<float>("LongitudeCoord");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Airports");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c3de7922-e59d-4ac8-b7a8-cb634778a3cf"),
                            LatitudeCoord = 0.3f,
                            LongitudeCoord = 0.3f,
                            Name = "teszt1"
                        },
                        new
                        {
                            Id = new Guid("83106795-8ba0-47ab-a610-fdd2ac67aaac"),
                            LatitudeCoord = 0.3f,
                            LongitudeCoord = 0.3f,
                            Name = "teszt2"
                        });
                });

            modelBuilder.Entity("Solo_feladat.Model.Models.AirportFlight", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AirportId");

                    b.Property<Guid>("FlightId");

                    b.Property<string>("Type")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("AirportId");

                    b.HasIndex("FlightId");

                    b.ToTable("AirportFlights");

                    b.HasData(
                        new
                        {
                            Id = new Guid("cc894fcc-06a0-480e-84ed-1abd101eb24d"),
                            AirportId = new Guid("c3de7922-e59d-4ac8-b7a8-cb634778a3cf"),
                            FlightId = new Guid("ab250dce-6f80-41dc-902b-26cfb0029bd7"),
                            Type = "Landing"
                        },
                        new
                        {
                            Id = new Guid("9e419297-d5bd-43c4-b01f-07657b299e1b"),
                            AirportId = new Guid("83106795-8ba0-47ab-a610-fdd2ac67aaac"),
                            FlightId = new Guid("ab250dce-6f80-41dc-902b-26cfb0029bd7"),
                            Type = "Takeoff"
                        });
                });

            modelBuilder.Entity("Solo_feladat.Model.Models.Coordinate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("FlightId");

                    b.Property<float>("LatitudeCoord");

                    b.Property<float>("LongitudeCoord");

                    b.HasKey("Id");

                    b.HasIndex("FlightId");

                    b.ToTable("Coordinates");
                });

            modelBuilder.Entity("Solo_feladat.Model.Models.Flight", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<Guid>("PilotId");

                    b.Property<string>("Status")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("PilotId");

                    b.ToTable("Flights");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ab250dce-6f80-41dc-902b-26cfb0029bd7"),
                            Date = new DateTime(2019, 6, 25, 17, 26, 57, 726, DateTimeKind.Local).AddTicks(8015),
                            PilotId = new Guid("95b9c047-84de-4cc8-b193-c985fb8bdf6b"),
                            Status = "Wait"
                        });
                });

            modelBuilder.Entity("Solo_feladat.Model.Models.Pilot", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Pilots");

                    b.HasData(
                        new
                        {
                            Id = new Guid("95b9c047-84de-4cc8-b193-c985fb8bdf6b"),
                            Name = "teszt"
                        });
                });

            modelBuilder.Entity("Solo_feladat.Model.Models.AirportFlight", b =>
                {
                    b.HasOne("Solo_feladat.Model.Models.Airport", "Airport")
                        .WithMany("AirportFlights")
                        .HasForeignKey("AirportId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Solo_feladat.Model.Models.Flight", "Flight")
                        .WithMany("AirportFlights")
                        .HasForeignKey("FlightId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Solo_feladat.Model.Models.Coordinate", b =>
                {
                    b.HasOne("Solo_feladat.Model.Models.Flight", "Flight")
                        .WithMany("Coordinates")
                        .HasForeignKey("FlightId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Solo_feladat.Model.Models.Flight", b =>
                {
                    b.HasOne("Solo_feladat.Model.Models.Pilot", "Pilot")
                        .WithMany("Flights")
                        .HasForeignKey("PilotId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
