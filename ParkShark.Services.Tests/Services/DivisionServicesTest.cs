using NSubstitute;
using ParkShark.Model.Divisions;
using ParkShark.Services.Services.Divisions;
using ParkShark.Services.Repositories.Divisions;
using Xunit;
using System.Collections.Generic;

namespace ParkShark.Services.Tests.Services.DivisionServices
{
    public class DivisionServicesTest
    {
        [Fact]
        public void GivenADivisionService_WhenCreateDivision_ThenANewDivisionObjectIsReturned()
        {
            //Given
            string name = "test";
            string originalName = "original";
            int persondirectorId = 0;
            IDivisionRepository divisionRepository = Substitute.For<IDivisionRepository>();
            var divisionService = new DivisionService(divisionRepository);
            //When
            var newDivision = divisionService.CreateDivision(name, originalName, persondirectorId);

            //Then
            Assert.IsType<Division>(newDivision);
        }

        [Fact]
        public void GivenADivisionService_WhenCreateSubDivision_ThenANewSubDivisionObjectIsReturned()
        {
            //Given
            string name = "test";
            string originalName = "original";
            int persondirectorId = 0;
            IDivisionRepository divisionRepository = Substitute.For<IDivisionRepository>();
            var divisionService = new DivisionService(divisionRepository);
            //When
            var newDivision = divisionService.CreateDivision(name, originalName, persondirectorId);
            var newSubDivision = divisionService.CreateDivision(name, originalName, persondirectorId, newDivision.ID);
            //Then
            Assert.IsType<Division>(newSubDivision);
        }

        //[Fact]
        //public void GivenADivisionService_WhenGetAll_ThenAListOfDivisionsIsReturned()
        //{
        //    //Given
        //    IDivisionRepository divisionRepository = Substitute.For<IDivisionRepository>();
        //    var divisionService = new DivisionService(divisionRepository);
        //    //When
        //    var actual = divisionService.GetAll();

        //    //Then
        //    Assert.IsType<List<Division>>(actual);
        //}
    }
}