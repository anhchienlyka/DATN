using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBanMayAnh.DataContext;

namespace WebBanMayAnh.Controllers
{
    public class ProductController : Controller
    {
        private readonly DATNContext _context;

        public ProductController(DATNContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var listProduct = _context.Products.Where(x => x.Active == true).Take(8).OrderByDescending(x=>x.ProductID);
            return View(listProduct);
        }
        public IActionResult Details(int id)
        {
            var product = _context.Products.Include(k => k.Category).FirstOrDefault(x => x.ProductID == id);
            //if (product==null)
            //{
            //    return RedirectToAction("Index");
            //}
            return View(product);
        }
    }
}
