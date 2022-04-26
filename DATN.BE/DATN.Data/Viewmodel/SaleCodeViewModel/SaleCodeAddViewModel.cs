using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Data.Viewmodel.SaleCodeViewModel
{
    public class SaleCodeAddViewModel
    {
        public string CodeName { get; set; }
        public int ValueCode { get; set; }
        public bool IsDelete { get; set; }
        public DateTime StartDateCode { get; set; }
        public DateTime EndDateCode { get; set; }
    }
}
