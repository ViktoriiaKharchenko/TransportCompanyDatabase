using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TransportCompanyApp.Models
{
    public class Trailer
    {
        public int Id { get; set; }
        public int Volume { get; set; }
        public int CarryingCapacity { get; set; }
        public int TrailerTypeId { get; set; }
        
        [ForeignKey("TrailerTypeId")]
        public virtual TrailerType TrailerType { get; set; }
    }
}
