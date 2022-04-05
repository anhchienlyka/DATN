using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebBanMayAnh.Models
{
    public class Account
    {
        [Key]
        public int AccountID { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public bool Active { get; set; }
        public string  FullName { get; set; }
        public int RoleID { get; set; }
        public Role  Role { get; set; }
        public DateTime? LastLogin { get; set; }
        public DateTime? CreateDate { get; set; }
        public IEnumerable<Post>   Posts { get; set; }

    }
}
