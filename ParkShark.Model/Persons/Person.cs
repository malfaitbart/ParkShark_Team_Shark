using ParkShark.Model.Addresses;
using ParkShark.Model.Persons.LicensePlates;
using System;
using System.Net.Mail;

namespace ParkShark.Model.Persons
{
    public class Person
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string MobilePhone { get; private set; }
        public string Phone { get; private set; }
        public Address PersonAddress { get; private set; }
        public string EmailAdress { get; private set; }
        public LicensePlate LicensePlate { get; private set; }
        public int? MembershipId { get; private set; }
        public DateTime? RegistrationDate { get; private set; }
        //public ICollection<Parkinglot> Parkinglots { get; } = new List<Parkinglot>();
        //public ICollection<Division> Divisions { get; } = new List<Division>();
        private Person() { }


        public Person(string name, string mobilePhone, string phone, Address address, string email, LicensePlate licensePlate, int? membershipId = null)
        {
            //CheckValues();
            Name = CheckName(name);

            CheckPhone(mobilePhone, phone);
            MobilePhone = mobilePhone;
            Phone = phone;

            PersonAddress = address;
            EmailAdress = CheckEmail(email);
            LicensePlate = licensePlate;
            MembershipId = membershipId;
        }

        public Person(int id, string name, string mobilePhone, string phone, Address personAddress, string emailAdress, LicensePlate licensePlate, int? membershipId = null, DateTime? registrationDate = null)
        {
            Id = id;
            Name = CheckName(name);

            CheckPhone(mobilePhone, phone);
            MobilePhone = mobilePhone;
            Phone = phone;

            PersonAddress = personAddress;
            EmailAdress = CheckEmail(emailAdress);
            LicensePlate = licensePlate;
            MembershipId = membershipId;
        }

        private void CheckPhone(string mobilePhone, string phone)
        {
            if (string.IsNullOrEmpty(mobilePhone) && string.IsNullOrEmpty(phone))
            {
                throw new PersonException("you must provide at least a phone or mobilphonenumber");
            }
        }

        private string CheckName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new PersonException("name is required, create person is aborted");
            }
            return name;
        }

        private string CheckEmail(string email)
        {
            try
            {
                MailAddress m = new MailAddress(email);
                return email;
            }
            catch (Exception e)
            {
                throw new FormatException("Mailaddress is not in avlid format");
            }
        }

    }
}
