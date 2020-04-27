using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransportCompanyApp.Models
{
    public class DriversWagons
    {
        public DriversWagons()
        {
            Deliveries = new List<Delivery>();
        }
        public int Id { get; set; }
        public int DriverId { get; set; }
        public int WagonId { get; set; }
        public virtual Wagon Wagon { get; set; }
        public virtual Driver Driver { get; set; }
        public ICollection<Delivery> Deliveries {get; set;}

    }
}
