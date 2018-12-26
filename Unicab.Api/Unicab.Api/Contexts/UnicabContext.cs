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
        public DbSet<CabRequestFulfillment> CabRequestFulfillments { get; set; }

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

            modelBuilder.Entity<CarpoolOffer>()
                .HasOne(b => b.OriginLocation)
                .WithMany();

            modelBuilder.Entity<CarpoolOffer>()
                .HasOne(p => p.DestinationLocation)
                .WithMany();

            modelBuilder.Entity<CabRequest>()
                .HasOne(p => p.PickUpLocation)
                .WithMany();

            modelBuilder.Entity<CabRequest>()
                .HasOne(p => p.DropOffLocation)
                .WithMany();
        }
    }
}
