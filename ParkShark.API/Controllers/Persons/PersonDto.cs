using ParkShark.Model.Addresses;
using ParkShark.Model.Persons.LicensePlates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkShark.API.Controllers.Persons
{
    public class PersonDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MobilePhone { get; set; }
        public string Phone { get; set; }
        public Address PersonAddress { get; set; }
        public string EmailAdress { get; set; }
        public LicensePlate LicensePlate { get; set; }
        public int? MembershipId { get; set; }
        public DateTime? RegistrationDate { get; set; }

    }
}
