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
    public class AdvertPositionController : Controller
    {
        private SystemUserBLL usebll = new SystemUserBLL();
        private SysAdvertBll bll = new SysAdvertBll();
        //
        // GET: /Admin/AdvertPosition/
        [UserAuthorizeAttribute]
        public ActionResult Positions()
        {
            SysUsers user = Session["User"] as SysUsers;
            AdvertPositionsViewModel model = new AdvertPositionsViewModel();
            model.usermodular = usebll.GetAuthorityByUser(user.ID, 38);
            return View(model);
        }
        public JsonResult Positionlist()
        {
            List<AdvertPositionVO> result = bll.GetAlladvertinfo();
            var griddata = new
            {
                Rows = result,
                Total = result.Count
            };
            return Json(griddata, JsonRequestBehavior.AllowGet);
        }

        [UserAuthorizeAttribute]
        [HttpPost]
        public JsonResult addposition(AdvertPosition model)
        {
            int rowcount = bll.InsertAdvertinfo(model);
            if (rowcount > 0)
            {
                return Json("1");
            }
            else
            { return Json("0"); }
        }
        [UserAuthorizeAttribute]
        [HttpPost]
        public JsonResult updposition(AdvertPosition model)
        {
            int rowcount = bll.UpdateAdvertinfo(model);
            if (rowcount > 0)
            {
                return Json("1");
            }
            else
            { return Json("0"); }
        }
        [UserAuthorizeAttribute]
        [HttpPost]
        public JsonResult disableposition(int id)
        {
            int rowcount = bll.DisableAdvertinfo(id);
            if (rowcount > 0)
            {
                return Json("1");
            }
            else
            { return Json("0"); }
        }
    }
}
