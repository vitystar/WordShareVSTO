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
                    return Content("success");
                }
                else
                    return Content("用户创建失败，请稍后重试");
            }
            else
            {
                try
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
                catch
                {
                    return Content("组织格式错误");
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

        public ActionResult AccessChange(string access)
        {
            if (access == "organization")
                screenResult.Accessable = Accessibility.Protected;
            else if (access == "private")
                screenResult.Accessable = Accessibility.Private;
            else
                screenResult.Accessable = Accessibility.Public;
            return Content(access);
        }

        public ActionResult Search(string search)
        {
            screenResult.Search = search;
            return Content(search);
        }

        public ActionResult ModSearch(string search)
        {
            modifyScreenResult.Search = search;
            return Content(search);
        }

        public ActionResult TempletTypeChange(string templetType)
        {
            if (templetType == "video")
                screenResult.TempletType = TempletType.VideoTemplet;
            else if (templetType == "ppt")
                screenResult.TempletType = TempletType.PPTTemplet;
            else if (templetType == "excel")
                screenResult.TempletType = TempletType.ExcelTemplet;
            else if (templetType == "image")
                screenResult.TempletType = TempletType.ImageTemplet;
            else if (templetType == "audio")
                screenResult.TempletType = TempletType.AudioTemplet;
            else
                screenResult.TempletType = TempletType.WordTemplet;
            return Content(templetType);
        }

        public ActionResult ModTempletType(string templetType)
        {
            if (templetType == "video")
                modifyScreenResult.TempletType = TempletType.VideoTemplet;
            else if (templetType == "ppt")
                modifyScreenResult.TempletType = TempletType.PPTTemplet;
            else if (templetType == "excel")
                modifyScreenResult.TempletType = TempletType.ExcelTemplet;
            else if (templetType == "image")
                modifyScreenResult.TempletType = TempletType.ImageTemplet;
            else if (templetType == "audio")
                modifyScreenResult.TempletType = TempletType.AudioTemplet;
            else
                modifyScreenResult.TempletType = TempletType.WordTemplet;
            return Content(templetType);
        }

        public ActionResult AddOrganization()
        {
            try
            {
                Guid organizationID = new Guid(Request["organizationID"]);
                string organizationPWD = Request["organizationPWD"];
                var organization = ServiceSessionFactory.ServiceSession.OrganizationInfoService.LoadEntity(o => o.ID == organizationID).FirstOrDefault();
                if (organization == null)
                    return Content("该组织不存在");
                else if (organization.Password == organizationPWD)
                {
                    userInfo.Organization = organization;
                    userInfo.UserAuth = organization.DefaultUserAuth;
                    ServiceSessionFactory.ServiceSession.UserInfoService.EditEntity(userInfo);
                    return Content("success");
                }

                return Content("组织密码错误");
            }
            catch
            {
                return Content("组织格式不正确");
            }
        }

        public ActionResult ExitOrganization()
        {
            if (userInfo == null)
                return Content("您尚未登陆");
            else if (userInfo.Organization == null)
                return Content("您尚未加入任何组织");
            else
            {
                OrganizationInfo organization = userInfo.Organization;
                userInfo.Organization = null;
                userInfo.UserAuth = UserAuth.User;
                ServiceSessionFactory.ServiceSession.UserInfoService.EditEntity(userInfo);
                if (ServiceSessionFactory.ServiceSession.OrganizationInfoService.OrganizationDelete(organization))
                {
                    return Content("退出成功，且由于您的组织中已无成员，该组织已解散");
                }
                else
                    return Content("Success");
            }
        }

        public ActionResult ModOrganizationInfo()
        {
            string name = Request["Name"];
            string pwd = Request["PWD"];
            string auth = Request["Auth"];
            UserAuth userAuth;
            if (auth == "管理员")
                userAuth = UserAuth.Admin;
            else
                userAuth = auth == "可上传" ? UserAuth.Uploader : UserAuth.User;
            OrganizationInfo organization = userInfo.Organization;
            organization.OrganizationName = name;
            organization.Password = pwd;
            organization.DefaultUserAuth = userAuth;
            ServiceSessionFactory.ServiceSession.OrganizationInfoService.EditEntity(organization);
            return Content("success");
        }

        /// <summary>
        /// 管理员将用户从组织中删除
        /// </summary>
        /// <param name="userID">要删除的用户ID</param>
        /// <returns>删除结果</returns>
        public ActionResult RemoveFromOrganization(string userID)
        {
            if (userInfo.UserAuth != UserAuth.Admin)
                return Content("权限不足");
            if (int.TryParse(userID, out int id))
            {
                UserInfo user = ServiceSessionFactory.ServiceSession.UserInfoService.LoadEntity(u => u.ID == id).FirstOrDefault();
                if (user == null)
                    return Content("参数错误");
                if (user.Organization != null)
                    user.Organization = null;
                user.UserAuth = UserAuth.User;
                ServiceSessionFactory.ServiceSession.UserInfoService.EditEntity(user);
                userInfo = ServiceSessionFactory.ServiceSession.UserInfoService.LoadEntity(u => u.ID == userInfo.ID).FirstOrDefault();
                return Content("success");
            }
            else
                return Content("参数错误");
        }

        public ActionResult ChangeUserFromOrganization()
        {
            string auth = Request["Auth"];
            string id = Request["id"];
            if (userInfo.UserAuth != UserAuth.Admin)
                return Content("权限不足");
            if (auth == null || id == null)
                return Content("参数错误");
            if (int.TryParse(id, out int uid))
            {
                UserAuth userAuth;
                if (auth == "管理员")
                    userAuth = UserAuth.Admin;
                else
                    userAuth = auth == "可上传" ? UserAuth.Uploader : UserAuth.User;
                UserInfo user = ServiceSessionFactory.ServiceSession.UserInfoService.LoadEntity(u => u.ID == uid).FirstOrDefault();
                user.UserAuth = userAuth;
                ServiceSessionFactory.ServiceSession.UserInfoService.EditEntity(user);
                return Content("success");
            }
            return Content("参数错误");
        }

        public ActionResult DeleteTemplet(string templetID)
        {
            BaseTemplet b;
            int id;
            if (!int.TryParse(templetID, out id))
                return Content("参数格式错误");
            switch (modifyScreenResult.TempletType)
            {
                case TempletType.WordTemplet:
                    b = ServiceSessionFactory.ServiceSession.WordTempletService.LoadEntity(w => w.ID == id).FirstOrDefault();
                    break;
                case TempletType.ExcelTemplet:
                    b = ServiceSessionFactory.ServiceSession.ExcelService.LoadEntity(w => w.ID == id).FirstOrDefault();
                    break;
                case TempletType.PPTTemplet:
                    b = ServiceSessionFactory.ServiceSession.PPTService.LoadEntity(w => w.ID == id).FirstOrDefault();
                    break;
                case TempletType.ImageTemplet:
                    b = ServiceSessionFactory.ServiceSession.ImageService.LoadEntity(w => w.ID == id).FirstOrDefault();
                    break;
                case TempletType.VideoTemplet:
                    b = ServiceSessionFactory.ServiceSession.VideoService.LoadEntity(w => w.ID == id).FirstOrDefault();
                    break;
                case TempletType.AudioTemplet:
                    b = ServiceSessionFactory.ServiceSession.AudioService.LoadEntity(w => w.ID == id).FirstOrDefault();
                    break;
                default:
                    b = ServiceSessionFactory.ServiceSession.WordTempletService.LoadEntity(w => w.ID == id).FirstOrDefault();
                    break;
            }

            if(b.User.ID == userInfo.ID)
            {
                switch (modifyScreenResult.TempletType)
                {
                    case TempletType.WordTemplet:
                        ServiceSessionFactory.ServiceSession.WordTempletService.DeleteEntity((WordTemplet)b);
                        break;
                    case TempletType.ExcelTemplet:
                        ServiceSessionFactory.ServiceSession.ExcelService.DeleteEntity((ExcelTemplet)b);
                        break;
                    case TempletType.PPTTemplet:
                        ServiceSessionFactory.ServiceSession.PPTService.DeleteEntity((PPTTemplet)b);
                        break;
                    case TempletType.ImageTemplet:
                        ServiceSessionFactory.ServiceSession.ImageService.DeleteEntity((ImageTemplet)b);
                        break;
                    case TempletType.VideoTemplet:
                        ServiceSessionFactory.ServiceSession.VideoService.DeleteEntity((VideoTemplet)b);
                        break;
                    case TempletType.AudioTemplet:
                        ServiceSessionFactory.ServiceSession.AudioService.DeleteEntity((AudioTemplet)b);
                        break;
                    default:
                        break;
                }
                System.IO.File.Delete(Request.MapPath(b.FilePath));
                System.IO.File.Delete(Request.MapPath(b.ImagePath));
            }
            else
            {
                return Content("权限不足");
            }
            return Content("success");
        }

        public ActionResult UserChg(string username, string userPWD, string pwdValidate)
        {
            bool isModed = false;
            if (!string.IsNullOrWhiteSpace(userPWD))
                if (userPWD != pwdValidate)
                    return Content("密码不一致");
                else
                {
                    userInfo.UserPwd = userPWD;
                    isModed = true;
                }

            if (!string.IsNullOrWhiteSpace(username))
                if (username != userInfo.UserName)
                {
                    if (ServiceSessionFactory.ServiceSession.UserInfoService.LoadEntity(u => u.UserName == username).Count() > 0)
                        return Content("用户名不可用");
                    userInfo.UserName = username;
                    isModed = true;
                }
            if (isModed)
            {
                userInfo.Organization = ServiceSessionFactory.ServiceSession.UserInfoService.LoadEntity(u => u.ID == userInfo.ID).FirstOrDefault().Organization;
                ServiceSessionFactory.ServiceSession.UserInfoService.EditEntity(userInfo);
            }
            return Content("success");
        }
    }
}