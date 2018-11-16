﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ParkShark.Services.Data;

namespace ParkShark.Services.Migrations
{
    [DbContext(typeof(ParkSharkContext))]
    [Migration("20181116093839_08")]
    partial class _08
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ParkShark.Model.Divisions.Division", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DirectorID");

                    b.Property<string>("Name");

                    b.Property<string>("OriginalName");

                    b.Property<int?>("ParentDivisionId");

                    b.HasKey("ID");

                    b.HasIndex("DirectorID");

                    b.HasIndex("ParentDivisionId");

                    b.ToTable("Divisions");
                });

            modelBuilder.Entity("ParkShark.Model.Parkinglots.BuildingTypes.BuildingType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("BuildingTypes");
                });

            modelBuilder.Entity("ParkShark.Model.Parkinglots.Parkinglot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BuildingTypeId");

                    b.Property<int>("Capacity");

                    b.Property<int>("ContactPersonId");

                    b.Property<int>("DivisionId");

                    b.Property<string>("Name");

                    b.Property<decimal>("PricePerHour");

                    b.HasKey("Id");

                    b.HasIndex("BuildingTypeId");

                    b.HasIndex("ContactPersonId");

                    b.HasIndex("DivisionId");

                    b.ToTable("ParkingLots");
                });

            modelBuilder.Entity("ParkShark.Model.Persons.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmailAdress");

                    b.Property<int?>("LicensePlateId");

                    b.Property<int?>("MembershipId");

                    b.Property<string>("MobilePhone");

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.Property<DateTime?>("RegistrationDate");

                    b.HasKey("Id");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("ParkShark.Model.Divisions.Division", b =>
                {
                    b.HasOne("ParkShark.Model.Persons.Person", "Director")
                        .WithMany()
                        .HasForeignKey("DirectorID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ParkShark.Model.Divisions.Division", "ParentDivision")
                        .WithMany("Divisions")
                        .HasForeignKey("ParentDivisionId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ParkShark.Model.Parkinglots.Parkinglot", b =>
                {
                    b.HasOne("ParkShark.Model.Parkinglots.BuildingTypes.BuildingType", "PlBuildingType")
                        .WithMany()
                        .HasForeignKey("BuildingTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ParkShark.Model.Persons.Person", "ContactPerson")
                        .WithMany()
                        .HasForeignKey("ContactPersonId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ParkShark.Model.Divisions.Division", "PlDivision")
                        .WithMany("Parkinglots")
                        .HasForeignKey("DivisionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("ParkShark.Model.Addresses.Address", "PlAddress", b1 =>
                        {
                            b1.Property<int>("ParkinglotId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("CityName")
                                .HasColumnName("CityName");

                            b1.Property<string>("PostalCode")
                                .HasColumnName("PostalCode");

                            b1.Property<string>("StreetName")
                                .HasColumnName("StreetName");

                            b1.Property<string>("StreetNumber")
                                .HasColumnName("StreetNumber");

                            b1.ToTable("ParkingLots");

                            b1.HasOne("ParkShark.Model.Parkinglots.Parkinglot")
                                .WithOne("PlAddress")
                                .HasForeignKey("ParkShark.Model.Addresses.Address", "ParkinglotId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("ParkShark.Model.Persons.Person", b =>
                {
                    b.OwnsOne("ParkShark.Model.Addresses.Address", "PersonAddress", b1 =>
                        {
                            b1.Property<int>("PersonId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("CityName")
                                .HasColumnName("CityName");

                            b1.Property<string>("PostalCode")
                                .HasColumnName("PostalCode");

                            b1.Property<string>("StreetName")
                                .HasColumnName("StreetName");

                            b1.Property<string>("StreetNumber")
                                .HasColumnName("StreetNumber");

                            b1.ToTable("Persons");

                            b1.HasOne("ParkShark.Model.Persons.Person")
                                .WithOne("PersonAddress")
                                .HasForeignKey("ParkShark.Model.Addresses.Address", "PersonId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
