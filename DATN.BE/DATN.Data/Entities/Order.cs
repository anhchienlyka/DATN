using DATN.Data.BaseEntities;
using DATN.InfrastructureLayer.Enums;
using System;
using System.Collections.Generic;

namespace DATN.Data.Entities
{
    public class Order 
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int OrderNumber { get; set; }
        public DateTime ShipDate { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public DeliveryStatus TransacStatus { get; set; }
        public DateTime PaymentDate { get; set; }
        public int PaymentId { get; set; }
        public Payment Payment { get; set; }
        public IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}