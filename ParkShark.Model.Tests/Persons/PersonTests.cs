using ParkShark.Model.Persons;
using System;
using System.Collections.Generic;
using System.Text;
using ParkShark.Model.Addresses;
using ParkShark.Model.Persons.LicensePlates;
using Xunit;

namespace ParkShark.Model.Tests.Persons
{
    public class PersonTests
    {
        [Fact]
        public void WhenGivenData_WhenCreateUser_ThenUserIsCreated()
        {
            //Given
            var name = "test";
            var mobilePhone = "000";
            var phone = "001";
            var street = "street";
            var streetnr = "01";
            var postalcode = "1234";
            var city = "kjhg";
            var licenseplate = "123";
            var country = "bel";
            var mail = "test@test.com";

            //When
            var newperson = new Person
            {
                Name = name,
                MobilePhone = mobilePhone,
                Phone = phone,
                PersonAddress = new Address
                {
                    CityName = city,
                    PostalCode = postalcode,
                    StreetName = street,
                    StreetNumber = streetnr
                },
                EmailAdress = mail,
                LicensePlate = new LicensePlate
                {
                    Country = country,
                    LicensePlateNumber = licenseplate
                }
            };
            //Then
            Assert.Equal("test", newperson.Name);
        }
    }
}
