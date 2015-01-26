using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BBSProject.BLL;
using BBSProject.WebUI.Areas.Admin.Models;
using BBSProject.DataModel.Model;

namespace BBSProject.WebUI.Areas.Admin.Controllers
{
    public class NoticeNewsController : Controller
    {
        private SystemUserBLL userbll = new SystemUserBLL();
        private NoticeNewsBLL noticebll = new NoticeNewsBLL();
        /// <summary>
        /// 公告首页
        /// </summary>
        /// <returns></returns>
        [UserAuthorizeAttribute]
        public ActionResult Notices()
        {
            SysUsers luser=(SysUsers)Session["User"];
            NoticeViewModel model = new NoticeViewModel();
            model.sysusermodular = userbll.GetAuthorityByUser(luser.ID, 37);
            return View(model);
        }
    }
}
