using ModelAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServerForVSTO.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            int pageIndex = 1;
            int totalCount;
            IQueryable<WordTemplet> templets;
            if (int.TryParse(Request["pageIndex"], out pageIndex))
                pageIndex = pageIndex < 1 ? 1 : pageIndex;
            if (Session["UserInfo"] == null)
                templets = ServiceSessionFactory.ServiceSession.WordTempletService.LoadEntityPage(pageIndex, 6, out totalCount, w => w.Accessibility == Accessibility.Public, w => w.TempletName, true);
            else
            {
                UserInfo userInfo = (UserInfo)Session["UserInfo"];
                templets = ServiceSessionFactory.ServiceSession.WordTempletService.LoadEntityPage(pageIndex, 6, out totalCount, w => w.Accessibility == Accessibility.Public || (w.Accessibility == Accessibility.Protected && w.Organization.ID ==userInfo.Organization.ID)||(w.Accessibility==Accessibility.Private&&w.User.ID==userInfo.ID), w => w.TempletName, true);
            }
            if(Request["search"] != null)
            {
                string search = (string)Request["search"];
                templets = from t in templets
                           where (t.TempletName.Contains(search))
                           select t;
                totalCount = templets.Count();
            }
            ViewData["Templets"] = templets;
            int pageCount = Convert.ToInt32(Math.Ceiling((double)(totalCount / 6)));
            pageIndex = pageIndex > pageCount ? pageCount : pageIndex;
            ViewData["pageCount"] = pageCount;
            ViewData["pageIndex"] = pageIndex;
            return View();
        }
    }
}
