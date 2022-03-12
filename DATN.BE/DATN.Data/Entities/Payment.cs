using DATN.Data.BaseEntities;
using System.Collections.Generic;

namespace DATN.Data.Entities
{
    public class Payment : EntityBase
    {
        public int Id { get; set; }
        public short PaymentType { get; set; }
        public bool Allowed { get; set; }
        public IEnumerable<Order> Orders { get; set; }
    }
}