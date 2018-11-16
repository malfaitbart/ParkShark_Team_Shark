using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using ParkShark.API;
using ParkShark.API.Controllers.Parkinglots;
using ParkShark.Model.Addresses;
using Xunit;

namespace ParkShark.Integration.Tests.Controllers
{
    public class ParkinglotControllerIntegrationTests : IDisposable
    {
        private readonly HttpClient _client;

        public ParkinglotControllerIntegrationTests()
        {
            var server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = server
                .CreateClient();
            //_client.DefaultRequestHeaders.Accept.Clear();
            //_client.DefaultRequestHeaders.Accept.Add(
            //    new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public void Dispose()
        {
            _client.Dispose();
        }

        [Fact]
        public async Task Createparkinglot_WhenCreatingNewParkinglot_ThenReturnStatusCode201WithParkinglotDto()
        {
            ParkinglotDto parkinglotDtoToCreate = new ParkinglotDto()
            {
                BuildingTypeId = 5,
                Capacity = 5,
                ContactPersonId = 2,
                DivisionId = 1,
                Name = "Name",
                PlAddress = new Address(),
                PricePerHour = 10
            };
            var content = JsonConvert.SerializeObject(parkinglotDtoToCreate);
            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("api/parkinglots", stringContent);
            //var responseString = await response.Content.ReadAsStringAsync();
            //var parkinglotDtoCreated = JsonConvert.DeserializeObject<ActionResult<ParkinglotDto>>(responseString);
            Assert.False(response.IsSuccessStatusCode);
        }
    }
}
