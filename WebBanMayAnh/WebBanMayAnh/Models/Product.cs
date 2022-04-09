using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebBanMayAnh.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ShortDesc { get; set; }
        public string Description { get; set; }
        public int CatID { get; set; }
        public Category  Category { get; set; }
        public int Price { get; set; }
        public int? Discount { get; set; }
        public int Inventory { get; set; }
        public int Insurance { get; set; }
        public string Accessory { get; set; }
        public string Sensor { get; set; }
        public string Thumb { get; set; }
        public float Screen { get; set; }
        public string ISO { get; set; }
        public string ShutterSpeed { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        //public bool HomeFlag { get; set; }
        public bool Active { get; set; }
        public string Tags { get; set; }
        //public string Title { get; set; }
        public string Alias { get; set; }
        public string MetaDesc { get; set; }
        public string MetaKey { get; set; }
        public int? ViewProduct { get; set; }
        public int? QuantitySold { get; set; }
        public int SupplierID { get; set; }
        public Supplier  Supplier { get; set; }
        public IEnumerable<OrderDetail>  OrderDetails { get; set; }

    }
}
