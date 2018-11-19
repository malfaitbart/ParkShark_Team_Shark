using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using ParkShark.API;
using ParkShark.API.Controllers.Parkinglots;
using ParkShark.Model.Addresses;
using ParkShark.Model.Divisions;
using ParkShark.Model.Parkinglots.BuildingTypes;
using ParkShark.Model.Persons;
using ParkShark.Services.Data;
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
                context.Persons.Add(new Person()
                {
                    Id = 1,
                    Name = "Person1",
                    MobilePhone = "MobilePhone1",
                    EmailAdress = "EmailAdress@test.be",
                    PersonAddress = adress
                });

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
    }
}
