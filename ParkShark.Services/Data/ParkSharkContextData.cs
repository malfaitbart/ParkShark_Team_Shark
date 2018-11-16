using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ParkShark.Model.Addresses;
using ParkShark.Model.Divisions;
using ParkShark.Model.Parkinglots;
using ParkShark.Model.Parkinglots.BuildingTypes;
using ParkShark.Model.Persons;

namespace ParkShark.Services.Data
{
    class ParkSharkData
    {
 

        internal Person person1 = new Person()
        {
            Id = 1,
           
            Name = "Person1",
            MobilePhone = "MobilePhone1",
            EmailAdress = "EmailAdress@test.be",
        };

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
            Id =1,
            BuildingTypeId = 1,
            Capacity = 50,
            ContactPersonId = 1,
            DivisionId = 1,
            Name = "Lot1",
   
        };
    }

    public partial class ParkSharkContext
    {
        protected void SeedData(ModelBuilder modelBuilder)
        {
            var seedData = new ParkSharkData();
            modelBuilder.Entity<Person>(p =>
            {
                p.HasData(seedData.person1);
                p.OwnsOne(pp => pp.PersonAddress).HasData(new
                {
                    StreetNumber = "1",
                    StreetName = "tt",
                    CityName = "er",
                    PostalCode = "4153",
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
