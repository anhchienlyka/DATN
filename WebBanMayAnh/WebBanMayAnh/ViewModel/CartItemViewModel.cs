using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBanMayAnh.Models;

namespace WebBanMayAnh.ViewModel
{
    public class CartItemViewModel
    {
        public Product Product { get; set; }
        public int Amount { get; set; }
        public double TotalMoney => Amount * Product.Price;
    }
}
