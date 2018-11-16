﻿using ParkShark.Infrastructure.DtoMapper;
using ParkShark.Model.Parkinglots;

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
                PricePerHour = domainObject.PricePerHour,
                PlAddress = domainObject.PlAddress,
                BuildingTypeId = domainObject.BuildingTypeId
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
                 PricePerHour = dtoObject.PricePerHour,
                 PlAddress = dtoObject.PlAddress,
                 BuildingTypeId= dtoObject.BuildingTypeId
            };
            newParkinglot.CheckValues();
            return newParkinglot;
        }
    }
}