using DATN.Data.BaseEntities;
using DATN.InfrastructureLayer.Enums;
using System.Collections.Generic;

namespace DATN.Data.Entities
{
    public class Customer 
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public RANK? CustomerRank { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public IEnumerable<Order> Orders { get; set; }
    }
}