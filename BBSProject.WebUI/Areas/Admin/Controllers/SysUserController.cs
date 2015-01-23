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
        /// <summary>
        /// 系统用户组维护
        /// </summary>
        /// <returns></returns>
        public ActionResult userGroup()
        {
            UserGroupViewModel model = new UserGroupViewModel();
            model.userModularList = helper.GetAuthorityByUser(1, 34);
            return View(model);
        }
        /// <summary>
        /// 得到用户列表
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// 插入新的系统用户
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult InsertUser(SysUsers users)
        {
            int rowcount = helper.InsertSysUser(users);
            if (rowcount > 0)
            {
                return RedirectToAction("UserList");
            }
            else
            {
                return View();
            }
        }
        /// <summary>
        /// 修改账户信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UpdateUser(SysUsers user)
        {
            int rowount = helper.UpdateSysUser(user);
            if (rowount > 0)
            {
                return RedirectToAction("UserList");
            }
            else
                return RedirectToAction("UserList");
        }
        /// <summary>
        /// 得到用户组信息
        /// </summary>
        /// <returns></returns>
        public JsonResult getusergroup()
        {
            int pagesize = int.Parse(Request.Params["pagesize"].ToString());
            int pageindex = int.Parse(Request.Params["page"].ToString());
            List<SysUserGroupVO> result = helper.GetSysUserGroup(pageindex, pagesize);
            var griddata = new
            {
                Row = result,
                Total = result.Count
            };
            return Json(griddata, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 禁用启用账户组
        /// </summary>
        /// <param name="groupid"></param>
        /// <param name="used"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult disableusergroup(int groupid, int used)
        {
            int rowcount = helper.DisableSysUsergroup(groupid, used);
            if (rowcount > 0)
            { return Json("1"); }
            else
            { return Json("0"); }
        }
    }
}
