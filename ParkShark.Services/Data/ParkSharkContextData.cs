using Microsoft.EntityFrameworkCore;
using ParkShark.Model.Addresses;
using ParkShark.Model.Divisions;
using ParkShark.Model.Parkinglots;
using ParkShark.Model.Parkinglots.BuildingTypes;
using ParkShark.Model.Persons;
using System.Collections.Generic;

namespace ParkShark.Services.Data
{
    class ParkSharkData
    {
        internal BuildingType buildingType1 = new BuildingType()
        {
            Id = 1,
            Name = "Underground"
        };
        internal BuildingType buildingType2 = new BuildingType()
        {
            Id = 2,
            Name = "AboveGround"
        };

        internal Division division1 = new Division()
        {
            ID = 1,
            Name = "Division1",
            OriginalName = "Original1",
            DirectorID = 1
        };

        internal Parkinglot parkinglot1 = new Parkinglot()
        {
            Id = 1,
            BuildingTypeId = 1,
            Capacity = 50,
            AvailablePlaces = 50,
            ContactPersonId = 1,
            DivisionId = 1,
            Name = "Lot1",
            //PlAddress = new Address
            //{
            //    StreetName = "azerty",
            //    StreetNumber = "1",
            //    PostalCode = "1234",
            //    CityName = "kor"
            //}
        };
    }

    public partial class ParkSharkContext
    {
        protected void SeedData(ModelBuilder modelBuilder)
        {
            var seedData = new ParkSharkData();

            modelBuilder.Entity<Person>(p =>
            {
                p.HasData(new
                {
                    Id = 1,
                    Name = "test",
                    MobilePhone = "000",
                    Phone = "000",
                    EmailAddress = "test@test.be"
                });
                p.OwnsOne(pp => pp.PersonAddress).HasData(new
                {
                    StreetNumber = "1",
                    StreetName = "tt",
                    CityName = "er",
                    PostalCode = "4153",
                    PersonId = 1
                });
                p.OwnsOne(pp => pp.LicensePlate).HasData(new
                {
                    LicensePlateNumber = "000-000",
                    Country = "BXL",
                    PersonId = 1
                });
            });

            modelBuilder.Entity<BuildingType>().HasData(new List<BuildingType>()
            {
                seedData.buildingType1,
                seedData.buildingType2
            }.ToArray());

            modelBuilder.Entity<Division>().HasData(new List<Division>()
            {
                seedData.division1
            }.ToArray());

            modelBuilder.Entity<Parkinglot>(p =>
            {
                p.HasData(seedData.parkinglot1);
                p.OwnsOne(pp => pp.PlAddress).HasData(new
                {
                    StreetNumber = "1",
                    StreetName = "tt",
                    CityName = "er",
                    PostalCode = "4153",
                    ParkinglotId = 1
                });
            });

        }

    }
}
