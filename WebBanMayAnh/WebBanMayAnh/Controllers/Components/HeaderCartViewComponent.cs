using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBanMayAnh.Extension;
using WebBanMayAnh.ViewModel;

namespace WebBanMayAnh.Controllers.Components
{
    public class HeaderCartViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
          //  List<ShoppingCartViewModel> cart = new List<ShoppingCartViewModel>();
            var cart = HttpContext.Session.Get<List<CartItemViewModel>>("GioHang");
           
            return View(cart);
        }
    }
}
