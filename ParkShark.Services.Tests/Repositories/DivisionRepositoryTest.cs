using Microsoft.EntityFrameworkCore;
using ParkShark.Model.Divisions;
using ParkShark.Services.Data;
using ParkShark.Services.Repositories.Divisions;
using System;
using System.Collections.Generic;
using Xunit;

namespace ParkShark.Services.Tests.Repositories.DivisionRepositories
{
    public class DivisionRepositoryTest
    {
        [Fact]
        public void GivenADivision_WhenSaveDivision_ThenRepoReturnsTrue()
        {
            //Given
            var division = new Division
            {
                Name = "test",
                OriginalName = "original",
                PersonDirectorId = 0,
                ParentDivisionId = null
            };

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
            var division = new Division
            {
                Name = "test",
                OriginalName = "original",
                PersonDirectorId = 0,
            };
            var subdivision = new Division
            {
                Name = "test",
                OriginalName = "original",
                PersonDirectorId = 0,
                ParentDivisionId = division.ID
            };


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
            var division = new Division{
                Name = "test",
                OriginalName = "original",
                PersonDirectorId = 0,
                ParentDivisionId = null
            };

            var options = new DbContextOptionsBuilder<ParkSharkContext>()
                .UseInMemoryDatabase("parkshark" + Guid.NewGuid().ToString("n"))
                .Options;

            var result = new List<Division>();

            //When
            using (var context = new ParkSharkContext(options))
            {
                IDivisionRepository divisionRepository = new DivisionRepository(context);
                result = divisionRepository.GetAllDevisions();
            }

            //Then
            Assert.IsType<List<Division>>(result);
        }
    }
}
