using DATN.Data.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Data.Entities
{
    public class Product : EntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Sale { get; set; }
        public int Inventory { get; set; }
        public byte[] Picture { get; set; }
        public int Insurance { get; set; }
        public string Accessory { get; set; }
        public string ProductSummary { get; set; }
        public int CategoryId { get; set; }
        public int PupplierId { get; set; }
        public Category Category { get; set; }
        public Supplier Supplier { get; set; }

    }
}
