using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebBanMayAnh.DataContext;
using WebBanMayAnh.Extension;
using WebBanMayAnh.Helpper;
using WebBanMayAnh.Models;
using WebBanMayAnh.ViewModel;

namespace WebBanMayAnh.Controllers
{
    public class AccountController : Controller
    {
        private readonly DATNContext _context;
        private readonly INotyfService _notyfService;

        public AccountController(DATNContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("dang-ky.html", Name = "DangKy")]
        public IActionResult DangKyTaiKhoan()
        {
            return View();
        }



        [HttpPost]
        [AllowAnonymous]
        [Route("dang-ky.html", Name = "DangKy")]
        public async Task<IActionResult> DangKyTaiKhoan(RegisterViewModel taikhoan)
        {
            if (taikhoan.Password.Trim().ToLower() != taikhoan.ConfirmPassword.Trim().ToLower())
            {
                _notyfService.Error("Vui lòng xác nhận đúng mật khẩu");
                return RedirectToAction("DangKyTaiKhoan", "Account");
            }

            try
            {
                if (ModelState.IsValid)
                {
                    string randomKey = Utilities.GetRandomKey();
                    Customer customer = new Customer()
                    {
                        FullName = taikhoan.FullName,
                        Phone = taikhoan.Phone.Trim().ToLower(),
                        Email = taikhoan.Email.Trim().ToLower(),
                        Password = (taikhoan.Password + randomKey.Trim()).ToMD5(),
                        Active = true,
                        Address = taikhoan.Address,
                        CreateDate = DateTime.Now,
                        RankCustomer = Enums.RANK.Normal,
                        Salt = randomKey,
                        LocationID = 1
                    };
                    try
                    {
                        var khachhang = _context.Customers.AsNoTracking().SingleOrDefault(x => x.Email.ToLower() == customer.Email);
                        if (khachhang != null)
                        {
                            _notyfService.Error("Email đã tồn tại");
                            return RedirectToAction("DangKyTaiKhoan", "Account");
                        }

                        await _context.AddAsync(customer);
                        await _context.SaveChangesAsync();
                        _notyfService.Success("Đăng ký tài khoản thành công");
                        //    HttpContext.Session.SetString("CustomerID", taikhoan.CustomerID.ToString());
                        //    var taiKhoanID = HttpContext.Session.GetString("CustomerID");
                        //    //Identity
                        //    var clams = new List<Claim>()
                        //{
                        //    new Claim(ClaimTypes.Name, customer.FullName),
                        //    new Claim("CustomerID",customer.CustomerID.ToString())
                        //};
                        //    ClaimsIdentity claimsIdentity = new ClaimsIdentity(clams, "login");
                        //    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                        //    await HttpContext.SignInAsync(claimsPrincipal);
                        return RedirectToAction("Login", "Account");
                    }
                    catch (Exception)
                    {

                        RedirectToAction("DangKyTaiKhoan", "Account");
                    }

                }
                else
                {
                    return View(taikhoan);
                }

            }
            catch
            {

                return RedirectToAction("DangKyTaiKhoan", "Account");
            }

            return View(taikhoan);
        }
        [AllowAnonymous]
        [Route("dang-nhap.html", Name = "DangNhap")]
        public IActionResult Login(string returnUrl = null)
        {
            var taikhoanID = HttpContext.Session.GetString("CustomerID");
            if (taikhoanID != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [Route("tai-khoan-cua-toi.html", Name = "Dashboard")]
        public IActionResult Dashboard()
        {
            var taikhoanID = HttpContext.Session.GetString("CustomerID");
            if (taikhoanID != null)
            {
                var customer = _context.Customers.AsNoTracking().SingleOrDefault(x => x.CustomerID == Convert.ToInt32(taikhoanID));
                if (customer != null)
                {
                    var lsOrderByCustomerID = _context.Orders.AsNoTracking().Include(x => x.TransactStatus).Where(x => x.CustomerID == customer.CustomerID).ToList();
                    ViewBag.OrDers = lsOrderByCustomerID;
                    return View(customer);
                }
            }
            return RedirectToAction("Login", "Account");
        }


        [HttpPost]
        public IActionResult ChangePassword(ChangePasswordViewModel changePassword)
        {
            if (changePassword.NewPassword != changePassword.ConfrimPassword)
            {
                _notyfService.Error("Mật khẩu xác nhận không đúng, vui lòng kiểm tra lại");
                return RedirectToAction("Dashboard", "Account");
            }
            var taikhoanID = HttpContext.Session.GetString("CustomerID");
            if (taikhoanID != null)
            {
                var customer = _context.Customers.AsNoTracking().SingleOrDefault(x => x.CustomerID == Convert.ToInt32(taikhoanID));


                if (customer != null)
                {

                    string pass = (changePassword.OldPassword + customer.Salt.Trim()).ToMD5();
                    if (customer.Password != pass)
                    {
                        _notyfService.Error("Bạn nhập sai mật khẩu cũ, vui lòng kiểm tra lại");
                        return RedirectToAction("Dashboard", "Account");
                    }
                    customer.Password = pass;
                    _context.Customers.Update(customer);
                    _context.SaveChanges();
                    _notyfService.Success("Thay đổi mật khẩu thành công");

                    return RedirectToAction("Dashboard", "Account");
                }
            }
            _notyfService.Error("Thay đổi mật khẩu không thành công");
            return RedirectToAction("Dashboard", "Account");
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("dang-nhap.html", Name = "DangNhap")]
        public async Task<IActionResult> Login(LoginViewModel customer, string returnUrl = null)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool isEmail = Utilities.IsValidEmail(customer.UserName);
                    if (!isEmail) return View(customer);
                }
                var khachhang = _context.Customers.AsNoTracking().SingleOrDefault(x => x.Email.Trim() == customer.UserName.Trim());
                if (khachhang == null) return RedirectToAction("DangKytaiKhoan", "Account");
                string pass = (customer.Password + khachhang.Salt.Trim()).ToMD5();
                if (khachhang.Password != pass)
                {
                    _notyfService.Error("Thông tin đăng nhập chưa chính xác");
                    return View(customer);
                }
                //kiem tra account cos bij disable khoong
                if (khachhang.Active == false)
                {
                    return RedirectToAction("ThongBao", "Account");
                }
                //Luu SessionKhachHang
                HttpContext.Session.SetString("CustomerID", khachhang.CustomerID.ToString());
                var taiKhoanID = HttpContext.Session.GetString("CustomerID");

                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name,khachhang.FullName),
                    new Claim("CustomerID",khachhang.CustomerID.ToString()),
                    new Claim("Address",khachhang.Address.ToString()),
                    new Claim("CreateDate",khachhang.CreateDate.ToString()),
                    new Claim("Email",khachhang.Email.ToString()),
                    new Claim("Phone",khachhang.Phone.ToString()),
                    new Claim("Rank",khachhang.RankCustomer.ToString()),
                };

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "login");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                await HttpContext.SignInAsync(claimsPrincipal);
                _notyfService.Success("Đăng nhập thành công");
                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {

                return RedirectToAction("DangKyTaiKhoan", "Account");
            }
        }




        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            HttpContext.Session.Remove("CustomerID");
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult ValidatePhone(string phone)
        {
            try
            {
                var khachhang = _context.Customers.SingleOrDefault(x => x.Phone.ToLower() == phone.ToUpper());

                if (khachhang != null)
                {
                    return Json(data: "Số điện thoại : " + phone + " đã được sử dụng");
                }
                return Json(data: true);

            }
            catch (Exception)
            {

                return Json(data: true);
            }
        }



        [HttpGet]
        [AllowAnonymous]
        public IActionResult ValidateEmail(string email)
        {
            try
            {
                var khachhang = _context.Customers.AsNoTracking().SingleOrDefault(x => x.Email.ToLower() == email);

                if (khachhang != null)
                {
                    return Json(data: "Email : " + email + " đã được sử dụng");
                }
                return Json(data: true);

            }
            catch (Exception)
            {

                return Json(data: true);
            }
        }
    }
}
