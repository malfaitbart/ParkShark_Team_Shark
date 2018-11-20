using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NJsonSchema.Infrastructure;
using NSubstitute;
using ParkShark.API.Controllers.Parkinglots;
using ParkShark.Infrastructure.DtoMapper;
using ParkShark.Infrastructure.Exceptions;
using ParkShark.Model.Addresses;
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
            //_parkinglotMapper.DtoToDomain(parkinglotDto).Returns(parkinglot);
            _parkinglotService.CreateParkinglot(_parkinglotMapper.DtoToDomain(parkinglotDto)).Returns(parkinglot);

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
            var exception = Assert.Throws<EntityNotValidException>(action);
            Assert.Contains("Name required", exception.Message);

            ////then
            //Assert.IsType<BadRequestObjectResult>(returnValue);
        }

        [Fact]
        public void GivenListParkinglotDto_WhenGetAll_ThenReturnOKWithList()
        {
            //Given
            ParkinglotDto parkinglotDto = new ParkinglotDto();
            List<ParkinglotDto> listParkinglotDto = new List<ParkinglotDto>() { parkinglotDto };

            Parkinglot parkinglot = new Parkinglot();
            List<Parkinglot> listParkinglot = new List<Parkinglot>() { parkinglot };

            _parkinglotService.GetAll().Returns(listParkinglot);

            //_parkinglotMapper.ListToDtoList(listParkinglot).Returns(listParkinglotDto);

            //When
            OkObjectResult ok = (OkObjectResult) _parkinglotController.GetAllParkinglots().Result;
            //ActionResult<List<ParkinglotDto>> returnValue = _parkinglotController.GetAllParkinglots();

            
            //then
            //OkObjectResult returnValue = (OkObjectResult)_parkinglotController.GetAllParkinglots().Result;
            Assert.Equal(200, ok.StatusCode);
            Assert.IsType < List<ParkinglotDto>>(ok.Value);
        }

        [Fact]
        public void GivenListParkinglotDto_WhenGetOnel_ThenReturnOKWithOne()
        {
            //Given

            Parkinglot parkinglot = new Parkinglot();
            _parkinglotService.GetOneParkinglot(1).Returns(parkinglot);
            _parkinglotMapper.DomainToDto(parkinglot).Returns(new ParkinglotDto());


            //When
            OkObjectResult ok = (OkObjectResult)_parkinglotController.GetOneParkinglot(1).Result;

            //then
            Assert.Equal(200, ok.StatusCode);
            Assert.IsType<ParkinglotDto>(ok.Value);
        }
    }
}
