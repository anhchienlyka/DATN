using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebBanMayAnh.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }
        public int ShipperID { get; set; }
        public Shipper Shipper { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShipDate { get; set; }
        public int TransactStatusID { get; set; }
        public TransactStatus TransactStatus { get; set; }
        public bool Deleted { get; set; }
        public bool Paid { get; set; }
        public DateTime PaymentDate { get; set; }
        public int TotalMoney { get; set; }
        public int PaymentID { get; set; }
        public Payment Payment { get; set; }
        public string Note { get; set; }
        public string Address { get; set; }
        public int? LocationID { get; set; }
        //public Location  Location { get; set; }
        public int District { get; set; }
        public int Ward { get; set; }
        public IEnumerable<OrderDetail> OrderDetails { get; set; }

    }
}
