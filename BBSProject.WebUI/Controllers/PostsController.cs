using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BBSProject.WebUI.Controllers
{
    public class PostsController : Controller
    {
        //
        // GET: /Posts/

        public ActionResult Index()
        {
            ViewBag.Title = "贴吧首页";
            ViewBag.Message = "这是一个新的开始，一定要坚持做完";
            return View();
        }

    }
}
