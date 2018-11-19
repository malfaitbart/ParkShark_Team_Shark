using System;
using System.Collections.Generic;
using System.Text;
using ParkShark.Model.Allocations;

namespace ParkShark.Services.Repositories.Allocations
{
    public interface IAllocationRepository
    {
        bool SaveNewAllocation(Allocation newAllocation);
    }
}
