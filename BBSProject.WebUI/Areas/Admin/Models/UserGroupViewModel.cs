using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BBSProject.DataModel.Model;

namespace BBSProject.WebUI.Areas.Admin.Models
{
    public class UserGroupViewModel
    {
        /// <summary>
        /// 用户权限列表
        /// </summary>
        public List<SysUserModular> userModularList { get; set; }
    }
}