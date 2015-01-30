using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BBSProject.DataModel.Model;
using BBSProject.WebUI.Areas.Admin.Models;
using BBSProject.BLL;

namespace BBSProject.WebUI.Areas.Admin.Controllers
{
    public class BasicSersController : Controller
    {
        private BaseDataBll helper = new BaseDataBll();
        private SystemUserBLL userbll = new SystemUserBLL();
        [UserAuthorizeAttribute]
        public ActionResult sysConfiguration()
        {
            SysUsers user = Session["User"] as SysUsers;
            SysConfigurationViewModel model = new SysConfigurationViewModel();
            model.modularlist = userbll.GetAuthorityByUser(user.ID, 40);
            return View(model);
        }
        /// <summary>
        /// 配置项列表
        /// </summary>
        /// <returns></returns>
        public JsonResult configurationlist()
        {
            int pageindex = Request.Params["page"].ToString().ToInt(1);
            int pagesize = Request.Params["pagesize"].ToString().ToInt(100);
            List<SysConfigurationVO> result = helper.GetAllConfiguration(pageindex, pagesize);
            var griddata = new { Rows = result, Total = result.Count };
            return Json(griddata, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public JsonResult fathconfig()
        {
            List<SysConfiguration> list = helper.getfatherconfig();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 添加配置项
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [UserAuthorizeAttribute]
        [HttpPost]
        public JsonResult addconfig(SysConfiguration model)
        {
            SysUsers user = Session["User"] as SysUsers;
            model.CreateUser = user.SysUserName;
            int rowcount = helper.InsertConfiguration(model);
            if (rowcount > 0)
            {
                return Json("1");
            }
            else
                return Json("0");
        }
        /// <summary>
        /// 修改配置项
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [UserAuthorizeAttribute]
        [HttpPost]
        public JsonResult updateconfig(SysConfiguration model)
        {
            int rowcount = helper.UpdateConfiguration(model);
            if (rowcount > 0)
            {
                return Json("1");
            }
            else
                return Json("0");
        }
        /// <summary>
        /// 禁用启用配置项
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [UserAuthorizeAttribute]
        [HttpPost]
        public JsonResult disableconfig(int id)
        {
            int rowcount = helper.DisableConfiguration(id);
            if (rowcount > 0)
            {
                return Json("1");
            }
            else
                return Json("0");
        }
    }
}
