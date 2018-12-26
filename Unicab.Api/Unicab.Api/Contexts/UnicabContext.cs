using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unicab.Api.Models;

namespace Unicab.Api.Contexts
{
    public class UnicabContext : DbContext
    {
        public DbSet<DriverApplicant> DriverApplicants { get; set; }
        public DbSet<PassengerApplicant> PassengerApplicants { get; set; }

        public DbSet<DriverBlacklist> DriverBlacklists { get; set; }
        public DbSet<PassengerBlacklist> PassengerBlacklists { get; set; }

        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Admin> Admins { get; set; }

        public DbSet<CarpoolOffer> CarpoolOffers { get; set; }
        public DbSet<CarpoolOfferFulfillment> CarpoolOfferFulfillments { get; set; }

        public DbSet<CabRequest> CabRequests { get; set; }
        
        public DbSet<RatingFeedback> RatingFeedbacks { get; set; }

        public DbSet<Location> Locations { get; set; }

        public UnicabContext(DbContextOptions<UnicabContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DriverApplicant>()
                .Property(b => b.AddedDateTime)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Driver>()
                .Property(b => b.AddedDateTime)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<PassengerApplicant>()
                .Property(b => b.AddedDateTime)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Passenger>()
                .Property(b => b.AddedDateTime)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Admin>()
                .Property(b => b.AddedDateTime)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<CabRequest>()
                .Property(b => b.AddedDateTime)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<CarpoolOffer>()
                .Property(b => b.AddedDateTime)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Location>()
                .Property(b => b.AddedDateTime)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<CarpoolOffer>(fk =>
            {
                fk.HasOne(f => f.DestinationLocation)
                .WithMany()
                .HasForeignKey(p => p.DestinationLocationId)
                .OnDelete(DeleteBehavior.Restrict);

                fk.HasOne(f => f.OriginLocation)
                .WithMany()
                .HasForeignKey(p => p.OriginLocationId)
                .OnDelete(DeleteBehavior.Restrict);

            });

            modelBuilder.Entity<CabRequest>(fk =>
            {
                fk.HasOne(f => f.PickUpLocation)
                .WithMany()
                .HasForeignKey(p => p.PickUpLocationId)
                .OnDelete(DeleteBehavior.Restrict);

                fk.HasOne(f => f.DropOffLocation)
                .WithMany()
                .HasForeignKey(p => p.DropOffLocationId)
                .OnDelete(DeleteBehavior.Restrict);

            });
        }
    }
}
