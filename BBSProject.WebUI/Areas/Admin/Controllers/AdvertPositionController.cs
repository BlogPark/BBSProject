using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BBSProject.WebUI.Areas.Admin.Controllers
{
    public class AdvertPositionController : Controller
    {
        //
        // GET: /Admin/AdvertPosition/
         [UserAuthorizeAttribute]
        public ActionResult Positions()
        {
            return View();
        }

    }
}
