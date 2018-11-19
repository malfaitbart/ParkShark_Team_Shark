using System;
using System.Collections.Generic;
using System.Text;
using NSubstitute;
using ParkShark.Model.Allocations;
using ParkShark.Model.Parkinglots;
using ParkShark.Services.Repositories.Allocations;
using ParkShark.Services.Repositories.Parkinglots;
using ParkShark.Services.Services.Allocations;
using ParkShark.Services.Services.Parkinglots;
using Xunit;

namespace ParkShark.Services.Tests.Services
{
    public class AllocationServicesTest
    {
        [Fact]
        public void GivenAnAllocationService_WhenStartAllocation_ThenANewLocationIsReturned()
        {
            //Given
            Allocation startAllocation = new Allocation();

            IAllocationRepository allocationRepository = Substitute.For<IAllocationRepository>();
            var allocationService = new AllocationService(allocationRepository);
            //When
            var returnAllocation = allocationService.StartAllocation(startAllocation);

            //Then
            Assert.IsType<Allocation>(returnAllocation);
        }

    }
}
