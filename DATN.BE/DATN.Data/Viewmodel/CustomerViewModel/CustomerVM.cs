using DATN.InfrastructureLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Data.Viewmodel.CustomerViewModel
{
    public class CustomerVM
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public RANK? CustomerRank { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
    }
}
