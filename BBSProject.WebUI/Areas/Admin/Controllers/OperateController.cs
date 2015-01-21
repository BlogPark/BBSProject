using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BBSProject.DataModel.Model;
using BBSProject.BLL;

namespace BBSProject.WebUI.Areas.Admin.Controllers
{
    public class OperateController : Controller
    {
        //
        // GET: /Admin/Operate/
        private BaseDataBll helper = new BaseDataBll();

        public ActionResult Index()
        {
            ViewBag.Title = "贴吧后台管理系统";
            ViewBag.Message = "此处为后台管理系统首页位置";
            List<SysModulars> modulars = helper.GetModularsByUser(1);
            return Json(modulars, JsonRequestBehavior.AllowGet);
        }

    }
}
