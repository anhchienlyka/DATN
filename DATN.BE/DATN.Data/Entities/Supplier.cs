using DATN.Data.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Data.Entities
{
    public class Supplier : EntityBase
    {
        public int Id { get; set; }

        public string CompanyName { get; set; }

        public string ContactFName { get; set; }

        public string ContactLName { get; set; }

        public string ContactTitle { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public IEnumerable<Product>  Products { get; set; }
    }
}
