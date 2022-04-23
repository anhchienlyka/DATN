using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebBanMayAnh.Controllers
{
    public class AjaxContentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult HeaderCart()
        {
            return ViewComponent("HeaderCart");
        }

        public IActionResult HeaderFavourites()
        {
            return ViewComponent("NumberCart");
        }
    }
}
