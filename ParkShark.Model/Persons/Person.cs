using System;
using System.Collections.Generic;
using System.Text;
using ParkShark.Infrastructure.Exceptions;
using ParkShark.Model.Addresses;
using ParkShark.Model.Parkinglots;

namespace ParkShark.Model.Persons
{
    public class Person:ModelCreationCheckClass
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

        public void CheckValues()
        {
            CheckFilledIn(Name, "Name", this);
            if (MobilePhone == null && Phone == null)
            {
                CheckFilledIn(MobilePhone, "MobilePhone or Phone", this);
            }
            CheckFilledIn(PersonAddress, "Person address", this);
            CheckFilledIn(EmailAdress, "Email", this);
        }

 }
}
