using ModelAPI;
using ServerForVSTO.Models;
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
        protected ScreenResultModel screenResult = new ScreenResultModel(1,"",Accessibility.Public,TempletType.WordTemplet);

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            if (Session["UserInfo"] != null)
            {
                userInfo = (UserInfo)Session["UserInfo"];
                ViewData["UserInfo"] = userInfo;
            }
            if (Session["screenResult"] != null)
                screenResult = (ScreenResultModel)Session["screenResult"];
            else
            {
                screenResult = new ScreenResultModel(1, "", Accessibility.Public, TempletType.WordTemplet);
                Session["screenResult"] = screenResult;
            }
        }

        protected override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            base.OnResultExecuting(filterContext);
            Session["screenResult"] = screenResult;
            ViewData["search"] = screenResult.Search;
        }
    }
}