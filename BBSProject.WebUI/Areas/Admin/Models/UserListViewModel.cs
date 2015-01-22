using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BBSProject.DataModel.Model;

namespace BBSProject.WebUI.Areas.Admin.Models
{
    public class UserListViewModel
    {
        /// <summary>
        /// 权限列表
        /// </summary>
        public List<SysUserModular> userModularList { get; set; }
        /// <summary>
        ///用户列表
        /// </summary>
        public List<SysUsersVO> userList { get; set; }

        /// <summary>
        /// 所有的用户分组
        /// </summary>
        public List<SysUserGroups> Usergroups { get; set; }
    }
}