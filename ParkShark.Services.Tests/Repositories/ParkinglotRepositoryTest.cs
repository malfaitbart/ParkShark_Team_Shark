using Microsoft.EntityFrameworkCore;
using ParkShark.Services.Data;
using ParkShark.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using ParkShark.Model.Parkinglots;
using ParkShark.Services.Repositories.Parkinglots;
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
    }
}
