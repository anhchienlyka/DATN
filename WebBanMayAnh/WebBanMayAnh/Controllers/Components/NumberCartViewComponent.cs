using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBanMayAnh.Extension;
using WebBanMayAnh.ViewModel;

namespace WebBanMayAnh.Controllers.Components
{
    public class NumberCartViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {

            var cart = HttpContext.Session.Get<List<CartItemViewModel>>("GioHang");
           
            return View(cart);
        }
    }
}
