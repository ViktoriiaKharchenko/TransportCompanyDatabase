using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransportCompanyApp.Models
{
    public class Load
    {
        public Load()
        {
            Deliveries = new List<Delivery>();
        }
        public int Id { get; set; }
        public DateTime UploadDate { get; set; }
        public string Address { get; set; }
        public string CargoName { get; set; }
        public bool RequireADR { get; set; }
        public ICollection<Delivery> Deliveries { get; set; }
    }
}
