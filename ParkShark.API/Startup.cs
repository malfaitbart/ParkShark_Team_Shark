using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NJsonSchema;
using NSwag.AspNetCore;
using ParkShark.API.Controllers.Divisions;
using ParkShark.API.Controllers.Parkinglots;
using ParkShark.Infrastructure.Exceptions;
using ParkShark.Infrastructure.Logging;
using ParkShark.Services.Data;
using ParkShark.Services.Services.Divisions;
using ParkShark.Services.Repositories.Divisions;
using ParkShark.Services.Repositories.Parkinglots;
using ParkShark.Services.Services.Parkinglots;
using ParkShark.Model.Parkinglots;
using ParkShark.Model.Divisions;
using ParkShark.Infrastructure.DtoMapper;
using ParkShark.Services.Repositories.Persons;
using ParkShark.Services.Services.Persons;
using ParkShark.API.Controllers.Persons;

namespace ParkShark.API
{
    public class Startup
    {
        //private string _connectionstring = "(LocalDb)\\MSSQLLocalDb";
        private string _connectionstring = ".\\SQLExpress";
        //TODO Zie: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/environments?view=aspnetcore-2.1
        public Startup(IConfiguration configuration, ILoggerFactory logFactory, IHostingEnvironment env)
        {
            Configuration = configuration;
            ApplicationLogging.LoggerFactory = logFactory;
            //var foo = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var foo = Environment.GetEnvironmentVariable("ParkSharkSql", EnvironmentVariableTarget.User);
            if (foo != null && foo.Equals("SqlServer"))
            {
                _connectionstring = "(LocalDb)\\MSSQLLocalDb";
            }
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureParkSharkServices(services);
        }

        protected virtual void ConfigureParkSharkServices(IServiceCollection services)
        {
            services.AddSingleton<DbContextOptions<ParkSharkContext>>(ConfigureDbContext());

            services.AddSingleton<IDivisionRepository, DivisionRepository>();
            services.AddSingleton<IParkinglotRepository, ParkinglotRepository>();
            services.AddSingleton<IPersonRepository, PersonRepository>();

            services.AddSingleton<IDivisionService, DivisionService>();
            services.AddSingleton<IParkinglotService, ParkinglotService>();
            services.AddSingleton<IPersonService, PersonService>();

            services.AddSingleton<ParkinglotMapper>();
            services.AddSingleton<DivisionMapper>();
            services.AddSingleton<PersonMapper>();

            services.AddTransient<ParkSharkContext>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSwagger();
        }

        protected virtual DbContextOptions<ParkSharkContext> ConfigureDbContext()
        {
            
            return new DbContextOptionsBuilder<ParkSharkContext>()
                .UseSqlServer($"Data Source={_connectionstring};Initial Catalog=ParkShark;Integrated Security=True;")
                //(LocalDb)\\MSSQLLocalDb
                .Options;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }         

            app.UseSwaggerUi3WithApiExplorer(settings =>
            {
                settings.GeneratorSettings.DefaultPropertyNameHandling =
                    PropertyNameHandling.CamelCase;
            });
            //app.UseHttpsRedirection();
            app.UseMiddleware(typeof(ErrorHandlingMiddleware));
            app.UseMvc();
        }
    }
}
