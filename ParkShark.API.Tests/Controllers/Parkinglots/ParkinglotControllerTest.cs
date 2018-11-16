using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSubstitute;
using ParkShark.API.Controllers.Parkinglots;
using ParkShark.Infrastructure.DtoMapper;
using ParkShark.Infrastructure.Exceptions;
using ParkShark.Model.Parkinglots;
using ParkShark.Services.Services.Parkinglots;
using Xunit;

namespace ParkShark.API.Tests.Controllers.Parkinglots
{
    public class ParkinglotControllerTest
    {
        private readonly IParkinglotService _parkinglotService;
        private readonly ParkinglotMapper _parkinglotMapper;
        private readonly ParkinglotsController _parkinglotController;
        public ParkinglotControllerTest()
        {

            _parkinglotMapper = Substitute.For<ParkinglotMapper>();
            _parkinglotService = Substitute.For<IParkinglotService>();
            _parkinglotController = new ParkinglotsController(_parkinglotMapper, _parkinglotService); 
        }

        [Fact]
        public void GivenCompletParkinglotDto_WhenCreatingNewParkinglot_ThenReturnStatusCode201WithParkinglotDto()
        {
            //Given
            ParkinglotDto parkinglotDto = new ParkinglotDto();
            Parkinglot parkinglot = new Parkinglot();
            _parkinglotMapper.DtoToDomain(parkinglotDto).Returns(parkinglot);
            _parkinglotService.CreateParkinglot(parkinglot).Returns(parkinglot);

            //When
            CreatedResult returnValue = (CreatedResult) _parkinglotController.Createparkinglot(parkinglotDto).Result;

            //then
            Assert.Equal(201, returnValue.StatusCode);
        }

        [Fact]
        public void GivenInCompletParkinglotDto_WhenCreatingNewParkinglot_ThenReturnStatusCode400()
        {
            //Given
            ParkinglotDto parkinglotDto = new ParkinglotDto();
            Parkinglot parkinglot = new Parkinglot();

            _parkinglotMapper.When(fake => fake.DtoToDomain(parkinglotDto))
                             .Do(call => { throw new EntityNotValidException("Name required", this); });
            
            // is allowed but only if void
            //_parkinglotMapper.DtoToDomain(parkinglotDto)
            //                .Returns(x => throw new EntityNotValidException("Name required", this));

            Action action = () => _parkinglotController.Createparkinglot(parkinglotDto);
            var exeption = Assert.Throws<EntityNotValidException>(action);
            Assert.Contains("Name required", exeption.Message);

            ////then
            //Assert.IsType<BadRequestObjectResult>(returnValue);
        }
    }
}
