using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransportCompanyApp.Models
{
    public class Driver
    {
        public Driver()
        {
            DriversWagons = new List<DriversWagons>();
        }
        public int Id { get; set; }
        public string FullName { get; set; }
        public string PassportNum { get; set; }
        public string DriverLicenseNum { get; set; }
        public bool ADRCertificate { get; set; }
        public ICollection<DriversWagons> DriversWagons {get;set;}
    }
}
