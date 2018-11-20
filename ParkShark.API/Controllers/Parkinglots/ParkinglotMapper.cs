using ParkShark.Infrastructure.DtoMapper;
using ParkShark.Model.Parkinglots;
using System.Collections.Generic;

namespace ParkShark.API.Controllers.Parkinglots
{
    public class ParkinglotMapper : Mapper<ParkinglotDto, Parkinglot>
    {
        public override ParkinglotDto DomainToDto(Parkinglot domainObject)
        {
            ParkinglotDto dtoParkinglot = new ParkinglotDto()
            {
                DivisionId = domainObject.DivisionId,
                ContactPersonId = domainObject.ContactPersonId,
                Name = domainObject.Name,
                Capacity = domainObject.Capacity,
                AvailablePlaces=domainObject.AvailablePlaces,
                PricePerHour = domainObject.PricePerHour,
                PlAddress = domainObject.PlAddress,
                BuildingTypeId = domainObject.BuildingTypeId,
                Id =  domainObject.Id
            };

            return dtoParkinglot;
        }

        public override Parkinglot DtoToDomain(ParkinglotDto dtoObject)
        {
            Parkinglot newParkinglot = new Parkinglot()
            {
                 DivisionId = dtoObject.DivisionId,
                 ContactPersonId = dtoObject.ContactPersonId,
                 Name= dtoObject.Name,
                 Capacity = dtoObject.Capacity,
                 AvailablePlaces = dtoObject.Capacity,
                 PricePerHour = dtoObject.PricePerHour,
                 PlAddress = dtoObject.PlAddress,
                 BuildingTypeId= dtoObject.BuildingTypeId
            };
            newParkinglot.CheckValues();
            return newParkinglot;
        }

        public List<ParkinglotDto> ListToDtoList(List<Parkinglot> allParkinglots)
        {
            var output = new List<ParkinglotDto>();
            foreach (var division in allParkinglots)
            {
                output.Add(DomainToDto(division));
            }
            return output;
        }
    }
}