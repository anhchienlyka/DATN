using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebBanMayAnh.Models
{
    public class Attributes
    {
        [Key]
        public int AttributeID { get; set; }
        public string Name { get; set; }
        public IEnumerable<AttributesPrice> AttributesPrices { get; set; }

    }
}
