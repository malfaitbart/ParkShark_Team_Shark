using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkShark.Model.Persons;
using ParkShark.Services.Services.Persons;

namespace ParkShark.API.Controllers.Persons
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly PersonMapper _personMapper;
        private readonly IPersonService _personService;

        public PersonsController(PersonMapper personMapper, IPersonService personService)
        {
            _personMapper = personMapper;
            _personService = personService;
        }

        [HttpGet]
        public ActionResult<List<PersonDto>> GetAll()
        {
            var output = new List<PersonDto>();
            foreach (var person in _personService.GetAll())
            {
                output.Add(_personMapper.DomainToDto(person));
            }
            return Ok(output);
        }

        [HttpPost]
        public ActionResult SaveNewPerson(PersonDto personDto)
        {
            _personService.SaveNewPerson(_personMapper.DtoToDomain(personDto));
            return Ok();
        }
    }
}