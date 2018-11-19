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
            (
                name,
                mobilePhone,
                phone,
                new Address
                {
                    CityName = city,
                    PostalCode = postalcode,
                    StreetName = street,
                    StreetNumber = streetnr
                },
                mail,
                new LicensePlate
                {
                    Country = country,
                    LicensePlateNumber = licenseplate
                }
            );
            //Then
            Assert.Equal("test", newperson.Name);
        }
        [Fact]
        public void WhenGivenDataWithBadEmail_WhenCreateUser_ThenGetException()
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
            var mail = "test";

            //When
            
            //Then
            Action act = () =>
            {
                var newperson = new Person
                (
                    name,
                    mobilePhone,
                    phone,
                    new Address
                    {
                        CityName = city,
                        PostalCode = postalcode,
                        StreetName = street,
                        StreetNumber = streetnr
                    },
                    mail,
                    new LicensePlate
                    {
                        Country = country,
                        LicensePlateNumber = licenseplate
                    }
                );
            };
            var exception = Assert.Throws<FormatException>(act);
            Assert.Equal("Mailaddress is not in avlid format", exception.Message);
        }
        [Fact]
        public void WhenGivenDataWithNoName_WhenCreateUser_ThenGetException()
        {
            //Given
            var name = "";
            var mobilePhone = "000";
            var phone = "001";
            var street = "street";
            var streetnr = "01";
            var postalcode = "1234";
            var city = "kjhg";
            var licenseplate = "123";
            var country = "bel";
            var mail = "test@test.be";

            //When

            //Then
            Action act = () =>
            {
                var newperson = new Person
                (
                    name,
                    mobilePhone,
                    phone,
                    new Address
                    {
                        CityName = city,
                        PostalCode = postalcode,
                        StreetName = street,
                        StreetNumber = streetnr
                    },
                    mail,
                    new LicensePlate
                    {
                        Country = country,
                        LicensePlateNumber = licenseplate
                    }
                );
            };
            var exception = Assert.Throws<PersonException>(act);
            Assert.Equal("name is required, create person is aborted", exception.Message);
        }
    }
}
