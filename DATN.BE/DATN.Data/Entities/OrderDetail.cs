﻿using DATN.Data.BaseEntities;

namespace DATN.Data.Entities
{
    public class OrderDetail 
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}