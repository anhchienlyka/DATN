using DATN.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Data.Viewmodel.Order
{
    public class OrderUpdateVM
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int OrderNumber { get; set; }
        public DateTime ShipDate { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public short TransacStatus { get; set; }
        public DateTime PaymentDate { get; set; }
        public int PaymentId { get; set; }
        public Payment Payment { get; set; }
        public IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}
