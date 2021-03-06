using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Emun
{
    public enum ApiCode
    {
        [Description("成功")]
        Success = 200,
        [Description("身份认证失败")]
        NotAuth = 401,
        [Description("未找到服务")]
        NotFound = 404,
        [Description("失败")]
        Faild = 500,

        [Description("账号不能为空")]
        CantEmptyLoginName = 401001,
        [Description("密码不能为空")]
        CantEmptyPassword = 401002,
        [Description("账号或密码错误")]
        WrongPassword = 401003,
    }
}
