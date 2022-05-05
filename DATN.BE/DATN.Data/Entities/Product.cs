﻿using DATN.Data.BaseEntities;
using System.Collections.Generic;

namespace DATN.Data.Entities
{
    public class Product 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Sale { get; set; }
        public int Inventory { get; set; }
        public int Insurance { get; set; }
        public string Accessory { get; set; }
        public string Sensor { get; set; }
        public string ImageProcessor { get; set; }
        public float Screen { get; set; }
        public string ISO { get; set; }
        public string ShutterSpeed { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }
        public int ViewProduct { get; set; }
        public Category Category { get; set; }
        public Supplier Supplier { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public IEnumerable<Picture> Pictures { get; set; }
        public IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}