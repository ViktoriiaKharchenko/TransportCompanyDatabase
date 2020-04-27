using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransportCompanyApp.Models
{
    public class TrailerType
    {
        public TrailerType()
        {
            Trailers = new List<Trailer>();
        }
        public int Id { get; set; }

        public string Type { get; set; }
        public virtual ICollection<Trailer> Trailers { get; set; }

    }
}
