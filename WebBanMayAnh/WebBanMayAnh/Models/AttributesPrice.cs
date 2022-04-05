using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebBanMayAnh.Models
{
    public class AttributesPrice
    {
        [Key]
        public int AttributesPriceID { get; set; }
        public int AttributeID { get; set; }
        public Attributes Attributes { get; set; }
        public int ProductID { get; set; }
        public int Price { get; set; }
        public bool Active { get; set; }
    }
}
