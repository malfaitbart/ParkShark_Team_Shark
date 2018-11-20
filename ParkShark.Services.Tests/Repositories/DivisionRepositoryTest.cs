using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ParkShark.Model.Divisions;
using ParkShark.Services.Data;
using ParkShark.Services.Repositories.Divisions;
using Xunit;

namespace ParkShark.Services.Tests.Repositories
{
    public class DivisionRepositoryTest
    {
        [Fact]
        public void GivenADivision_WhenSaveDivision_ThenRepoReturnsTrue()
        {
            //Given
            var division = new Division("test","original",0,null);

            var options = new DbContextOptionsBuilder<ParkSharkContext>()
                .UseInMemoryDatabase("parkshark" + Guid.NewGuid().ToString("n"))
                .Options;

            var result = false;

            //When
            using (var context = new ParkSharkContext(options))
            {
                IDivisionRepository divisionRepository = new DivisionRepository(context);
                result = divisionRepository.SaveNewDivision(division);
            }

            //Then
            Assert.True(result);
        }
        [Fact]
        public void GivenASubDivision_WhenSaveSubDivision_ThenRepoReturnsTrue()
        {
            //Given
            var division = new Division("test", "original", 0, null);
            var subdivision = new Division("test","original",0,division.Id);


            var options = new DbContextOptionsBuilder<ParkSharkContext>()
                .UseInMemoryDatabase("parkshark" + Guid.NewGuid().ToString("n"))
                .Options;

            var result = false;

            //When
            using (var context = new ParkSharkContext(options))
            {
                IDivisionRepository divisionRepository = new DivisionRepository(context);
                divisionRepository.SaveNewDivision(division);
                result = divisionRepository.SaveNewDivision(subdivision);
            }

            //Then
            Assert.True(result);
        }
        [Fact]
        public void GivenADivision_WhenGetAllDivisions_ThenRepoReturnsAListOfDivisions()
        {
            //Given
            var options = new DbContextOptionsBuilder<ParkSharkContext>()
                .UseInMemoryDatabase("parkshark" + Guid.NewGuid().ToString("n"))
                .Options;

            var result = new List<Division>();

            //When
            using (var context = new ParkSharkContext(options))
            {
                IDivisionRepository divisionRepository = new DivisionRepository(context);
                result = divisionRepository.GetAllDivisions();
            }

            //Then
            Assert.IsType<List<Division>>(result);
        }
    }
}
