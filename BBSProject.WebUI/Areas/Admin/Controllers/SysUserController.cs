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

        public ActionResult Login(string returnurl = "")
        {
            if (!string.IsNullOrWhiteSpace(returnurl))
            {
                ViewBag.returnurl = returnurl;
            }
            return View();
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            SysUsers user = helper.CheckPassport(model.LUserName, model.LPassword);
            if (user == null)//无此账户
            {
                ModelState.AddModelError("LPassword", "用户名或密码错误");
                return View(model);
            }
            else if (user != null && user.Status == 3) //状态不正确 
            {
                ModelState.AddModelError("LPassword", "该用户已被禁用，请联系管理员");
                return View(model);
            }
            else
            {
                #region 将登陆信息记入Session/cookie
                Session["User"] = user;
                HttpCookie usernamecookie = new HttpCookie("username");
                usernamecookie.Value = user.SysUserName;
                usernamecookie.Expires = DateTime.Now.AddMinutes(20);//20分钟过期
                Response.Cookies.Add(usernamecookie);
                HttpCookie useridcookie = new HttpCookie("userid");
                useridcookie.Expires = DateTime.Now.AddMinutes(20);
                useridcookie.Value = user.ID.ToString();
                Response.Cookies.Add(useridcookie);
                #endregion
                //if (!string.IsNullOrWhiteSpace(model.ReturnUrl))
                //{
                //    return RedirectToRoute(model.ReturnUrl);
                //}
                //else
                //{
                return RedirectToAction("Index", "Operate");
                //}
            }
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
        public JsonResult GetUserGroup()
        {
            int pagesize = int.Parse(Request.Params["pagesize"].ToString());
            int pageindex = int.Parse(Request.Params["page"].ToString());
            List<SysUserGroupVO> result = helper.GetSysUserGroup(pageindex, pagesize);
            var griddata = new
            {
                Rows = result,
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
        /// <summary>
        /// 插入用户组
        /// </summary>
        /// <param name="groupname"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Insertgroup(string groupname)
        {
            SysUserGroups model = new SysUserGroups();
            model.SysUserGroupName = groupname;
            int rowcount = helper.InsertSysUserGroup(model);
            if (rowcount > 0)
            {
                return Json("1");
            }
            else
            {
                return Json("0");
            }
        }

        [HttpPost]
        public ActionResult CheckPassPost(LoginViewModel model)
        {
            SysUsers user = helper.CheckPassport(model.LUserName, model.LPassword);
            if (user == null)//无此账户
            {
                ModelState.AddModelError("LUserName", "用户名或密码错误");
                return RedirectToAction("Login");
            }
            else if (user != null && user.Status == 3) //状态不正确 
            {
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(model.ReturnUrl))
                {
                    return RedirectToRoute(model.ReturnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Operate");
                }
            }
            return View();
        }

    }
}
