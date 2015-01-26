using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using BBSProject.DataModel.Model;

namespace System.Web.Mvc
{
    public class UserAuthorizeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            SysUsers user = (SysUsers)filterContext.HttpContext.Session["User"];
            if (user == null)// || filterContext.HttpContext.Session.Mode != 0)
            {
                string s = filterContext.RequestContext.HttpContext.Request.Url.ToString();
                //filterContext.Result = new RedirectResult("/Admin/SysUser/Login");
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "action", "Login" }, { "controller", "SysUser" }, { "returnurl", s } });
            }
            return;
        }
    }
}
