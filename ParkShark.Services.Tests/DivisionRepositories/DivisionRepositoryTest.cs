using Microsoft.EntityFrameworkCore;
using ParkShark.Model.Divisions;
using ParkShark.Services.Data;
using ParkShark.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ParkShark.Services.Tests.DivisionRepositories
{
    public class DivisionRepositoryTest
    {
        [Fact]
        public void GivenADivision_WhenSaveDivision_ThenRepoReturnsTrue()
        {
            //Given
            var division = new Division("test", 0);

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
    }
}
