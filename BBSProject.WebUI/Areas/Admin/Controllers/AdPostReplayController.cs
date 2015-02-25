using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BBSProject.BLL;
using BBSProject.DataModel.Model;
using BBSProject.WebUI.Areas.Admin.Models;

namespace BBSProject.WebUI.Areas.Admin.Controllers
{
    public class AdPostReplayController : Controller
    {
        //
        // GET: /Admin/AdPostReplay/
        private SystemUserBLL usebll = new SystemUserBLL();
        private AdminPostBLL bll = new AdminPostBLL();
        /// <summary>
        /// 帖子管理页面
        /// </summary>
        /// <returns></returns>
        [UserAuthorizeAttribute]
        public ActionResult posts()
        {
            SysUsers user = Session["User"] as SysUsers;
            PostsViewModel model = new PostsViewModel();
            model.usermodular = usebll.GetAuthorityByUser(user.ID, 38);
            return View(model);
        }
        /// <summary>
        /// 得到帖子列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult getpostlist(PostsVO model)
        {
            string s = model.PostTitle;

            if (model.StrPublishTime == DateTime.MinValue)
            {
                model.StrPublishTime = DateTime.Now.AddDays(-7);
            }
            if (model.EndPublishTime == DateTime.MinValue)
            {
                model.EndPublishTime = DateTime.Now;
            }
            if (model.PageIndex == 0)
            {
                model.PageIndex = Request.Params["page"].ToString().ToInt(1);
            }
            if (model.PageSize == 0)
            {
                model.PageSize = Request.Params["pagesize"].ToString().ToInt(200);
            }
            try
            {
                string sortname = Request.Params["sortname"].ToString();
                if (!string.IsNullOrWhiteSpace(sortname))
                { model.SortOrderName = sortname; }
                string sortoption = Request.Params["sortorder"].ToString();
                if (!string.IsNullOrWhiteSpace(sortoption))
                { model.SortOrderOption = sortoption; }
            }
            catch { }
            List<PostsVO> list = bll.GetPostlist(model);
            var datamodel = new
            {
                Rows = list,
                Total = list.Count
            };
            return Json(datamodel, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 删除帖子
        /// </summary>
        /// <param name="postid"></param>
        /// <param name="memberid"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult delepost(int postid, int memberid)
        {
            int rowcount = bll.DeletePosts(postid);
            if (rowcount > 0)
            {
                MemberNewsVO model = new MemberNewsVO();
                model.NewsTitle = @"帖子删除通知";
                model.NewsContent = @"由于您发表的帖子中包含敏感内容，您的帖子已经被管理员删除，请您再次发表帖子时注意您的措辞";
                model.NewsPublisher = 1;
                model.NewsReceiver = memberid;
                int newid = bll.InsertMemberNews(model);
                if (newid > 0)
                {
                    return Json("1");
                }
                else { return Json("0"); }
            }
            else
            { return Json("0"); }
        }


    }
}
