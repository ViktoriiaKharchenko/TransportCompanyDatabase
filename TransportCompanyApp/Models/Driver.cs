using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        public string PassportNum { get; set; }
        [Required(ErrorMessage = "Поле  не повинно бути порожнім")]
        public string DriverLicenseNum { get; set; }
        public bool ADRCertificate { get; set; }
        public ICollection<DriversWagons> DriversWagons {get;set;}
    }
}
