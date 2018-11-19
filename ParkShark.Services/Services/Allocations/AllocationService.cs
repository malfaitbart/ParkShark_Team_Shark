using System;
using System.Collections.Generic;
using System.Text;
using ParkShark.Model.Allocations;
using ParkShark.Services.Repositories.Allocations;

namespace ParkShark.Services.Services.Allocations
{
    public class AllocationService: IAllocationService
    {
        private readonly IAllocationRepository _allocationRepository;

        public AllocationService(IAllocationRepository allocationRepository)
        {
            this._allocationRepository = allocationRepository;
        }

        public Allocation StartAllocation(Allocation newAllocation)
        {
            _allocationRepository.SaveNewAllocation(newAllocation);
            return newAllocation;
        }
    }
}
