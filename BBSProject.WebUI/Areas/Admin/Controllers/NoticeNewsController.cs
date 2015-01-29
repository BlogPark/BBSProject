using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BBSProject.BLL;
using BBSProject.WebUI.Areas.Admin.Models;
using BBSProject.DataModel.Model;
using System.Net.Mail;

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
            string ss = DateTime.Now.ToSortDatestr();
            SysUsers luser = (SysUsers)Session["User"];
            NoticeViewModel model = new NoticeViewModel();
            model.sysusermodular = userbll.GetAuthorityByUser(luser.ID, 37);
            return View(model);
        }

        public JsonResult getnoticeslist()
        {
            int pageindex = Request.Params["page"].ToString().ToInt(1);
            int pagesize = Request.Params["pagesize"].ToString().ToInt(200);
            List<SysNoticeVO> result = noticebll.GetNoticelist(pageindex, pagesize);
            var griddata = new
            {
                Rows = result,
                Total = result.Count
            };
            return Json(griddata, JsonRequestBehavior.AllowGet);
        }
        [UserAuthorizeAttribute]
        [HttpPost]
        public JsonResult addNotice(SysNotice model)
        {
            SysUsers luser = (SysUsers)Session["User"];
            model.PublishUserName = luser.SysUserName;
            int rowcount = noticebll.InsertNotices(model);
            if (rowcount > 0)
            { return Json("1"); }
            else
            { return Json("0"); }
        }

        /// <summary>
        /// 撤销单个公告
        /// </summary>
        /// <param name="noticesid"></param>
        /// <returns></returns>
        [UserAuthorizeAttribute]
        [HttpPost]
        public JsonResult deleteNotice(int noticesid)
        {
            int rowcount = noticebll.deleteNotice(noticesid);
            if (rowcount > 0)
            {
                return Json("1");
            }
            else { return Json("0"); }
        }
        public JsonResult sendmail()
        {
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
            client.Port = 25;
            client.Host = "smtp.qq.com";
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("1002685061@qq.com", "chenghang1937!");
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            MailMessage mail = new MailMessage();
            MailAddress from = new MailAddress("1002685061@qq.com", "aa"); //邮件的发件人
            mail.From = from;
            mail.To.Add(new MailAddress("chenghang1937@126.com", "aa"));
            mail.Subject = "sss";
            mail.Body = "dd";
            //设置邮件的格式
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;
            //设置邮件的发送级别
            mail.Priority = MailPriority.Normal;
            client.Send(mail);
            return Json("1");
        }

    }
}
