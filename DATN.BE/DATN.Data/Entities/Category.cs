using DATN.Data.BaseEntities;
using System.Collections.Generic;

namespace DATN.Data.Entities
{
    public class Category : EntityBase
    {
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public bool Active { get; set; }

        public IEnumerable<Product> Products { get; set; }
    }
}