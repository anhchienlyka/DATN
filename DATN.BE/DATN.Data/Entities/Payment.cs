using DATN.Data.BaseEntities;
using DATN.InfrastructureLayer.Enums;
using System.Collections.Generic;

namespace DATN.Data.Entities
{
    public class Payment 
    {
        public int Id { get; set; }
        public PaymentType PaymentType { get; set; }
        public bool Allowed { get; set; }
        public IEnumerable<Order> Orders { get; set; }
    }
}