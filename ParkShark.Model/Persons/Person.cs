using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using ParkShark.Infrastructure.Exceptions;
using ParkShark.Model.Addresses;
using ParkShark.Model.Divisions;
using ParkShark.Model.Parkinglots;
using ParkShark.Model.Persons.LicensePlates;

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
        public LicensePlate LicensePlate { get; set; }
        public int? MembershipId { get; set; }
        public DateTime? RegistrationDate { get; set; }
        //public ICollection<Parkinglot> Parkinglots { get; } = new List<Parkinglot>();
        //public ICollection<Division> Divisions { get; } = new List<Division>();

        public void CheckValues()
        {
            CheckFilledIn(Name, "Name", this);
            if (MobilePhone == null && Phone == null)
            {
                CheckFilledIn(MobilePhone, "MobilePhone or Phone", this);
            }
            PersonAddress.CheckValues();
            CheckEmail(EmailAdress);
            //CheckFilledIn(EmailAdress, "Email", this);
        }

        private void CheckEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new EntityNotValidException($"Email is required", this);
            }

            if (!IsEmailValid(email))
            {
                throw new EntityNotValidException($" not a correct Email-format", this);
            }
        }

        private bool IsEmailValid(string email)
        {
            try
            {
                MailAddress m = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

    }
}
