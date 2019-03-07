using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebShop.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Không được bỏ trống tên đăng nhập")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Không được bỏ trống mật khẩu")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}