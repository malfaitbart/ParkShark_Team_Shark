using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ParkShark.Services.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ParkSharkContext>
    {
        public ParkSharkContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<ParkSharkContext>()
                .UseSqlServer("Data Source=.\\SQLExpress;Initial Catalog=ParkShark;Integrated Security=True;")
                .Options;

            return new ParkSharkContext(options);
        }
    }
}
