using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBanMayAnh.DataContext;
using WebBanMayAnh.Extension;
using WebBanMayAnh.Models;
using WebBanMayAnh.ViewModel;

namespace WebBanMayAnh.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly DATNContext _context;
        private readonly INotyfService _notyfService;
        public ShoppingCartController(DATNContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }
        [Route("cart.html",Name ="Cart")]
        public IActionResult Index()
        {
            List<int> lsProductID = new List<int>();
            var lsGioHang = GioHang;
            //foreach (var item in lsGioHang)
            //{
            //    lsProductID.Add(item.Product.ProductID);
            //}
            //List<Product> lsProducts = _context.Products.OrderByDescending(x => x.ProductID)
            //    .Where(x => x.Active == true && !lsProductID.Contains(x.ProductID)).Take(6).ToList();
            //ViewBag.lsSanPham = lsProducts;
            return View(GioHang);
        }


        public List<CartItemViewModel> GioHang
        {
            get
            {
                var gioHang = HttpContext.Session.Get<List<CartItemViewModel>>("GioHang");
                if (gioHang == default(List<CartItemViewModel>))
                {
                    gioHang = new List<CartItemViewModel>();
                }
                return gioHang;
            }
        }

        [HttpPost]
        [Route("api/cart/add")]
        public IActionResult AddToCart(int productId, int? amount)
        {
            try
            {
                List<CartItemViewModel> gioHang = GioHang;
                //Them san pham vao gio hang

                CartItemViewModel cart = GioHang.SingleOrDefault(x => x.Product.ProductID == productId);
                if (cart != null)//neu co thi cap nhat so luong
                {
                    if (amount.HasValue)
                    {
                        cart.Amount = amount.Value;
                    }
                    else
                    {
                        cart.Amount++;
                    }
                }
                else
                {
                    Product product = _context.Products.SingleOrDefault(x => x.ProductID == productId);
                    cart = new CartItemViewModel()
                    {
                        Amount = amount.HasValue ? amount.Value : 1,
                        Product = product
                    };
                    gioHang.Add(cart);//them vao gio hang
                }

                //luu lai vao seccsion
                HttpContext.Session.Set<List<CartItemViewModel>>("GioHang", gioHang);
                return Json(new { sucess = true });
            }
            catch (Exception)
            {

                return Json(new { sucess = false });
            }
        }


        [HttpPost]
        [Route("api/cart/remove")]
        public IActionResult Remove(int productId)
        {
            try
            {
                List<CartItemViewModel> gioHang = GioHang;
                //Them san pham vao gio hang

                CartItemViewModel cart = GioHang.SingleOrDefault(x => x.Product.ProductID == productId);
                if (cart != null)//neu co thi cap nhat so luong
                {
                    gioHang.Remove(cart);
                }


                //luu lai vao seccsion
                HttpContext.Session.Set<List<CartItemViewModel>>("GioHang", gioHang);
                return Json(new { sucess = true });
            }
            catch (Exception)
            {

                return Json(new { sucess = false });
            }
        }






    }
}
