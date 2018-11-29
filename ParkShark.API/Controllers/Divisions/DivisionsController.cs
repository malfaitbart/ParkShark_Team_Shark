using Microsoft.AspNetCore.Mvc;
using ParkShark.Services.Services.Divisions;
using System.Collections.Generic;

namespace ParkShark.API.Controllers.Divisions
{
    [Route("api/[controller]")]
    [ApiController]
    public class DivisionsController : ControllerBase
    {
        private readonly DivisionMapper _divisionMapper;
        private readonly IDivisionService _divisionService;

        public DivisionsController(DivisionMapper divisionMapper, IDivisionService divisionService)
        {
            _divisionMapper = divisionMapper;
            _divisionService = divisionService;
        }

        [HttpGet]
        public ActionResult<List<DivisionDto>> GetAll()
        {
            var allDivisions = _divisionService.GetAll();
            var allDivisionsDto = _divisionMapper.ListToDtoList(allDivisions);
            return allDivisionsDto;
        }

        [HttpGet("{id}")]
        public ActionResult<DivisionDto> GetById(int id)
        {
            var division = _divisionService.GetById(id);
            if (division == null)
            {
                return NotFound($"Division with id {id} was not found");
            }
            return Ok(_divisionMapper.DomainToDto(division));
        }

        [HttpPost]
        public ActionResult<DivisionDto> CreateDivision([FromBody]DivisionDto divisionDto)
        {
            _divisionService.CreateDivision(divisionDto.Name, divisionDto.OriginalName, divisionDto.DirectorId, divisionDto.ParentDivisionId);
            return Ok(divisionDto);
        }

        [HttpPost("UpdateDivision")]
        public ActionResult UpdateDivision([FromBody] DivisionDto divisionDto)
        {
            var result = _divisionService.UpdateDivision(_divisionMapper.DtoToDomain(divisionDto));
            if (result)
            {
                return Ok("Division was updated");
            }
            //Don't just assume a false result to be a 404, make it excplicit, use exceptions and an exception filter: EntityNotFoundException
            return NotFound("Division was not found, No update has been done");
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteDivision(int id)
        {
            var result = _divisionService.DeleteDivision(id);
            if (result)
            {
                return Ok("Division has been deleted");
            }

            //Don't just assume a false result to be a 404, make it excplicit, use exceptions and an exception filter: EntityNotFoundException
            return NotFound("Division was not found. Nothing has been deleted");
        }
    }
}