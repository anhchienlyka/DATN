using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebBanMayAnh.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        public string FullName { get; set; }
        public DateTime Birthday { get; set; }
        public string Avatar { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int LocationID { get; set; }
        public Location Location { get; set; }
        public int District { get; set; }
        public int Ward { get; set; }
        public DateTime CreateDate { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public DateTime LastLogin { get; set; }
        public bool Active { get; set; }
        public IEnumerable<Order> Orders  { get; set; }


    }
}
