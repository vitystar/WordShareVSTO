using ServerForVSTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServerForVSTO.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            
        }

        protected bool CheckOrCreateAuth(string id,string token)
        {
            string key = (string)HttpRuntime.Cache.Get(id);
            if(key == null)
            {

            }
        }
    }
}