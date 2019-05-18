using ModelAPI;
using ServerForVSTO.App_Common;
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
        protected ScreenResultModel screenResult = new ScreenResultModel(1, "", Accessibility.Public, TempletType.WordTemplet);
        protected ScreenResultModel modifyScreenResult = new ScreenResultModel(1, "", Accessibility.Private, TempletType.WordTemplet);
        protected Common util = new Common();

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
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
            if (Session["modifyScreenResult"] != null)
                modifyScreenResult = (ScreenResultModel)Session["modifyScreenResult"];
            else
            {
                modifyScreenResult = new ScreenResultModel(1, "", Accessibility.Private, TempletType.WordTemplet);
                Session["modifyScreenResult"] = modifyScreenResult;
            }

            if (Session["UserInfo"] == null && Request.Path != "/Home/Index" && Request.Path != "/Home/AddonDownload" && Request.Path.Contains("/Home/"))
                filterContext.Result = Redirect("/Home/Index");

        }

        protected override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            base.OnResultExecuting(filterContext);
            Session["screenResult"] = screenResult;
            Session["modifyScreenResult"] = modifyScreenResult;
            Session["UserInfo"] = userInfo;
            ViewData["search"] = screenResult.Search;
        }
    }
}