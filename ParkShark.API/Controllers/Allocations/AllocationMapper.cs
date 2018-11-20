using ParkShark.Infrastructure.DtoMapper;
using ParkShark.Model.Persons;
using ParkShark.Model.Persons.LicensePlates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ParkShark.API.Controllers.Persons;
using ParkShark.Model.Allocations;

namespace ParkShark.API.Controllers.Allocations
{
    public class AllocationMapper : Mapper<AllocationDto, Allocation>
    {
        public override AllocationDto DomainToDto(Allocation domainObject)
        {
            return new AllocationDto
            {
                Id = domainObject.Id,
                MemberPeronId = domainObject.MemberPersonId,
                ParkinglotId = domainObject.ParkinglotId,
            };
        }

        public override Allocation DtoToDomain(AllocationDto dtoObject)
        {
            return new Allocation
            {
                Id = dtoObject.Id,
                MemberPersonId = dtoObject.MemberPeronId,
                ParkinglotId = dtoObject.ParkinglotId,
            };
        }
    }
}
