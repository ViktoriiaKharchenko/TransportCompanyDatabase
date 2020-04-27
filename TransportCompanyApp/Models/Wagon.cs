using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransportCompanyApp.Models
{
    public class Wagon
    {
        public Wagon(){
            DriversWagons = new List<DriversWagons>();
        }
        public int Id { get; set; }

        string WagonNum { get; set; }
        public int TrailerId { get; set; }
        public virtual Trailer Trailer { get; set; }
        public ICollection<DriversWagons> DriversWagons { get; set; }

    }
}
