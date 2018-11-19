using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ParkShark.API;
using ParkShark.Services.Data;

namespace ParkShark.Integration.Tests
{
    public class TestStartup : Startup
    {
        public TestStartup(IConfiguration configuration, ILoggerFactory logFactory) : base(configuration, logFactory)
        {
        }

        protected override DbContextOptions<ParkSharkContext> ConfigureDbContext()
        {
            return new DbContextOptionsBuilder<ParkSharkContext>()
                .UseInMemoryDatabase("ParkSharkDb" + Guid.NewGuid().ToString("N")).Options;
        }

        protected override void ConfigureParkSharkServices(IServiceCollection services)
        {
            base.ConfigureParkSharkServices(services);

            //This is required for MVC to find our Controllers in our TestStartup
            services.AddMvc()
                .AddApplicationPart(typeof(Startup).Assembly);
        }
    }
}
