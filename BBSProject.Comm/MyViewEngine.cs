using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BBSProject.Comm
{
    public sealed class MyViewEngine : RazorViewEngine
    {
        public MyViewEngine()
        {
            ViewLocationFormats = new[] { 
            "~/Views/{1}/{0}.cshtml",
                "~/Views/Shared/{0}.cshtml",
                "~/Views/Admin/{1}/{0}.cshtml"//我们的规则
            };
        }
        public override ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, bool useCache)
        {
            return base.FindView(controllerContext, viewName, masterName, useCache);
        }
    }
}
