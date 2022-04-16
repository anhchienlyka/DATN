using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebBanMayAnh.DataContext;
using WebBanMayAnh.Models;

namespace WebBanMayAnh.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DATNContext _context;
        public HomeController(ILogger<HomeController> logger, DATNContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var listProduct = _context.Products.Where(x => x.Active == true).Take(8).OrderByDescending(x => x.ProductID).ToList();
            var listProductss = _context.Products.Where(x => x.Active == true).Take(3).OrderByDescending(x => x.Discount).ToList();
            ViewBag.lisProductSale = listProductss;
            var listProductsNew = _context.Products.Where(x => x.Active == true).OrderByDescending(x => x.DateCreated).Take(4).ToList();
            ViewBag.listProductsNew = listProductsNew;
            var newPost = _context.Posts.Take(3).OrderByDescending(x => x.CreatedDate).ToList();
            ViewBag.newPost = newPost;
            return View(listProduct);
        }

        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
