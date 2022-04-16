using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebBanMayAnh.ViewModel
{
    public class LoginViewModel
    {
        [Key]
        [Display(Name ="Email")]
        [MaxLength(100)]
        [Required(ErrorMessage ="Vui lòng nhập Email")]
        public string UserName { get; set; }
        [Display(Name = "Mật khẩu")]
        [MinLength(6,ErrorMessage ="Bạn vui lòng nhập mật khẩu lớn 6 kí tự")]
        [Required(ErrorMessage = "Vui lòng nhập Mật khẩu")]
        public string Password { get; set; }
    }
}
