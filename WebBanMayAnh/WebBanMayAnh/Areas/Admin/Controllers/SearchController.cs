using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBanMayAnh.DataContext;
using WebBanMayAnh.Models;

namespace WebBanMayAnh.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SearchController : Controller
    {
        private readonly DATNContext _context;
        public SearchController(DATNContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult FindProduct(string keyword)
        {
            List<Product> listProduct = new List<Product>();
            if (string.IsNullOrEmpty(keyword) || keyword.Length < 1)
            {
                return PartialView("ListProductsSearchPartial", null);
            }
            listProduct = _context.Products.AsNoTracking().Include(a => a.Category).Where(x => x.ProductName.Contains(keyword))
                 .OrderByDescending(x => x.ProductName).Take(10).ToList();
            if (listProduct == null)
            {
                return PartialView("ListProductsSearchPartial", null);
            }
            return PartialView("ListProductsSearchPartial", listProduct);
        }
    }
}
