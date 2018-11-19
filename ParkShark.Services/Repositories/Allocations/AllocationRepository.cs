using System;
using System.Collections.Generic;
using System.Text;
using ParkShark.Infrastructure.Exceptions;
using ParkShark.Model.Allocations;
using ParkShark.Model.Parkinglots;
using ParkShark.Model.Persons;
using ParkShark.Services.Data;
using ParkShark.Services.Repositories.Parkinglots;
using ParkShark.Services.Repositories.Persons;

namespace ParkShark.Services.Repositories.Allocations
{
    public class AllocationRepository: IAllocationRepository
    {
        private readonly ParkSharkContext _context;
        private readonly IPersonRepository _personRepository;
        private readonly IParkinglotRepository _parkinglotRepository;

        public AllocationRepository(ParkSharkContext context, IPersonRepository personRepository, IParkinglotRepository parkinglotRepository)
        {
            _context = context;
            _personRepository = personRepository;
            _parkinglotRepository = parkinglotRepository;
        }

        public Allocation SaveNewAllocation(Allocation newAllocation)
        {
            if (CheckPersonExist(newAllocation.MemberPeronId) && CheckParkinglotExist(newAllocation.ParkinglotId))
            {
                _context.Add(newAllocation);
                _context.SaveChanges();
            }
            return newAllocation;
        }

        private bool CheckParkinglotExist(int newAllocationParkinglotId)
        {
            Parkinglot foundParkinglot=_parkinglotRepository.GetOneParkinglot(newAllocationParkinglotId);
            if (foundParkinglot == null)
            {
                throw new EntityNotFoundException("CheckParkinglotExist", "Allocation", newAllocationParkinglotId.ToString());
            }
            return true;
        }

        private bool CheckPersonExist(int newAllocationMemberPeronId)
        {
            Person foundPerson = _personRepository.GetById(newAllocationMemberPeronId);
            if (foundPerson == null)
            {
                throw new EntityNotFoundException("CheckPersonExist", "Allocation", newAllocationMemberPeronId.ToString());
            }
            return true;
        }
    }
}
