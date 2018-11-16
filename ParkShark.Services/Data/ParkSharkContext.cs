using Microsoft.EntityFrameworkCore;
using ParkShark.Model.Divisions;
using ParkShark.Model.Parkinglots;
using ParkShark.Model.Parkinglots.BuildingTypes;
using ParkShark.Model.Persons;

namespace ParkShark.Services.Data
{
    public partial class ParkSharkContext : DbContext
    {
        public virtual DbSet<Division> Divisions { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Parkinglot> Parkinglots { get; set; }

        public ParkSharkContext(DbContextOptions<ParkSharkContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Division>()
                .ToTable("Divisions")
                .HasKey("ID");

            modelBuilder.Entity<Division>()
                .HasOne(d => d.ParentDivision)
                .WithMany(pd => pd.Divisions)
                .HasForeignKey(d => d.ParentDivisionId)
                .OnDelete(DeleteBehavior.Restrict);
                

            modelBuilder.Entity<Division>()
                .HasOne(d => d.Director)
                .WithMany()
                .HasForeignKey(d => d.DirectorID)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Person>()
                .ToTable("Persons")
                .HasKey("Id");

            modelBuilder.Entity<Person>()
                .OwnsOne(person => person.PersonAddress,
                    personAddress =>
                    {
                        personAddress.Property(prop => prop.StreetName).HasColumnName("StreetName");
                        personAddress.Property(prop => prop.StreetNumber).HasColumnName("StreetNumber");
                        personAddress.Property(prop => prop.PostalCode).HasColumnName("PostalCode");
                        personAddress.Property(prop => prop.CityName).HasColumnName("CityName");
                    });

            modelBuilder.Entity<Parkinglot>()
                .ToTable("ParkingLots")
                .HasKey("Id");

            modelBuilder.Entity<Parkinglot>()
                .OwnsOne(parkinglot => parkinglot.PlAddress,
                    plAddress =>
                    {
                        plAddress.Property(prop => prop.StreetName).HasColumnName("StreetName");
                        plAddress.Property(prop => prop.StreetNumber).HasColumnName("StreetNumber");
                        plAddress.Property(prop => prop.PostalCode).HasColumnName("PostalCode");
                        plAddress.Property(prop => prop.CityName).HasColumnName("CityName");
                    });

            modelBuilder.Entity<Parkinglot>()
                .HasOne(pl => pl.PlDivision)
                .WithMany(d => d.Parkinglots)
                .HasForeignKey(pl => pl.DivisionId)
                .IsRequired();

            modelBuilder.Entity<Parkinglot>()
                .HasOne(pl => pl.PlBuildingType)
                .WithMany()
                .HasForeignKey(pl => pl.BuildingTypeId)
                .IsRequired();

            modelBuilder.Entity<Parkinglot>()
                .HasOne(pl => pl.ContactPerson)
                .WithMany()
                .HasForeignKey(pl => pl.ContactPersonId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BuildingType>()
                .ToTable("BuildingTypes")
                .HasKey("Id");

            base.OnModelCreating(modelBuilder);

            SeedData(modelBuilder);
        }
    }
}