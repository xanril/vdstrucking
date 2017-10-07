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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Truck>().ToTable("Trucks");
        }
    }
}
