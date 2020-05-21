using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TransportCompanyApp.Models
{
    public class WagonDto
    {
        public Wagon wagon { get; set; }
        public Trailer trailer { get; set; }
        public TrailerType trailerType { get; set; }
    }
}
