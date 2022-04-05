using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebBanMayAnh.Models
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailID { get; set; }
        public int OrderID { get; set; }
        public Order  Order { get; set; }
        public int ProductID { get; set; }
        public Product  Product { get; set; }
        public int OrderNumber { get; set; }
        public int Amount { get; set; }
        public int Discount { get; set; }
        public int TotalMoney { get; set; }
        public int CreateDate { get; set; }
        public int Price { get; set; }
      
    }
}
