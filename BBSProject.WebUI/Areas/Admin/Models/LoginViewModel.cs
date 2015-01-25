using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BBSProject.WebUI.Areas.Admin.Models
{
    public class LoginViewModel
    {
        /// <summary>
        /// 返回地址
        /// </summary>
        public string ReturnUrl { get; set; }
        /// <summary>
        /// 登陆名
        /// </summary>
        public string LUserName { get; set; }
        /// <summary>
        /// 登陆密码
        /// </summary>
        public string LPassword { get; set; }
    }
}