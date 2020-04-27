using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransportCompanyApp.Models
{
    public class TransportCompanyDatabaseContext : DbContext
    {
        public virtual DbSet<TrailerType> TrailerTypes { get; set; }
        public virtual DbSet<Trailer> Trailers { get; set; }
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<Wagon> Wagons { get; set; }
        public virtual DbSet<DriversWagons> DriversWagons { get; set; }
        public virtual DbSet<Load> Loads { get; set; }
        public virtual DbSet<CustomerCompany> CustomerCompanies { get; set; }
        public virtual DbSet<Delivery> Deliveries { get; set; }

        public TransportCompanyDatabaseContext(DbContextOptions<TransportCompanyDatabaseContext> options)
            :base(options)
        {
            Database.EnsureCreated();
        }
    }
}
