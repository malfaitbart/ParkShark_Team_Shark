using System;
using ParkShark.Model.Parkinglots;
using ParkShark.Model.Persons;

namespace ParkShark.API.Controllers.Allocations
{
    public class AllocationDto
    {
        public string Id { get; set; }
        public int MemberPeronId { get; set; }
        public int ParkinglotId { get; set; }
        //public DateTime StartingTime { get; set; }
        //public DateTime EndTime { get; set; }
        //public string Status { get; set; }

    }
}
