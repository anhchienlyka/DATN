using DATN.InfrastructureLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Data.Viewmodel.AccountViewModel
{
    public class ActivatingUserModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
    }
}
