using Microsoft.EntityFrameworkCore;
using SRMSS.Models;

namespace SRMSS.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public DbSet<User> Users { get; set; }

        public DbSet<Bus> Buses { get; set; }

        public DbSet<Driver> Drivers { get; set; }

        public DbSet<SRMSS.Models.Route> Routes { get; set; }

        public DbSet<RouteManagementDetail> RouteManagementDetails { get; set; }

        public DbSet<Schedule> Schedules { get; set; }

        public DbSet<Trip> Trips { get; set; }

        public DbSet<FuelLog> FuelLogs { get; set; }

        public DbSet<Maintenance> Maintenance { get; set; }


        // ADD THIS FOR VEHICLE MANAGEMENT
        public DbSet<Vehicle> Vehicles { get; set; }


        // ADD THIS FOR FUEL MANAGEMENT
        public DbSet<FuelRecord> FuelRecords { get; set; }

    }
}