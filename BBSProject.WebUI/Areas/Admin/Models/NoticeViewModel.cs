using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BBSProject.DataModel.Model;

namespace BBSProject.WebUI.Areas.Admin.Models
{
    public class NoticeViewModel
    {
        /// <summary>
        /// 用户权限
        /// </summary>
        public List<SysUserModular> sysusermodular { get; set; }
        /// <summary>
        /// 公告列表
        /// </summary>
        public List<SysNotice> notices { get; set; }
    }
}