using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransportCompanyApp.Models
{
    public class Delivery
    {
        public int Id { get; set; }
        public int DriverWagonId { get; set; }
        public int CustomerCompanyId { get; set; }
        public int LoadId { get; set; }
        public DateTime UnloadDate { get; set; }
        public string Address { get; set; }
        public DriversWagons DriverWagon { get; set; }
        public Load Load { get; set; }
        public CustomerCompany CustomerCompany { get; set; }
    }
}
