using System;
using System.Collections.Generic;
using System.Text;

namespace ParkShark.Model.MemberShips
{
    public class MemberShip
    {
        public int Id { get; private set; }
        public double MonthlyCost { get; private set; }
        public double AllocationCost { get; private set; }
        public double MaxAllocationTime { get; private set; }

        public MemberShip(int id, double monthlyCost, double allocationCost, double maxAllocationTime)
        {
            Id = id;
            MonthlyCost = monthlyCost;
            AllocationCost = allocationCost;
            MaxAllocationTime = maxAllocationTime;
        }

        public MemberShip(double monthlyCost, double allocationCost, double maxAllocationTime)
        {
            MonthlyCost = monthlyCost;
            AllocationCost = allocationCost;
            MaxAllocationTime = maxAllocationTime;
        }
    }
}
