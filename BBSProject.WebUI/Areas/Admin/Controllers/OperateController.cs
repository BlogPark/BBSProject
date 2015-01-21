using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BBSProject.WebUI.Areas.Admin.Controllers
{
    public class OperateController : Controller
    {
        //
        // GET: /Admin/Operate/

        public ActionResult Index()
        {
            ViewBag.Title = "贴吧后台管理系统";
            ViewBag.Message = "此处为后台管理系统首页位置";
            return View();
        }

    }
}
