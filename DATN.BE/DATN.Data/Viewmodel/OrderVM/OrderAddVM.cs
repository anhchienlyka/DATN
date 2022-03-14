using DATN.Data.Entities;
using DATN.InfrastructureLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DATN.Data.Viewmodel.Order
{
    public class OrderAddVM
    {
        public int CustomerId { get; set; }
        public int OrderNumber { get; set; }
        public DateTime ShipDate { get; set; }
        public int EmployeeId { get; set; }
        public short TransacStatus { get; set; }
        public DateTime PaymentDate { get; set; }
        public int PaymentId { get; set; }
        public IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}
