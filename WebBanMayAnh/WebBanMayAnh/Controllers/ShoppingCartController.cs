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

        /*
         1. Thêm mới sản phẩm
        2.Cập nhật sản phẩm
        3.xóa sản phẩm trong giỏ hàng
        4.xóa luôn giỏ hàng
         */
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


        [HttpPost]
        [Route("api/cart/update")]
        public IActionResult UpdateCart(int productID, int? amount)
        {
            //lay gio hang ra de xu ly
            var cart = HttpContext.Session.Get<List<CartItemViewModel>>("GioHang");
            try
            {
                if (cart!=null)
                {
                    CartItemViewModel item = cart.SingleOrDefault(x => x.Product.ProductID == productID);
                    if (item!=null && amount.HasValue)// da co --> cap nhat so luong
                    {
                        item.Amount = amount.Value;
                    }
                  
                }
                //luu lai vao session
                HttpContext.Session.Set<List<CartItemViewModel>>("GioHang", cart);
                _notyfService.Success("Cập nhật gỏ hàng thành công");
                return Json(new { sucess = true });
            }
            catch (Exception)
            {

                return Json(new { sucess = false });
            }
        }



    }
}
