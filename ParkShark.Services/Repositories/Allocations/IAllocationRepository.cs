﻿using System;
using System.Collections.Generic;
using System.Text;
using ParkShark.Model.Allocations;

namespace ParkShark.Services.Repositories.Allocations
{
    public interface IAllocationRepository
    {
        Allocation SaveNewAllocation(Allocation newAllocation);
        Allocation GetAllocationById(string allocationDtoId);
        bool UpdateAllocation(Allocation allocation);
    }
}
