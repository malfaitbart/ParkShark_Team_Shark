using System;
using System.Collections.Generic;
using System.Text;
using ParkShark.Infrastructure.Exceptions;
using ParkShark.Model.Allocations;
using ParkShark.Model.Parkinglots;
using ParkShark.Model.Persons;
using ParkShark.Model.Persons.LicensePlates;
using ParkShark.Services.Repositories.Allocations;
using ParkShark.Services.Services.Parkinglots;
using ParkShark.Services.Services.Persons;

namespace ParkShark.Services.Services.Allocations
{
    public class AllocationService: IAllocationService
    {
        private readonly IAllocationRepository _allocationRepository;
        private readonly IParkinglotService _parkinglotService;
        private readonly IPersonService _personService;

        public AllocationService(IAllocationRepository allocationRepository, IParkinglotService parkinglotService,
        IPersonService personService)
        {
            _allocationRepository = allocationRepository;
            _parkinglotService = parkinglotService;
            _personService = personService;
        }

        public Allocation StartAllocation(Allocation newAllocation, LicensePlate memberLicensePlate)
        {

            Parkinglot parkinglotToChange = _parkinglotService.GetOneParkinglot(newAllocation.ParkinglotId);
            Person person = _personService.GetById(newAllocation.MemberPersonId);

            if (person != null && person.LicensePlate.Equals(memberLicensePlate))
            {
                _parkinglotService.ReduceAvailableParkingSpots(parkinglotToChange);
            }
            if (person == null)
            {
                throw new EntityNotFoundException("CheckPersonExist", "Person", newAllocation.MemberPersonId.ToString());
            }

            if (!person.LicensePlate.Equals(memberLicensePlate))
            {
                throw new EntityNotValidException("Licenseplate", memberLicensePlate);
            }

            return _allocationRepository.SaveNewAllocation(newAllocation);
        }



    }
}
