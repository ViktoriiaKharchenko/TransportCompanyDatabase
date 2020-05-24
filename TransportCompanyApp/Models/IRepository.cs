using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransportCompanyApp.Models
{
    public interface IRepository
    {
        DbSet<TrailerType> TrailerTypes { get; set; }
        DbSet<Trailer> Trailers { get; set; }
        DbSet<Driver> Drivers { get; set; }
        DbSet<Wagon> Wagons { get; set; }
        DbSet<DriversWagons> DriversWagons { get; set; }
        DbSet<Load> Loads { get; set; }
        DbSet<CustomerCompany> CustomerCompanies { get; set; }
        DbSet<Delivery> Deliveries { get; set; }
        void MarkAsModified<T>(T item);
        EntityEntry Entry(object entity);
        Task Save();
    }

}
