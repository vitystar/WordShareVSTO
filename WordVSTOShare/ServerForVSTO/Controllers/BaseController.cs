using ModelAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServerForVSTO.Controllers
{
    public class BaseController : Controller
    {
        protected UserInfo userInfo;
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            if (Session["UserInfo"] != null)
            {
                userInfo = (UserInfo)Session["UserInfo"];
                ViewData["UserInfo"] = userInfo;
            }
        }
    }
}