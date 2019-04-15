using ModelAPI;
using ServerForVSTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServerForVSTO.Controllers
{
    public class JsonAPIController : Controller
    {


        // GET: JsonAPI
        public ActionResult GetUser(UserMsg user)
        {
            UserInfo userInfo = ServiceSessionFactory.ServiceSession.UserInfoService.LoadEntity(u => u.UserName == user.UserName).FirstOrDefault();
            if (userInfo != null)
                if (userInfo.UserPwd == userInfo.UserPwd)
                    return Json(userInfo);
                else
                    return Content("密码错误");
            else
                return Content("用户不存在");
        }
    }
}