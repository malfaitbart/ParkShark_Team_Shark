using System;
using System.Collections.Generic;
using System.Text;
using ParkShark.Model.Addresses;
using ParkShark.Model.Parkinglots;

namespace ParkShark.Model.Persons
{
    public class Person
    {
        public int Id { get; set;  }
        public string Name { get; set; }
        public string MobilePhone { get; set; }
        public string Phone { get; set; }
        public Address PersonAddress { get; set; }
        public string EmailAdress { get; set; }
        public int? LicensePlateId { get; set; }
        public int? MembershipId { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public ICollection<Parkinglot> Parkinglots { get; } = new List<Parkinglot>();
    }
}
