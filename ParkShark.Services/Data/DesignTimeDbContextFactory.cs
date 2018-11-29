using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace ParkShark.Services.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ParkSharkContext>
    {

        public readonly ILoggerFactory efLoggerFactory
            = new LoggerFactory(new[] { new ConsoleLoggerProvider((category, level) => category.Contains("Command") && level == LogLevel.Information, true), });

        public DesignTimeDbContextFactory(ILoggerFactory efLoggerFactory)
        {
            this.efLoggerFactory = efLoggerFactory;
        }

        private string _connectionstring = ".\\SQLExpress";
        public ParkSharkContext CreateDbContext(string[] args)
        {
            //Great way to overcome a real-life problem (using env variables), I love the pragmatic approach/solution
            //However, this code looks to be written in a hurry, refactoring is due (remove foo)
            var foo = Environment.GetEnvironmentVariable("ParkSharkSql", EnvironmentVariableTarget.User);
            if (foo != null && foo.Equals("SqlServer"))
            {
                _connectionstring = "(LocalDb)\\MSSQLLocalDb";
            }
            var options = new DbContextOptionsBuilder<ParkSharkContext>()
                .UseSqlServer($"Data Source={_connectionstring};Initial Catalog=ParkShark;Integrated Security=True;")
                .EnableSensitiveDataLogging()
                .UseLoggerFactory(efLoggerFactory)
                .Options;

            return new ParkSharkContext(options, efLoggerFactory);
        }
    }
}
