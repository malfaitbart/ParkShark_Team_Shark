using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ParkShark.Model.Divisions;
using ParkShark.Model.Parkinglots;
using ParkShark.Model.Parkinglots.BuildingTypes;
using ParkShark.Model.Persons;
using System;

namespace ParkShark.Services.Data
{
    public class ParkSharkContext : DbContext
    {
        public virtual DbSet<Division> Divisions { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Parkinglot> Parkinglots { get; set; }

        public ParkSharkContext(DbContextOptions<ParkSharkContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Division>()
                .ToTable("Divisions")
                .HasKey("ID");

            modelBuilder.Entity<Person>()
                .ToTable("Persons")
                .HasKey("Id");

            modelBuilder.Entity<Person>()
                .OwnsOne(person=>person.PersonAddress,
                    personAddress =>
                    {
                        personAddress.Property(prop => prop.StreetName).HasColumnName("StreetName");
                        personAddress.Property(prop => prop.StreetNumber).HasColumnName("StreetNumber");
                        personAddress.Property(prop => prop.PostalCode).HasColumnName("PostalCode");
                        personAddress.Property(prop => prop.CityName).HasColumnName("CityName");
                    });

            modelBuilder.Entity<Parkinglot>()
                .ToTable("ParkingLots")
                .HasKey("Id");


            modelBuilder.Entity<BuildingType>()
                .ToTable("BuildingTypes")
                .HasKey("Id");

            modelBuilder.Entity<Parkinglot>()
                .OwnsOne(parkinglot => parkinglot.PlAddress,
                    plAddress =>
                    {
                        plAddress.Property(prop => prop.StreetName).HasColumnName("StreetName");
                        plAddress.Property(prop => prop.StreetNumber).HasColumnName("StreetNumber");
                        plAddress.Property(prop => prop.PostalCode).HasColumnName("PostalCode");
                        plAddress.Property(prop => prop.CityName).HasColumnName("CityName");
                    });

            modelBuilder.Entity<Parkinglot>()
                .HasOne(parkinglot => parkinglot.ContactPerson)
                .WithMany(person => person.Parkinglots)
                .HasForeignKey(parkinglot => parkinglot.ContactPersonId)
                .IsRequired();

            modelBuilder.Entity<Parkinglot>()
                .HasOne(parkinglot => parkinglot.PlBuildingType)
                .WithMany(buildingType => buildingType.Parkinglots)
                .HasForeignKey(parkinglot => parkinglot.BuildingTypeId)
                .IsRequired();

            //TODO Add collection in Devision
            //public ICollection<Parkinglot> Parkinglots { get; } = new List<Parkinglot>();

            //modelBuilder.Entity<Parkinglot>()
            //    .HasOne(parkinglot => parkinglot.PlDivision)
            //    .WithMany(division => division.Parkinglots)
            //    .HasForeignKey(parkinglot => parkinglot.DivisionId)
            //    .IsRequired();

        }
    }
}
