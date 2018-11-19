using ParkShark.Infrastructure.DtoMapper;
using ParkShark.Model.Persons;
using ParkShark.Model.Persons.LicensePlates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkShark.API.Controllers.Persons
{
    public class PersonMapper : Mapper<PersonDto, Person>
    {
        public override PersonDto DomainToDto(Person domainObject)
        {
            return new PersonDto
            {
                Id = domainObject.Id,
                Name = domainObject.Name,
                MobilePhone = domainObject.MobilePhone,
                Phone = domainObject.Phone,
                PersonAddress = domainObject.PersonAddress,
                EmailAdress = domainObject.EmailAdress,
                LicensePlate= domainObject.LicensePlate,
                MembershipId = domainObject.MembershipId,
                RegistrationDate = domainObject.RegistrationDate
            };
        }

        public override Person DtoToDomain(PersonDto dtoObject)
        {
            return new Person
            (
                dtoObject.Id,
                dtoObject.Name,
                dtoObject.MobilePhone,
                dtoObject.Phone,
                dtoObject.PersonAddress,
                dtoObject.EmailAdress,
                dtoObject.LicensePlate,
                dtoObject.MembershipId,
                dtoObject.RegistrationDate
            );
        }
    }
}
