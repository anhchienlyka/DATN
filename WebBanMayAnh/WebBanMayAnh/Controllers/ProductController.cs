using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBanMayAnh.DataContext;
using WebBanMayAnh.Models;

namespace WebBanMayAnh.Controllers
{
    public class ProductController : Controller
    {
        private readonly DATNContext _context;

        public ProductController(DATNContext context)
        {
            _context = context;
        }
        public IActionResult Index(int? page)
        {
            try
            {
                var pageNumber = page == null || page <= 0 ? 1 : page.Value;
                var pageSize = 8;
                var listProduct = _context.Products.AsNoTracking().OrderByDescending(x => x.ProductID);
                PagedList<Product> models = new PagedList<Product>(listProduct, pageNumber, pageSize);
                ViewBag.CurrentPage = pageNumber;
                ViewBag.toltalProduct = _context.Products.ToList().Count;
                ViewBag.toltalProductPage = models.ToList().Count;
                return View(models);
            }
            catch (Exception)
            {

                return RedirectToAction("Index", "Home");
            }
        }
        ////[Route("/{Alias}-{catID}.html", Name = "ListProduct")]
        //public IActionResult ListProduct(int catID, int page = 1)
        //{

        //    try
        //    {
        //        var pageSize = 8;
        //        var category = _context.Categories.Find(catID);
        //        var listProduct = _context.Products.AsNoTracking().Where(x => x.CatID == catID).OrderByDescending(x => x.ProductID);
        //        PagedList<Product> models = new PagedList<Product>(listProduct, page, pageSize);
        //        ViewBag.CurrentPage = page;
        //        ViewBag.CurrentCat = category;
        //        return View(models);
        //    }
        //    catch (Exception)
        //    {

        //        return RedirectToAction("Index", "Home");
        //    }
        //}

        //[Route("/{Alias}-{id}.html",Name ="ProductDetails")]
        public IActionResult Details(int id)
        {
            try
            {
                var product = _context.Products.Include(k => k.Category).Include(x => x.Supplier).FirstOrDefault(x => x.ProductID == id);
                var lsProduct = _context.Products.AsNoTracking()
                    .Where(x => x.CatID == product.CatID && x.ProductID != id && x.Active == true)
                    .Take(4)
                    .OrderBy(x => x.DateCreated)
                    .ToList();
                ViewBag.SanPham = lsProduct;

                if (product == null)
                {
                    return RedirectToAction("Index");
                }

                  return View(product);
            }
            catch (Exception)
            {

                return RedirectToAction("Index", "Home");
            }
        }
    }
}
