using NSubstitute;
using ParkShark.Model.Parkinglots;
using ParkShark.Services.Repositories.Parkinglots;
using ParkShark.Services.Services.Parkinglots;
using System.Collections.Generic;
using NSubstitute.ReturnsExtensions;
using System;
using Xunit;
using ParkShark.Infrastructure.Exceptions;

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
        public void GivenAParkinglotService_WhenGetOneParkinglot_ThenReturnParkinglot()
        {
            //Given
            Parkinglot newParkinglot = new Parkinglot();
  
            IParkinglotRepository parkinglotRepository = Substitute.For<IParkinglotRepository>();
            parkinglotRepository.GetOneParkinglot(5).Returns(newParkinglot);
            var parkinglotService = new ParkinglotService(parkinglotRepository);
            //When
            var returnParkinglot = parkinglotService.GetOneParkinglot(5);

            //Then
            Assert.IsType<Parkinglot>(returnParkinglot);
        }

        [Fact]
        public void GivenAParkinglotService_WhenGetOneNoneExistingParkinglot_ThenThrowException()
        {
            //Given
            Parkinglot newParkinglot = new Parkinglot();

            IParkinglotRepository parkinglotRepository = Substitute.For<IParkinglotRepository>();
            parkinglotRepository.GetOneParkinglot(5).ReturnsNull();
            var parkinglotService = new ParkinglotService(parkinglotRepository);
            //When
            Action action = () =>  parkinglotService.GetOneParkinglot(5);

            //Then
            Assert.Throws<EntityNotFoundException>(action);
        }

        [Fact]
        public void GivenAParkinglotService_WhenGetAllParkinglots_ThenRepositoryReceivedGetAllParkinglots()
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

        [Fact]
        public void GivenAParkinglotService_WhenReduceAvailablePlacesParkinglot_ThenThrowExceptionIfGoesNegative()
        {
            //Given
            Parkinglot newParkinglot = new Parkinglot()
            {
                AvailablePlaces = 0
            };
            IParkinglotRepository parkinglotRepository = Substitute.For<IParkinglotRepository>();

            var parkinglotService = new ParkinglotService(parkinglotRepository);
            //When
            Action action = () => parkinglotService.ReduceAvailableParkingSpots(newParkinglot);

            //Then
            Assert.Throws< EntityNotValidException> (action);
        }

        [Fact]
        public void GivenAParkinglotService_WhenReduceAvailablePlacesParkinglot_ThenReduceAvailablePlaces()
        {
            //Given
            Parkinglot newParkinglot = new Parkinglot()
            {
                AvailablePlaces = 5
            };
            IParkinglotRepository parkinglotRepository = Substitute.For<IParkinglotRepository>();

            var parkinglotService = new ParkinglotService(parkinglotRepository);
            parkinglotRepository.UpdateParkinglot(newParkinglot).Returns(true);
            //When
            parkinglotService.ReduceAvailableParkingSpots(newParkinglot);

            //Then
            Assert.Equal(4, newParkinglot.AvailablePlaces);
        }
    }
}