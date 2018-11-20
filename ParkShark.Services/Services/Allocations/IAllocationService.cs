using System;
using System.Collections.Generic;
using System.Text;
using ParkShark.Model.Allocations;
using ParkShark.Model.Persons.LicensePlates;

namespace ParkShark.Services.Services.Allocations
{
    public interface IAllocationService
    {
        Allocation StartAllocation(Allocation newAllocation, LicensePlate memberLicensePlate);
    }
}
