using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebBanMayAnh.Models
{
    public class SaleCode
    {
        [Key]
        public int SaleCodeID { get; set; }
        public int SaleCodeName { get; set; }
    }
}
