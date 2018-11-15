using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkShark.Services.Services.Divisions;

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

        [HttpPost]
        public ActionResult<DivisionDto> CreateDivision([FromBody]DivisionDto divisionDto)
        {
            _divisionService.CreateDivision(divisionDto.Name,divisionDto.OriginalName, divisionDto.DirectorId);
            return Ok(divisionDto);
        }
    }
}