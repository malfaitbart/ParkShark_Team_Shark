using Microsoft.AspNetCore.Mvc;
using ParkShark.Infrastructure.DtoMapper;
using ParkShark.Model.Parkinglots;
using ParkShark.Services.Services.Parkinglots;

namespace ParkShark.API.Controllers.Parkinglots
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class ParkinglotsController : ControllerBase
    {
        private readonly Mapper<ParkinglotDto, Parkinglot> _parkinglotMapper;
        private readonly IParkinglotService _parkinglotService;

        public ParkinglotsController(Mapper<ParkinglotDto, Parkinglot> parkinglotMapper, IParkinglotService parkinglotService)
        {
            _parkinglotMapper = parkinglotMapper;
            _parkinglotService = parkinglotService;
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