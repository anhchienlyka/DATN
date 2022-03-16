using DATN.Data.Viewmodel.OrderDetailViewModel;
using DATN.InfrastructureLayer.Enums;
using System;
using System.Collections.Generic;

namespace DATN.Data.Viewmodel.OrderViewModel
{
    public class OrderAddVM
    {
        public int UserId { get; set; }
        public int OrderNumber { get; set; }
        public DateTime ShipDate { get; set; }
        public DeliveryStatus TransacStatus { get; set; }
        public DateTime PaymentDate { get; set; }
        public int PaymentId { get; set; }
        public IEnumerable<OrderDetailAddVM> OrderDetails { get; set; }
    }
}