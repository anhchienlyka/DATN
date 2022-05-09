using DATN.Data.BaseEntities;
using DATN.InfrastructureLayer.Enums;
using System;
using System.Collections.Generic;

namespace DATN.Data.Entities
{
    public class Order 
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User  User { get; set; }
        public int OrderNumber { get; set; }
        public DateTime CreateDate { get; set; }
        public DeliveryStatus TransacStatus { get; set; }
        public DateTime PaymentDate { get; set; }
        public int PaymentId { get; set; }
        public Payment Payment { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public decimal? ToltalCost { get; set; }
        public IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}