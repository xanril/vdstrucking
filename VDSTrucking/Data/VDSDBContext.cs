using System;
using Microsoft.EntityFrameworkCore;
using VDSTrucking.Models;

namespace VDSTrucking.Data
{
    public class VDSDBContext : DbContext
    {
        public VDSDBContext(DbContextOptions<VDSDBContext> options) : base(options)
        {
        }

        public DbSet<Truck> Trucks { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Helper> Helpers { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<ParticularItem> ParticularItems { get; set; }
        public DbSet<Particular> Particulars { get; set; }
        public DbSet<Trip> Trips { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Truck>().ToTable("Trucks");
            modelBuilder.Entity<Driver>().ToTable("Drivers");
            modelBuilder.Entity<Helper>().ToTable("Helpers");
            modelBuilder.Entity<Location>().ToTable("Locations");
            modelBuilder.Entity<Route>().ToTable("Routes");
            modelBuilder.Entity<ParticularItem>().ToTable("ParticularItems");
            modelBuilder.Entity<Particular>().ToTable("Particulars");
            modelBuilder.Entity<Trip>().ToTable("Trips");
        }
    }
}
