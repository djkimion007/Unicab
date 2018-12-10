using Microsoft.EntityFrameworkCore;
using Unicab.Api.Models;

namespace Unicab.Api.Contexts
{
    public class UsersContext : DbContext
    {
        public DbSet<DriverApplicant> DriverApplicants { get; set; }
        public DbSet<PassengerApplicant> PassengerApplicants { get; set; }

        public DbSet<DriverBlacklist> DriverBlacklists { get; set; }
        public DbSet<PassengerBlacklist> PassengerBlacklists { get; set; }

        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Admin> Admins { get; set; }

        public UsersContext(DbContextOptions<UsersContext> options) : base(options)
        {

        }
    }
}
