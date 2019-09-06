using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vega.Core.Models;

namespace Vega.Persistence
{
    public class VegaDbContext : DbContext
    {
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Photo> Photos { get; set; }

        public VegaDbContext(DbContextOptions<VegaDbContext> options) : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleFeature>().HasKey(vf => new { vf.VehicleId, vf.FeatureId });

            modelBuilder.Entity<VehicleFeature>().HasOne(vf => vf.Vehicle).WithMany(v => v.Features).HasForeignKey(vf => vf.VehicleId);

            modelBuilder.Entity<VehicleFeature>().HasOne(vf => vf.Feature).WithMany(f => f.Vehicles).HasForeignKey(vf => vf.FeatureId);
        }
    }
}
