using NSubstitute;
using ParkShark.Model.Parkinglots;
using ParkShark.Services.Repositories.Parkinglots;
using ParkShark.Services.Services.Parkinglots;
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
    }
}