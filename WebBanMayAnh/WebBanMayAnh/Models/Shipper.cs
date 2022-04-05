using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebBanMayAnh.Models
{
    public class Shipper
    {
        [Key]
        public int ShipperID { get; set; }
        public string ShipperName { get; set; }
        public string Phone { get; set; }
        public string Company { get; set; }
        public DateTime ShipDate { get; set; }
        public IEnumerable<Order> Orders   { get; set; }
    }
}
