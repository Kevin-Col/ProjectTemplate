using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.InputDto.Auth
{
    public class LoginInput
    {
        [Required(ErrorMessage = "登录名不能为空")]
        public string LoginName { get; set; }
        [Required(ErrorMessage = "密码不能为空")]
        public string Password { get; set; }
    }
}
