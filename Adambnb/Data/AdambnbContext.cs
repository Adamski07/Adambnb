using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Adambnb.Models;

namespace Adambnb.Data
{
    public class AdambnbContext : DbContext
    {
        public DbSet<Costumer> Costumers { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<LandLord> LandLords { get; set; }

        public AdambnbContext(DbContextOptions<AdambnbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Costumer)
                .WithMany(c => c.Reservations)
                .HasForeignKey(r => r.CostumerId);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Location)
                .WithMany(l => l.Reservations)
                .HasForeignKey(r => r.LocationId);

            modelBuilder.Entity<Image>()
                .HasOne(i => i.Location)
                .WithMany(l => l.Images)
                .HasForeignKey(i => i.LocationId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Location>()
                .HasOne(l => l.LandLord)
                .WithMany(ll => ll.Locations)
                .HasForeignKey(l => l.LandLordId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<LandLord>()
                .HasOne(ll => ll.Avatar)
                .WithOne(i => i.LandLord)
                .HasForeignKey<Image>(i => i.LandLordId)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
