using DATN.Data.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Data.Entities
{
    public class Category :EntityBase
    {
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public bool Active { get; set; }

        public IEnumerable<Product> Products { get; set; }
    }
}
