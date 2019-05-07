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

        public ActionResult GetList(RequestType type)
        {
            Enum.TryParse(type.tmpType, out TempletType temp);
            switch (temp)
            {
                case TempletType.WordTemplet:
                    return Json(ServiceSessionFactory.ServiceSession.WordTempletService.LoadEntity(w => w.User.UserName == type.user.UserName && w.Accessibility.ToString() == type.tmpAccess));
                case TempletType.ExcelTemplet:
                    return Json(ServiceSessionFactory.ServiceSession.ExcelService.LoadEntity(w => w.User.UserName == type.user.UserName && w.Accessibility.ToString() == type.tmpAccess));
                case TempletType.PPTTemplet:
                    return Json(ServiceSessionFactory.ServiceSession.PPTService.LoadEntity(w => w.User.UserName == type.user.UserName && w.Accessibility.ToString() == type.tmpAccess));
                case TempletType.ImageTemplet:
                    return Json(ServiceSessionFactory.ServiceSession.ImageService.LoadEntity(w => w.User.UserName == type.user.UserName && w.Accessibility.ToString() == type.tmpAccess));
                case TempletType.VideoTemplet:
                    return Json(ServiceSessionFactory.ServiceSession.VideoService.LoadEntity(w => w.User.UserName == type.user.UserName && w.Accessibility.ToString() == type.tmpAccess));
                case TempletType.AudioTemplet:
                    return Json(ServiceSessionFactory.ServiceSession.AudioService.LoadEntity(w => w.User.UserName == type.user.UserName && w.Accessibility.ToString() == type.tmpAccess));
                default:
                    return Json(ServiceSessionFactory.ServiceSession.WordTempletService.LoadEntity(w => w.User.UserName == type.user.UserName && w.Accessibility.ToString() == type.tmpAccess));
            }
        }
    }
}