using System;
using System.Collections.Generic;
using System.Text;
using ParkShark.Model.Persons.LicensePlates;
using Xunit;

namespace ParkShark.Model.Tests.Persons
{
    public class LicensePlateTest
    {
        [Fact]
        public void Given_2LicensePlateWithSameValues_WhenCheckEquality_ThenReturnTrue()
        {
            LicensePlate plate1 = new LicensePlate()
            {
                Country = "BE",
                LicensePlateNumber = "1234"
            };
            LicensePlate plate2 = new LicensePlate()
            {
                Country = "BE",
                LicensePlateNumber = "1234"
            };
            Assert.Equal(plate1, plate2);
        }


        [Fact]
        public void Given_2LicensePlateWithDiffValues_WhenCheckEquality_ThenReturnFalse()
        {
            LicensePlate plate1 = new LicensePlate()
            {
                Country = "BE",
                LicensePlateNumber = "1234"
            };
            LicensePlate plate2 = new LicensePlate()
            {
                Country = "BE",
                LicensePlateNumber = "12354"
            };
            Assert.NotEqual(plate1, plate2);
        }
    }
}
