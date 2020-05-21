using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TransportCompanyApp.Models
{
    public class Wagon
    {
        internal Wagon wagon;

        public Wagon(){
            DriversWagons = new List<DriversWagons>();
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        public string WagonNum { get; set; }
        public int TrailerId { get; set; }
        [ForeignKey("TrailerId")]
        public virtual Trailer Trailer { get; set; }
        public ICollection<DriversWagons> DriversWagons { get; set; }

    }
}
