using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebBanMayAnh.ViewModel
{
    public class RegisterViewModel
    {
        [Key]
        public int CustomerID { get; set; }
        [Display(Name ="Họ Tên")]
        [Required(ErrorMessage ="Vui lòng nhập Họ Tên")]
        public string FullName { get; set; }

        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "Vui lòng nhập Địa chỉ")]
        public string Address { get; set; }

        
        [Required(ErrorMessage = "Vui lòng nhập Email")]
        [Remote(action: "ValidatEmail", controller: "Account")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Remote(action: "ValidatePhone", controller: "Account")]
        [Required(ErrorMessage = "Vui lòng nhập Điện thoại")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Display(Name = "Mật khẩu")]
        [MinLength(6, ErrorMessage = "Bạn vui lòng nhập mật khẩu lớn 6 kí tự")]
        [Required(ErrorMessage = "Vui lòng nhập Mật khẩu")]
        public string Password { get; set; }

        [Display(Name = "Nhập lại mật khẩu")]
        [MinLength(6, ErrorMessage = "Bạn vui lòng nhập mật khẩu lớn 6 kí tự")]
        [Required(ErrorMessage = "Vui lòng nhập Mật khẩu")]
        [Compare("Password",ErrorMessage ="Vui lòng nhập mật khẩu giống nhau")]
        public string ConfirmPassword { get; set; }
    }
}
