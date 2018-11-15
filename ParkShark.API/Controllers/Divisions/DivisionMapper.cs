using System;
using System.Collections.Generic;
using ParkShark.Infrastructure.DtoMapper;
using ParkShark.Model.Divisions;

namespace ParkShark.API.Controllers.Divisions
{
    public class DivisionMapper : Mapper<DivisionDto, Division>
    {
        public override DivisionDto DomainToDto(Division domainObject)
        {
            return new DivisionDto(domainObject.Name, domainObject.PersonDirectorId);
        }

        public override Division DtoToDomain(DivisionDto dtoObject)
        {
            return new Division(dtoObject.Name, dtoObject.PersonDirectorId);
        }

        public List<DivisionDto> ListToDtoList(List<Division> allDivisions)
        {
            var output = new List<DivisionDto>();
            foreach (var division in allDivisions)
            {
                output.Add(DomainToDto(division));
            }
            return output;
        }
    }
}