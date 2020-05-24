using Castle.Core.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransportCompanyApp.Models
{
    public class TransportCompanyDatabaseContext : DbContext, IRepository
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

        public void MarkAsModified<T>(T item)
        {
            Entry(item).State = EntityState.Modified;
        }

        public Task Save()
        {
            return SaveChangesAsync();
        }
    }
}
