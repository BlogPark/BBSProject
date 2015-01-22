using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BBSProject.DataModel.Model;
using BBSProject.BLL;
using BBSProject.WebUI.Areas.Admin.Models;

namespace BBSProject.WebUI.Areas.Admin.Controllers
{
    public class SysUserController : Controller
    {
        //
        // GET: /Admin/SysUser/
        private SystemUserBLL helper = new SystemUserBLL();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        /// <summary>
        /// 用户列表页面
        /// </summary>
        /// <returns></returns>
        public ActionResult UserList()
        {
            UserListViewModel models = new UserListViewModel();
            models.userModularList = helper.GetAuthorityByUser(1, 33);
            return View(models);
        }
        public JsonResult GetUsers()
        {
            int PageSize = Convert.ToInt32(Request.Params["pagesize"]);
            int PageIndex = Convert.ToInt32(Request.Params["page"]);
            List<SysUsersVO> result = helper.GetAllSysUsers();
            var griddata = new
            {
                Rows = result,
                Total = result.Count
            };
            return Json(griddata, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 得到所有的用户组列表
        /// </summary>
        /// <returns></returns>
        public JsonResult GetSysusergroups()
        {
            List<SysUserGroups> result = helper.GetAllSysUserGroup();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 禁用账户
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        [HttpPost]
        public string DisableSysUser(int userid)
        {
            int rowcount = helper.DisableSysUser(userid);
            if (rowcount > 0)
            {
                return "1";
            }
            else { return "0"; }
        }
    }
}
