using Microsoft.AspNetCore.Mvc;
using ParkShark.Infrastructure.DtoMapper;
using ParkShark.Model.Parkinglots;
using ParkShark.Services.Services.Parkinglots;
using System.Collections.Generic;

namespace ParkShark.API.Controllers.Parkinglots
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class ParkinglotsController : ControllerBase
    {
        private readonly ParkinglotMapper _parkinglotMapper;
        private readonly IParkinglotService _parkinglotService;

        public ParkinglotsController(ParkinglotMapper parkinglotMapper, IParkinglotService parkinglotService)
        {
            _parkinglotMapper = parkinglotMapper;
            _parkinglotService = parkinglotService;
        }

        [HttpGet]
        public ActionResult<List<ParkinglotDto>> GetAllParkinglots()
        {
            var allParkinglots = _parkinglotService.GetAll();
            var allParkinglotsDto = _parkinglotMapper.ListToDtoList(allParkinglots);
            return Ok(allParkinglotsDto);
        }

        [HttpPost]
        public ActionResult<ParkinglotDto> Createparkinglot([FromBody]ParkinglotDto parkinglotDto)
        {
            var newParkinglot = _parkinglotMapper.DtoToDomain(parkinglotDto);
            newParkinglot = _parkinglotService.CreateParkinglot(newParkinglot);
            return Created($"api/parkinglots/{newParkinglot.Id}", parkinglotDto);
        }
    }
}