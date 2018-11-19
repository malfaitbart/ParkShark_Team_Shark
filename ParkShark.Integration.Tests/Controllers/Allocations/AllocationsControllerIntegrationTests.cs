using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using ParkShark.API.Controllers.Parkinglots;
using ParkShark.Model.Addresses;
using ParkShark.Model.Divisions;
using ParkShark.Model.Parkinglots;
using ParkShark.Model.Parkinglots.BuildingTypes;
using ParkShark.Model.Persons;
using ParkShark.Model.Persons.LicensePlates;
using ParkShark.Services.Data;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ParkShark.API.Controllers.Allocations;
using Xunit;

namespace ParkShark.Integration.Tests.Controllers.Allocations
{
   public class AllocationsControllerIntegrationTests
    {
        private static DbContextOptions<ParkSharkContext> CreateNewInMemoryDatabase()
        {
            return new DbContextOptionsBuilder<ParkSharkContext>()
                .UseInMemoryDatabase("ParkSharkDb" + Guid.NewGuid().ToString("N")).Options;
        }

        [Fact]
        public async Task StartAllocation_WhenStartNewAllocation_ThenReturnStatusCode201WithAllocationGuid()
        {
            var server = new TestServer(new WebHostBuilder()
                .UseStartup<TestStartup>());

            using (server)
            {
                var client = server
                    .CreateClient();

                var context = server.Host.Services.GetService<ParkSharkContext>();


                #region fillingInMemoryDatabase

                Address adress = new Address()
                {
                    StreetNumber = "1",
                    StreetName = "tt",
                    CityName = "er",
                    PostalCode = "4153",
                };
                context.Persons.Add(new Person(
                    1,
                    "Person1",
                    "MobilePhone1",
                    "000",
                    adress,
                    "EmailAdress@test.be",
                    new LicensePlate()
                ));

                context.Set<BuildingType>().Add(new BuildingType()
                {
                    Id = 1,
                    Name = "Underground"
                });

                context.Divisions.Add(new Division()
                {
                    ID = 1,
                    Name = "Division1",
                    OriginalName = "Original1",
                    DirectorID = 1
                });

                Parkinglot parkinglotToCreate = new Parkinglot()
                {
                    Id = 1,
                    BuildingTypeId = 1,
                    Capacity = 5,
                    ContactPersonId = 1,
                    DivisionId = 1,
                    Name = "Name",
                    PlAddress = new Address()
                    {
                        StreetNumber = "1",
                        StreetName = "tt",
                        CityName = "er",
                        PostalCode = "4153"
                    },
                    PricePerHour = 10
                };
                context.Add(parkinglotToCreate);
                await context.SaveChangesAsync();

                #endregion fillingInMemoryDatabase

                AllocationDto allocationDto = new AllocationDto()
                {
                    MemberPeronId = 1,
                    ParkinglotId = 1
                };

                var content = JsonConvert.SerializeObject(allocationDto);
                var stringContent = new StringContent(content, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("api/allocations", stringContent);

                //var responseString = await response.Content.ReadAsStringAsync();
                // string allocationGuid = JsonConvert.DeserializeObject<string>(responseString);

                Assert.True(response.IsSuccessStatusCode);
            }
        }

        [Fact]
        public async Task StartAllocation_WhenStartNewAllocationWithBadInfo_ThenReturnBadRequest()
        {
            var server = new TestServer(new WebHostBuilder()
                .UseStartup<TestStartup>());

            using (server)
            {
                var client = server
                    .CreateClient();

                var context = server.Host.Services.GetService<ParkSharkContext>();


                AllocationDto allocationDto = new AllocationDto()
                {
                    MemberPeronId = 1,
                    ParkinglotId = 1
                };

                var content = JsonConvert.SerializeObject(allocationDto);
                var stringContent = new StringContent(content, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("api/allocations", stringContent);

                Assert.False(response.IsSuccessStatusCode);
            }

        }
    }
}
