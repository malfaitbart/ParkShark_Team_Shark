using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ParkShark.Infrastructure.Exceptions;
using ParkShark.Model.Allocations;
using ParkShark.Model.Parkinglots;
using ParkShark.Model.Persons;
using ParkShark.Services.Data;
using ParkShark.Services.Repositories.Parkinglots;
using ParkShark.Services.Repositories.Persons;
using ParkShark.Services.Services.Parkinglots;
using ParkShark.Services.Services.Persons;

namespace ParkShark.Services.Repositories.Allocations
{
    public class AllocationRepository: IAllocationRepository
    {
        private readonly ParkSharkContext _context;
        private readonly IPersonRepository _personRepository;
        private readonly IParkinglotRepository _parkinglotRepository;

        public AllocationRepository(ParkSharkContext context, IPersonRepository personRepository, 
                IParkinglotRepository parkinglotRepository)
        {
            _context = context;
            _personRepository = personRepository;
            _parkinglotRepository = parkinglotRepository;
        }

        public Allocation SaveNewAllocation(Allocation newAllocation)
        {
            _context.Add(newAllocation);
            _context.SaveChanges();
            return newAllocation;
        }

        public Allocation GetAllocationById(string allocationDtoId)
        {
            return _context.Allocations.FirstOrDefault(al => al.Id == allocationDtoId);
        }

        public bool UpdateAllocation(Allocation allocation)
        {
            _context.Update(allocation);
            return (_context.SaveChanges() == 1);
        }
    }
}
