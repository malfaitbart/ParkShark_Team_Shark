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

namespace ParkShark.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration, ILoggerFactory logFactory)
        {
            Configuration = configuration;
            ApplicationLogging.LoggerFactory = logFactory;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var options = new DbContextOptionsBuilder<ParkSharkContext>()
                .UseSqlServer("Data Source=.\\SQLExpress;Initial Catalog=ParkShark;Integrated Security=True;")
                .Options;

            services.AddSingleton<DbContextOptions<ParkSharkContext>>(options);

            services.AddSingleton<IDivisionRepository, DivisionRepository>();
            services.AddSingleton<IParkinglotRepository, ParkinglotRepository>();

            services.AddSingleton<IDivisionService, DivisionService>();
            services.AddSingleton<IParkinglotService, ParkinglotService>();


            services.AddSingleton<ParkinglotMapper>();
            services.AddSingleton<DivisionMapper>();

            services.AddTransient<ParkSharkContext>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSwagger();
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
