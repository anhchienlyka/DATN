using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebBanMayAnh.Models
{
    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }
        public string PaymentName { get; set; }
        public IEnumerable<Order> Orders { get; set; }
    }
}
