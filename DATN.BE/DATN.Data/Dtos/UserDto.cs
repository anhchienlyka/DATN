using DATN.Data.Entities;
using DATN.InfrastructureLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Data.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public RANK? CustomerRank { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public bool IsDeleted { get; set; }
        public IEnumerable<Role> Roles { get; set; }
    }
}
