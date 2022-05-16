using DATN.Data.Viewmodel.OrderDetailViewModel;
using DATN.InfrastructureLayer.Enums;
using System;
using System.Collections.Generic;

namespace DATN.Data.Viewmodel.OrderViewModel
{
    public class OrderAddVM
    {
        public int UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime PaymentDate { get; set; }
        public int PaymentId { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string OrderCode { get; set; }
        public string Email { get; set; }
        public decimal TotalCost { get; set; }
        public IEnumerable<OrderDetailAddVM> OrderDetails { get; set; }
    }
}