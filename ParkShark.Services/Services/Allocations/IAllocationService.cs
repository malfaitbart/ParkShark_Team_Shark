using System;
using System.Collections.Generic;
using System.Text;
using ParkShark.Model.Allocations;

namespace ParkShark.Services.Services.Allocations
{
    public interface IAllocationService
    {
        Allocation StartAllocation(Allocation newAllocation);
    }
}
