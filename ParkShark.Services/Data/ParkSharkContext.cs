using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using ParkShark.Model.Allocations;
using ParkShark.Model.Divisions;
using ParkShark.Model.MemberShips;
using ParkShark.Model.Parkinglots;
using ParkShark.Model.Parkinglots.BuildingTypes;
using ParkShark.Model.Persons;

namespace ParkShark.Services.Data
{
    public partial class ParkSharkContext : DbContext
    {
        private readonly ILoggerFactory _loggerFactory;

        public virtual DbSet<Division> Divisions { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Parkinglot> Parkinglots { get; set; }
        public virtual DbSet<Allocation> Allocations { get; set; }
        public virtual DbSet<MemberShip> MemberShips { get; set; }

        public ParkSharkContext(DbContextOptions<ParkSharkContext> options, ILoggerFactory loggerFactory) : base(options)
        {
            _loggerFactory = loggerFactory;
        }

        public ParkSharkContext(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseLoggerFactory(_loggerFactory);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Division>()
                .ToTable("Divisions")
                .HasKey(d=>d.Id);

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

            modelBuilder.Entity<Division>()
                .Property(prop => prop.Id).HasColumnName("ID");

            modelBuilder.Entity<Person>()
                .ToTable("Persons")
                .HasKey(p=>p.Id);

            modelBuilder.Entity<Person>()
                .OwnsOne(person => person.PersonAddress,
                    pa =>
                    {
                        pa.Property(prop => prop.StreetName).HasColumnName("StreetName");
                        pa.Property(prop => prop.StreetNumber).HasColumnName("StreetNumber");
                        pa.Property(prop => prop.PostalCode).HasColumnName("PostalCode");
                        pa.Property(prop => prop.CityName).HasColumnName("CityName");
                    });

            modelBuilder.Entity<Person>()
                .OwnsOne(person => person.LicensePlate,
                    licensePlate =>
                    {
                        licensePlate.Property(prop => prop.LicensePlateNumber).HasColumnName("LicensePlateNumber");
                        licensePlate.Property(prop => prop.Country).HasColumnName("Country");
                    });

            modelBuilder.Entity<Parkinglot>()
                .ToTable("ParkingLots")
                .HasKey(pl=>pl.Id);

            modelBuilder.Entity<Parkinglot>()
                .OwnsOne(parkinglot => parkinglot.PlAddress,
                    plAddress =>
                    {
                        plAddress.Property(prop => prop.StreetName).HasColumnName("StreetName");
                        plAddress.Property(prop => prop.StreetNumber).HasColumnName("StreetNumber");
                        plAddress.Property(prop => prop.PostalCode).HasColumnName("PostalCode");
                        plAddress.Property(prop => prop.CityName).HasColumnName("CityName");
                    });

            modelBuilder.Entity<MemberShip>()
                .ToTable("MemberShips")
                .HasKey(ms=>ms.Id);

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
                .HasKey(bt=>bt.Id);

            modelBuilder.Entity<Allocation>()
                .ToTable("Allocations")
                .HasKey(a=>a.Id);

            modelBuilder.Entity<Allocation>()
                .HasOne(al => al.MemberPerson)
                .WithMany()
                .HasForeignKey(al => al.MemberPeronId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Allocation>()
                .HasOne(al => al.Parkinglot)
                .WithMany()
                .HasForeignKey(al => al.ParkinglotId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Person>()
                .HasOne(p => p.MemberShip)
                .WithMany()
                .HasForeignKey(p => p.MembershipId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);

            SeedData(modelBuilder);
        }
    }
}