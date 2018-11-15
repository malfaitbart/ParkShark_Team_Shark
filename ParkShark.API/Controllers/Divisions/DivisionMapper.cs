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
            return new DivisionDto
            {
                Name = domainObject.Name,
                OriginalName = domainObject.OriginalName,
                DirectorId = domainObject.PersonDirectorId,
                ParentDivisionId = domainObject.ParentDivisionId
            };
        }

        public override Division DtoToDomain(DivisionDto dtoObject)
        {
            return new Division{
                Name = dtoObject.Name,
                OriginalName = dtoObject.OriginalName,
                PersonDirectorId = dtoObject.DirectorId,
                ParentDivisionId = dtoObject.ParentDivisionId
            };
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