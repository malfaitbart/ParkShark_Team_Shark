using NSubstitute;
using ParkShark.Model.Parkinglots;
using ParkShark.Services.Repositories.Parkinglots;
using ParkShark.Services.Services.Parkinglots;
using System.Collections.Generic;
using Xunit;

namespace ParkShark.Services.Tests.Services
{
    public class ParkinglotServicesTest
    {
        [Fact]
        public void GivenAParkinglotService_WhenCreateParkinglot_ThenANewParkinglotObjectIsReturned()
        {
            //Given
            Parkinglot newParkinglot = new Parkinglot();

            IParkinglotRepository parkinglotRepository = Substitute.For<IParkinglotRepository>();
            var parkinglotService = new ParkinglotService(parkinglotRepository);
            //When
            var returnParkinglot = parkinglotService.CreateParkinglot(newParkinglot);

            //Then
            Assert.IsType<Parkinglot>(returnParkinglot);
        }

        [Fact]
        public void GivenAParkinglotService_WhenCreateParkinglot_ThenReposotoryReceivedNewParkinglot()
        {
            //Given
            Parkinglot newParkinglot = new Parkinglot();

            IParkinglotRepository parkinglotRepository = Substitute.For<IParkinglotRepository>();
            var parkinglotService = new ParkinglotService(parkinglotRepository);
            //When
            var returnParkinglot = parkinglotService.CreateParkinglot(newParkinglot);

            //Then
            parkinglotRepository.Received().SaveNewParkinglot(newParkinglot);
        }

        [Fact]
        public void GivenAParkinglotService_WhenGetAllParkinglots_ThenListOfParkinglotsIsReturned()
        {
            //Given
            Parkinglot newParkinglot = new Parkinglot();
            List<Parkinglot> testParkinglots = new List<Parkinglot>() { newParkinglot};

            IParkinglotRepository parkinglotRepository = Substitute.For<IParkinglotRepository>();
            parkinglotRepository.GetAllParkinglots().Returns(testParkinglots);
            var parkinglotService = new ParkinglotService(parkinglotRepository);
            //When
            var returnParkinglot = parkinglotService.GetAll();

            //Then
            Assert.IsType<List<Parkinglot>>(returnParkinglot);
        }

        [Fact]
        public void GivenAParkinglotService_WhenGetAllParkinglots_ThenReposotoryReceivedGetAllParkinglots()
        {
            //Given
            Parkinglot newParkinglot = new Parkinglot();
            List<Parkinglot> testParkinglots = new List<Parkinglot>() { newParkinglot };

            IParkinglotRepository parkinglotRepository = Substitute.For<IParkinglotRepository>();
            var parkinglotService = new ParkinglotService(parkinglotRepository);
            //When
            var returnParkinglot = parkinglotService.GetAll();

            //Then
            parkinglotRepository.Received().GetAllParkinglots();
        }
    }
}