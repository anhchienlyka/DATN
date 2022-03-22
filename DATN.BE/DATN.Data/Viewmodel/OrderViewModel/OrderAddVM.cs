using DATN.Data.Viewmodel.OrderDetailViewModel;
using DATN.InfrastructureLayer.Enums;
using System;
using System.Collections.Generic;

namespace DATN.Data.Viewmodel.OrderViewModel
{
    public class OrderAddVM
    {
        public int UserId { get; set; }
        public DateTime ShipDate { get; set; }
        public DateTime PaymentDate { get; set; }
        public int PaymentId { get; set; }
        public IEnumerable<OrderDetailAddVM> OrderDetails { get; set; }
    }
}