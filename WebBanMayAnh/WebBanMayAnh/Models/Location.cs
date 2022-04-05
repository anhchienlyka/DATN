using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebBanMayAnh.Models
{
    public class Location
    {
        [Key]
        public int LocationID { get; set; }
        public string Name { get; set; }
        public int Parent { get; set; }
        public int Levels { get; set; }
        public string Slug { get; set; }
        public string NameWithType { get; set; }
        public string Type { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
       //public IList<Order> Orders { get; set; }

    }
}
