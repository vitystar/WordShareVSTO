using ModelAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServerForVSTO.Controllers
{
    public class AJAXInterfaceController : BaseController
    {
        // GET: AJAXInterface
        public ActionResult UserLogin()
        {
            string userName = Request["username"];
            string passWord = Request["userPWD"];

            UserInfo userTemp = ServiceSessionFactory.ServiceSession.UserInfoService.LoadEntity(u => u.UserName == userName).FirstOrDefault();
            if (userTemp == null)
            {
                return Content("用户不存在");
            }
            else if (userTemp.UserPwd == passWord)
            {
                userInfo = userTemp;
                Session["UserInfo"] = userInfo;
                return Content("success");
            }
            else
                return Content("密码错误");
        }

        public ActionResult UserReg()
        {
            string userName = Request["username"];
            string passWord = Request["userPWD"];
            string phoneNumber = Request["phoneNumber"];
            string organizationID = Request["organizationID"];
            string organizationPWD = Request["organizationPWD"];
            UserInfo userTemp = ServiceSessionFactory.ServiceSession.UserInfoService.LoadEntity(u => u.UserName == userName || u.PhoneNumber == phoneNumber).FirstOrDefault();
            if (userTemp != null)
                return Content("用户名或手机号码已被使用");
            else if (string.IsNullOrWhiteSpace(organizationID))
            {
                UserInfo newUser = new UserInfo() { PhoneNumber = phoneNumber, UserAuth = UserAuth.User, UserName = userName, UserPwd = passWord };
                if (ServiceSessionFactory.ServiceSession.UserInfoService.AddEntity(newUser))
                {
                    userInfo = newUser;
                    Session["UserInfo"] = userInfo;
                    return Content("success");
                }
                else
                    return Content("用户创建失败，请稍后重试");
            }
            else
            {
                Guid organization = new Guid(organizationID);
                OrganizationInfo organizationTemp = ServiceSessionFactory.ServiceSession.OrganizationInfoService.LoadEntity(o => o.ID == organization).FirstOrDefault();
                if (organizationTemp == null)
                    return Content("组织不存在");
                if (organizationTemp.Password == organizationPWD)
                {
                    UserInfo newUser = new UserInfo() { PhoneNumber = phoneNumber, UserAuth = organizationTemp.DefaultUserAuth, UserName = userName, UserPwd = passWord, Organization = organizationTemp, };
                    if (ServiceSessionFactory.ServiceSession.UserInfoService.AddEntity(newUser))
                    {
                        userInfo = newUser;
                        ViewData["UserInfo"] = userInfo;
                        return Content("success");
                    }
                    else
                        return Content("用户创建失败，请稍后重试");
                }
                else
                {
                    return Content("组织密码错误");
                }
            }
        }

        public ActionResult CheckUser(string username) => Content((ServiceSessionFactory.ServiceSession.UserInfoService.LoadEntity(u => u.UserName == username).Count() > 0).ToString());

        public ActionResult Logout()
        {
            userInfo = null;
            ViewData["UserInfo"] = null;
            Session["UserInfo"] = null;
            return Content("True");
        }
    }
}