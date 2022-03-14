using DATN.Data.Entities;
using DATN.Data.Viewmodel.OrderDetailViewModel;
using DATN.InfrastructureLayer.Enums;
using System;
using System.Collections.Generic;

namespace DATN.Data.Viewmodel.OrderViewModel
{
    public class OrderUpdateVM
    {
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
        public IEnumerable<OrderDetailVM> OrderDetails { get; set; }
    }
}