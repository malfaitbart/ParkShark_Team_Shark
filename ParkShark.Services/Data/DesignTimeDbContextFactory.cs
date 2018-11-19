using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ParkShark.Services.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ParkSharkContext>
    {
        private string _connectionstring = ".\\SQLExpress";
        public ParkSharkContext CreateDbContext(string[] args)
        {
            var foo = Environment.GetEnvironmentVariable("ParkSharkSql", EnvironmentVariableTarget.User);
            if (foo != null && foo.Equals("SqlServer"))
            {
                _connectionstring = "(LocalDb)\\MSSQLLocalDb";
            }
            var options = new DbContextOptionsBuilder<ParkSharkContext>()
                .UseSqlServer($"Data Source={_connectionstring};Initial Catalog=ParkShark;Integrated Security=True;")
                .EnableSensitiveDataLogging()
                .Options;

            return new ParkSharkContext(options);
        }
    }
}
