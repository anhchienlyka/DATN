using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Data.Viewmodel.BenefitViewModel
{
    public class BenefitVM
    {
        public string Label { get; set; }
        public List<decimal> Turnover { get; set; }
        public List<decimal> Profit { get; set; }
    }
}
