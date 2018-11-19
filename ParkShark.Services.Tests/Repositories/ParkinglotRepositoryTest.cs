using Microsoft.EntityFrameworkCore;
using ParkShark.Model.Addresses;
using ParkShark.Model.Divisions;
using ParkShark.Model.Parkinglots;
using ParkShark.Model.Parkinglots.BuildingTypes;
using ParkShark.Model.Persons;
using ParkShark.Services.Data;
using ParkShark.Services.Repositories.Parkinglots;
using System;
using System.Collections.Generic;
using ParkShark.Model.Persons.LicensePlates;
using Xunit;

namespace ParkShark.Services.Tests.Repositories
{
    public class ParkinglotRepositoryTest
    {

        [Fact]
        public void GivenAParkinglot_WhenSaveParkinglot_ThenRepoReturnsTrue()
        {
            //Given
            var parkinglot = new Parkinglot();

            var options = new DbContextOptionsBuilder<ParkSharkContext>()
                .UseInMemoryDatabase("parkshark" + Guid.NewGuid().ToString("n"))
                .Options;

            var result = false;

            //When
            using (var context = new ParkSharkContext(options))
            {
                IParkinglotRepository parkinglotRepository = new ParkinglotRepository(context);
                result = parkinglotRepository.SaveNewParkinglot(parkinglot);
            }

            //Then
            Assert.True(result);
        }

        [Fact]
        public void GivenListOfParkinglots_WhenGetAllParkinglot_ThenReturnListOfParkinglots()
        {
            //Given
            var parkinglot = new Parkinglot();

            var options = new DbContextOptionsBuilder<ParkSharkContext>()
                .UseInMemoryDatabase("parkshark" + Guid.NewGuid().ToString("n"))
                .Options;



            //When
            using (var context = new ParkSharkContext(options))
            {
                IParkinglotRepository parkinglotRepository = new ParkinglotRepository(context);
                var result = parkinglotRepository.GetAllParkinglots();

                //Then
                Assert.IsType<List<Parkinglot>>(result);
            }


        }

        [Fact]
        public void GivenListOfParkinglots_WhenGetOneNotExistingParkinglot_ThenReturnNull()
        {
            //Given
            var parkinglot = new Parkinglot();

            var options = new DbContextOptionsBuilder<ParkSharkContext>()
                .UseInMemoryDatabase("parkshark" + Guid.NewGuid().ToString("n"))
                .Options;

            //When
            using (var context = new ParkSharkContext(options))
            {
                IParkinglotRepository parkinglotRepository = new ParkinglotRepository(context);
                var result = parkinglotRepository.GetOneParkinglot(5);

                //Then
                Assert.Null(result);
            }


        }

        [Fact]
        public void GivenListOfParkinglots_WhenGetOneParkinglot_ThenReturnParkingLot()
        {
            //Given

            var options = new DbContextOptionsBuilder<ParkSharkContext>()
                .UseInMemoryDatabase("parkshark" + Guid.NewGuid().ToString("n"))
                .Options;

            //When
            using (var context = new ParkSharkContext(options))
            {
                #region fillingInMemoryDatabase

                Address adress = new Address()
                {
                    StreetNumber = "1",
                    StreetName = "tt",
                    CityName = "er",
                    PostalCode = "4153",
                };
                context.Persons.Add(new Person(
                    1,
                    "Person1",
                    "MobilePhone1",
                    "00",
                    adress,
                    "EmailAdress@test.be",
                    new LicensePlate()
                ));

                context.Set<BuildingType>().Add(new BuildingType()
                {
                    Id = 1,
                    Name = "Underground"
                });

                context.Divisions.Add(new Division()
                {
                    ID = 1,
                    Name = "Division1",
                    OriginalName = "Original1",
                    DirectorID = 1
                });

                Parkinglot parkinglot = new Parkinglot()
                {
                    BuildingTypeId = 1,
                    Capacity = 5,
                    ContactPersonId = 1,
                    DivisionId = 1,
                    Name = "Name",
                    Id = 1,
                    PlAddress = new Address()
                    {
                        StreetNumber = "1",
                        StreetName = "tt",
                        CityName = "er",
                        PostalCode = "4153"
                    },
                    PricePerHour = 10
                };
                context.Add(parkinglot);

                context.SaveChanges();
                #endregion fillingInMemoryDatabase

                IParkinglotRepository parkinglotRepository = new ParkinglotRepository(context);
                Parkinglot result = parkinglotRepository.GetOneParkinglot(1);

                //Then
                Assert.Equal("Name", result.Name);
            }


        }
    }
}
