using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BBSProject.DataModel.Model;

namespace BBSProject.WebUI.Areas.Admin.Models
{
    public class SysConfigurationViewModel
    {
        /// <summary>
        /// 权限列表
        /// </summary>
        public List<SysUserModular> modularlist { get; set; }
    }
}