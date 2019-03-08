using ModelAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServerForVSTO.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            int pageIndex = 1;
            string search = string.Empty;
            string accessable = string.Empty;
            int totalCount;
            System.Linq.Expressions.Expression<Func<WordTemplet, bool>> whereLambda;
            IQueryable<WordTemplet> templets;
            int.TryParse(Request["pageIndex"], out pageIndex);
            pageIndex = pageIndex < 1 ? 1 : pageIndex;

            if (userInfo == null)
                whereLambda = w => w.Accessibility == Accessibility.Public;
            else
            {
                accessable = Request["Accessable"];
                ViewData["Accessable"] = accessable;
                if (accessable.ToLower() == "private")
                    whereLambda = w => w.Accessibility == Accessibility.Private && w.User.ID == userInfo.ID;
                else if (accessable.ToLower() == "protected")
                    whereLambda = w => w.Accessibility == Accessibility.Protected && w.Organization.ID == userInfo.Organization.ID;
                else
                    whereLambda = w => w.Accessibility == Accessibility.Public || (w.Accessibility == Accessibility.Private && w.User.ID == userInfo.ID) || (w.Accessibility == Accessibility.Protected && w.Organization.ID == userInfo.Organization.ID);
            }
            templets = ServiceSessionFactory.ServiceSession.WordTempletService.LoadEntityPage(pageIndex, 6, out totalCount, whereLambda, w => w.TempletName, true);

            if (!string.IsNullOrWhiteSpace(Request["search"]))
            {
                search = Request["search"];
                ViewData["search"] = search;
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
