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
using Xunit;

namespace ParkShark.Integration.Tests.Controllers
{
    public class ParkinglotControllerIntegrationTests
    //public class ParkinglotControllerIntegrationTests
    {
        private static DbContextOptions<ParkSharkContext> CreateNewInMemoryDatabase()
        {
            return new DbContextOptionsBuilder<ParkSharkContext>()
                .UseInMemoryDatabase("ParkSharkDb" + Guid.NewGuid().ToString("N")).Options;
        }

        [Fact]
        public async Task Createparkinglot_WhenCreatingNewParkinglot_ThenReturnStatusCode201WithParkinglotDto()
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
                await context.SaveChangesAsync();
                #endregion fillingInMemoryDatabase


                ParkinglotDto parkinglotDtoToCreate = new ParkinglotDto()
                {
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
                var content = JsonConvert.SerializeObject(parkinglotDtoToCreate);
                var stringContent = new StringContent(content, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("api/parkinglots", stringContent);

                var responseString = await response.Content.ReadAsStringAsync();
                ParkinglotDto parkinglotDtoCreated = JsonConvert.DeserializeObject<ParkinglotDto>(responseString);

                Assert.True(response.IsSuccessStatusCode);
                Assert.Equal("Name", parkinglotDtoCreated.Name);
            }
        }

        [Fact]
        public async Task GetAllParkinglots_WhenGetAllParkinglots_ThenReturnParkinglotDtoList()
        {
            var server = new TestServer(new WebHostBuilder()
                .UseStartup<TestStartup>());

            using (server)
            {
                var client = server
                    .CreateClient();

                var context = server.Host.Services.GetService<ParkSharkContext>();


                var response = await client.GetAsync("api/parkinglots");

                var responseString = await response.Content.ReadAsStringAsync();
                List<ParkinglotDto> parkinglotDtoList = JsonConvert.DeserializeObject<List<ParkinglotDto>>(responseString);

                Assert.True(response.IsSuccessStatusCode);
                Assert.IsType<List<ParkinglotDto>>(parkinglotDtoList);
            }
        }

        [Fact]
        public async Task GetOneParkinglot_WhenGetOneParkinglot_ThenReturnParkinglotDto()
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

                Parkinglot parkinglot = new Parkinglot()
                {
                    BuildingTypeId = 1,
                    Capacity = 5,
                    ContactPersonId = 1,
                    DivisionId = 1,
                    Name = "Name",
                    Id = 1,
                    PlAddress = new Address()
                    {
                        StreetNumber = "1",
                        StreetName = "tt",
                        CityName = "er",
                        PostalCode = "4153"
                    },
                    PricePerHour = 10
                };
                context.Add(parkinglot);
                await context.SaveChangesAsync();
                #endregion fillingInMemoryDatabase

                var response = await client.GetAsync("api/parkinglots/1");

                var responseString = await response.Content.ReadAsStringAsync();
                ParkinglotDto parkinglotDto = JsonConvert.DeserializeObject<ParkinglotDto>(responseString);

                Assert.True(response.IsSuccessStatusCode);
                Assert.IsType<ParkinglotDto>(parkinglotDto);
            }
        }

        [Fact]
        public async Task GetOneParkinglot_WhenGetOneNonExistingParkinglot_ThenReturnBadRequest()
        {
            var server = new TestServer(new WebHostBuilder()
                .UseStartup<TestStartup>());

            using (server)
            {
                var client = server
                    .CreateClient();

                var context = server.Host.Services.GetService<ParkSharkContext>();

                var response = await client.GetAsync("api/parkinglots/5");

                Assert.False(response.IsSuccessStatusCode);

            }
        }
    }
}
