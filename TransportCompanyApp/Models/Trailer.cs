using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransportCompanyApp.Models
{
    public class Trailer
    {
        public Trailer()
        {
            Wagons = new List<Wagon>();
        }
        public int Id { get; set; }
        public int Volume { get; set; }
        public int CarryingCapacity { get; set; }
        public int TrailerTypeId { get; set; }
        public virtual TrailerType TrailerType { get; set; }
        public virtual ICollection <Wagon> Wagons { get; set; }
    }
}
