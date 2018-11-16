using System;
using ParkShark.Infrastructure.Exceptions;
using ParkShark.Model.Addresses;
using ParkShark.Model.Parkinglots;
using Xunit;

namespace ParkShark.Model.Tests.Parkinglots
{
    public class ParkinglotTests
    {
        [Fact]
        public void GivenAllNeccesaryPropertiesFromParkinglots_WhenMakingNewParkinglotsObject_ThenNoErrorThrow()
        {
            //Given
            Parkinglot testParkinglot = new Parkinglot()
            {
                Name = "test",
                Capacity = 1,
                DivisionId = 2,
                PricePerHour = 3,
                ContactPersonId = 4,
                PlAddress = new Address {
                    StreetName = "ljhg",
                    StreetNumber = "kuh",
                    PostalCode = "lkjh",
                    CityName = "lkjh"
                },
                BuildingTypeId = 5
            };

            //when
            testParkinglot.CheckValues();

            //then
            Assert.Equal("test", testParkinglot.Name);
        }

        [Fact]
        public void GivenNotAllNeccesaryPropertiesFromParkinglots_WhenMakingNewParkinglotsObject_ThenErrorThrow()
        {
            //Given
            Parkinglot testParkinglot = new Parkinglot()
            {
                Name="test",
                Capacity = 1,
                DivisionId = 2,
                ContactPersonId = 4,
                PlAddress = new Address(),
                BuildingTypeId = 5
            };

            //when
            Action action = () => testParkinglot.CheckValues();

            //then
            var exeption = Assert.Throws<EntityNotValidException>(action);
            Assert.Contains("is required", exeption.Message);
        }
    }
}
