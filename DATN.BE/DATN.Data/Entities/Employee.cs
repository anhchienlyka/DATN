using DATN.Data.BaseEntities;
using System.Collections.Generic;

namespace DATN.Data.Entities
{
    public class Employee 
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string DateOfBirth { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public decimal? Salary { get; set; }
        public string Phone { get; set; }
        public int? CoutOrder { get; set; }
        public IEnumerable<Order> Orders { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public IEnumerable<Role> Roles { get; set; }
    }
}