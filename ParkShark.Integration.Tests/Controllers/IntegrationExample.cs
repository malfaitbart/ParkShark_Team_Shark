using System;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using ParkShark.API;

namespace ParkShark.Integration.Tests.Controllers
{
    public class IntegrationExample: IDisposable
    {
        private readonly HttpClient _client;

        public IntegrationExample()
        {
            _client = new TestServer(new WebHostBuilder()
                    .UseStartup<Startup>())
                .CreateClient();
        }

        public void Dispose()
        {
            _client.Dispose();
        }
    }
}
