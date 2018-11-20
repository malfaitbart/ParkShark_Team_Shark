using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ParkShark.Infrastructure.DtoMapper;
using ParkShark.Model.Divisions;

namespace ParkShark.API.Controllers.Divisions
{
    public class DivisionMapper : Mapper<DivisionDto, Division>
    {
        public override DivisionDto DomainToDto(Division division)
        {
            return new DivisionDto
            {
                Id = division.Id,
                Name = division.Name,
                OriginalName = division.OriginalName,
                DirectorId = division.DirectorID,
                ParentDivisionId = division.ParentDivisionId
            };
        }

        public override Division DtoToDomain(DivisionDto divisionDto)
        {
            return new Division(divisionDto.Name,divisionDto.OriginalName,divisionDto.DirectorId,divisionDto.ParentDivisionId);
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