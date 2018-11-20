using Moq;
using ParkShark.Model.Addresses;
using ParkShark.Model.Persons;
using ParkShark.Model.Persons.LicensePlates;
using ParkShark.Services.Repositories.Persons;
using ParkShark.Services.Services.Persons;
using System.Collections.Generic;
using Xunit;

namespace ParkShark.Services.Tests.Services
{
    public class PersonServicesTest
    {
        [Fact]
        public void GivenAPersonService_WhenGetAll_GetAlIstOfPersons()
        {
            var mock = new Mock<IPersonRepository>();
            mock.Setup(m => m.GetAll()).Returns(new List<Person>());
            //Given
            PersonService personService = new PersonService(mock.Object);

            //When
            var actual = personService.GetAll();

            //Then
            Assert.IsType<List<Person>>(actual);
        }

        [Fact]
        public void GivenAPersonServiceAndAPerson_WhenSavePerson_ThenPersonIsSaved()
        {
            var newperson = new Person
            (
                "test",
                "000",
                "",
                new Address
                {
                    CityName = "kor",
                    PostalCode = "12345",
                    StreetName = "street",
                    StreetNumber = "10"
                },
                "test@test.be",
                new LicensePlate("123", "be")
            );

            //Given
            var mock = new Mock<IPersonRepository>();
            mock.Setup(m => m.SaveNewPerson(newperson)).Returns(true);
            PersonService personService = new PersonService(mock.Object);
            //When
            var actual = personService.SaveNewPerson(newperson);
            //Then
            Assert.Equal(newperson.Id, actual.Id);
        }

        [Fact]
        public void GivenAPersonService_WhenGetByID_GetPerson()
        {
            //Given
            var newperson = new Person
            (
                "test",
                "000",
                "",
                new Address
                {
                    CityName = "kor",
                    PostalCode = "12345",
                    StreetName = "street",
                    StreetNumber = "10"
                },
                "test@test.be",
                new LicensePlate("123456","be")
            );

            var mock = new Mock<IPersonRepository>();
            mock.Setup(m=>m.GetById(0)).Returns(newperson);
            PersonService personService = new PersonService(mock.Object);

            //When
            var actual = personService.GetById(0);

            //Then
            Assert.Equal("test", actual.Name);
        }
        [Fact]
        public void GivenAPersonService_WhenGetByIDWithNonExistingId_GetNull()
        {
            //Given
            var mock = new Mock<IPersonRepository>();
            PersonService personService = new PersonService(mock.Object);

            //When
            var actual = personService.GetById(-1);

            //Then
            Assert.Null(actual);
        }
    }
}
