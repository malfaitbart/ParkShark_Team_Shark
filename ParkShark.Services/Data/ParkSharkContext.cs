using Microsoft.EntityFrameworkCore;
using ParkShark.Model.Divisions;

namespace ParkShark.Services.Data
{
    public class ParkSharkContext : DbContext
    {
        public ParkSharkContext()
        {
        }

        public ParkSharkContext(DbContextOptions<ParkSharkContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Division>()
                .ToTable("Divisions")
                .HasKey("ID");
        }
    }
}
