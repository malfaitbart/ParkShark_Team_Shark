using System;
using System.Collections.Generic;
using System.Text;
using ParkShark.Model.Parkinglots;
using ParkShark.Model.Persons;
using ParkShark.Model.Persons.LicensePlates;

namespace ParkShark.Model.Allocations
{
    public class Allocation
    {
        //Use GUID as a type for Id, EF Core can handle this! Plus, indexing on a Guid (UniqueIdentifier) is faster than a string (nvarchar)
        public string Id { get; set; }
        public int MemberPersonId { get; set; }
        public Person MemberPerson { get; set; }
        public int ParkinglotId { get; set; }
        public Parkinglot Parkinglot { get; set; }
        public DateTime StartingTime { get; set; }
        public DateTime? EndTime { get; set; }
        public StatusAllocation Status { get; set; }

        public Allocation()
        {
            Id = new Guid().ToString();
            StartingTime = DateTime.Now;
            Status = StatusAllocation.Active;
        }
    }
}
