using Microsoft.EntityFrameworkCore;
using ParkShark.Model.Divisions;

namespace ParkShark.Services.Data
{
    public class ParkSharkContext : DbContext
    {
        private readonly string connectionString;

        public ParkSharkContext()
        {
            connectionString = "Data Source=.\\SQLExpress;Initial Catalog=ParkShark;Integrated Security=True;";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(this.connectionString);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Division>()
                .ToTable("Divisions")
                .HasKey("ID");

        }

    }
}
