using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using NSubstitute;
using ParkShark.Infrastructure.Exceptions;
using ParkShark.Model.Addresses;
using ParkShark.Model.Allocations;
using ParkShark.Model.Parkinglots;
using ParkShark.Model.Persons;
using ParkShark.Model.Persons.LicensePlates;
using ParkShark.Services.Repositories.Allocations;
using ParkShark.Services.Repositories.Parkinglots;
using ParkShark.Services.Services.Allocations;
using ParkShark.Services.Services.Parkinglots;
using ParkShark.Services.Services.Persons;
using Xunit;

namespace ParkShark.Services.Tests.Services
{
    public class AllocationServicesTest
    {
        private readonly IParkinglotService _parkinglotService;
        private readonly IPersonService _personService;
        private readonly IAllocationRepository _allocationRepository;
        private readonly Person _testPerson;

        public AllocationServicesTest()
        {
            _parkinglotService = Substitute.For<IParkinglotService>();
            _personService = Substitute.For<IPersonService>();
            _allocationRepository = Substitute.For<IAllocationRepository>();

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
            _testPerson = new Person
            (
                1,
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
        }

        [Fact]
        public void GivenAnAllocationService_WhenStartAllocation_ThenANewLocationIsReturned()
        {
            //Given
            Allocation startAllocation = new Allocation(){MemberPersonId = 1, ParkinglotId = 1};
            Parkinglot parkinglot = new Parkinglot(){Id = 1};
            _parkinglotService.GetOneParkinglot(1).Returns(parkinglot);
            _personService.GetById(1).Returns(_testPerson);
            _parkinglotService.ReduceAvailableParkingSpots(parkinglot).Returns(true);
            _allocationRepository.SaveNewAllocation(startAllocation).Returns(startAllocation);
            var allocationService = new AllocationService(_allocationRepository, _parkinglotService, _personService);
            //When
            var returnAllocation = allocationService.StartAllocation(startAllocation, _testPerson.LicensePlate);

            //Then
            Assert.IsType<Allocation>(returnAllocation);
        }

        [Fact]
        public void GivenAnAllocationService_WhenStartAllocationWithDiffLiceplate_ThenExecptionThrown()
        {
            //Given
            Allocation startAllocation = new Allocation() { MemberPersonId = 1, ParkinglotId = 1 };
            Parkinglot parkinglot = new Parkinglot() { Id = 1 };
            _parkinglotService.GetOneParkinglot(1).Returns(parkinglot);
            _personService.GetById(1).Returns(_testPerson);
            _parkinglotService.ReduceAvailableParkingSpots(parkinglot).Returns(true);
            _allocationRepository.SaveNewAllocation(startAllocation).Returns(startAllocation);
            var allocationService = new AllocationService(_allocationRepository, _parkinglotService, _personService);
           
            //When
            Action action = () => allocationService.StartAllocation(startAllocation, 
                                                    new LicensePlate(){Country="BE", LicensePlateNumber = "Fout"});

            //Then
            var exception = Assert.Throws<EntityNotValidException>(action);
            Assert.Contains("the following entity was found to be invalid", exception.Message);

        }

    }
}
