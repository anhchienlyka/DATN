using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebBanMayAnh.Models
{
    public class TransactStatus
    {
        [Key]
        public int TransactStatusID { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public IEnumerable<Order>  Orders { get; set; }
    }
}
