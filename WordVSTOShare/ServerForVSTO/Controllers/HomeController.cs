using ModelAPI;
using ServerForVSTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Expressions;
using ServerForVSTO.App_Common;

namespace ServerForVSTO.Controllers
{
    public class HomeController : BaseController
    {
        /// <summary>
        /// 首页
        /// </summary>
        /// <returns>页面</returns>
        public ActionResult Index()
        {
            #region 初始化变量
            ViewBag.Title = "Home Page";
            int pageIndex = 1;
            int totalCount;
            IQueryable<BaseTemplet> templets;
            int.TryParse(Request["pageIndex"], out pageIndex);
            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            screenResult.PageIndex = pageIndex;
            #endregion

            #region 从数据库查询结果
            UserForTemplet userForTemplet = userInfo != null ? new UserForTemplet() { ID = userInfo.ID, UserName = userInfo.UserName, OrganizationID = userInfo.Organization.ID, Auth = userInfo.UserAuth }:null;
            templets = util.GetScreenResult(userForTemplet, screenResult, out totalCount);
            #endregion

            #region 处理返回值
            ViewData["Templets"] = templets;
            int pageCount = Convert.ToInt32(Math.Ceiling(((double)totalCount / 6)));
            pageIndex = pageIndex > pageCount ? pageCount : pageIndex;
            ViewData["pageCount"] = pageCount;
            ViewData["pageIndex"] = pageIndex;
            #endregion

            return View();
        }
        /// <summary>
        /// 组织管理页面，仅仅包含前端页面
        /// </summary>
        /// <returns>页面</returns>
        public ActionResult OrganizationManager()
        {
            return View();
        }
        /// <summary>
        /// 组织注册页面，从这个页面填写组织信息，仅提供前端页面
        /// </summary>
        /// <returns>页面</returns>
        public ActionResult OrganizationRegister()
        {
            if (userInfo.Organization != null)
                return Redirect("/Home/Index");
            return View();
        }
        /// <summary>
        /// 组织创建逻辑，由AJAX调用
        /// </summary>
        /// <returns>创建完成后的页面跳转</returns>
        public ActionResult OrganizationCreate()
        {
            string organizationName = Request["OrganizationName"];
            string organizationPWD = Request["OrganizationPWD"];
            string auth = Request["Auth"];
            UserAuth userAuth;

            if (organizationName == null || organizationPWD == null || auth == null)
                return Redirect("/Home/Index");
            else
            {
                switch (auth)
                {
                    case "普通用户": userAuth = UserAuth.User; break;
                    case "可上传": userAuth = UserAuth.Uploader; break;
                    case "管理员": userAuth = UserAuth.Admin; break;
                    default: userAuth = UserAuth.User; break;
                }
                userInfo.Organization = ServiceSessionFactory.ServiceSession.OrganizationInfoService.AddOrganization(organizationName, organizationPWD, userAuth);
                userInfo.UserAuth = UserAuth.Admin;
                ServiceSessionFactory.ServiceSession.UserInfoService.EditEntity(userInfo);
            }

            return Redirect("/Home/OrganizationManager");
        }
        /// <summary>
        /// 修改组织信息
        /// </summary>
        /// <returns>修改完成后跳转页面</returns>
        public ActionResult EditOrganization()
        {
            if (userInfo.UserAuth != UserAuth.Admin)
                return Redirect("/Home/Index");
            OrganizationInfo organization = userInfo.Organization;
            organization.OrganizationName = Request["OrganizationName"];
            organization.Password = Request["OrganizationPWD"];
            organization.DefaultUserAuth = (UserAuth)Enum.Parse(typeof(UserAuth), Request["Auth"]);
            ServiceSessionFactory.ServiceSession.OrganizationInfoService.EditEntity(organization);
            return Redirect("/Home/Index");
        }
        /// <summary>
        /// 插件下载页面
        /// </summary>
        /// <returns>页面</returns>
        public ActionResult AddonDownload()
        {
            return View();
        }
        /// <summary>
        /// 模板修改页面
        /// </summary>
        /// <returns>页面</returns>
        public ActionResult TempletManage()
        {

            if (userInfo == null)
                return Redirect("/Home/Index");

            #region 定义变量
            IQueryable<BaseTemplet> templets;
            int totalCount;
            int pageIndex = 1;
            int.TryParse(Request["pageIndex"], out pageIndex);
            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            modifyScreenResult.PageIndex = pageIndex;
            #endregion

            #region 判断显示类型
            switch (modifyScreenResult.TempletType)
            {
                case TempletType.WordTemplet:
                    templets = ServiceSessionFactory.ServiceSession.WordTempletService.LoadEntityPage(pageIndex, 6, out totalCount, w => w.User.ID == userInfo.ID, w => w.TempletName, true);
                    break;
                case TempletType.ExcelTemplet:
                    templets = ServiceSessionFactory.ServiceSession.ExcelService.LoadEntityPage(pageIndex, 6, out totalCount, w => w.User.ID == userInfo.ID, w => w.TempletName, true);
                    break;
                case TempletType.PPTTemplet:
                    templets = ServiceSessionFactory.ServiceSession.PPTService.LoadEntityPage(pageIndex, 6, out totalCount, w => w.User.ID == userInfo.ID, w => w.TempletName, true);
                    break;
                case TempletType.ImageTemplet:
                    templets = ServiceSessionFactory.ServiceSession.ImageService.LoadEntityPage(pageIndex, 6, out totalCount, w => w.User.ID == userInfo.ID, w => w.TempletName, true);
                    break;
                case TempletType.VideoTemplet:
                    templets = ServiceSessionFactory.ServiceSession.VideoService.LoadEntityPage(pageIndex, 6, out totalCount, w => w.User.ID == userInfo.ID, w => w.TempletName, true);
                    break;
                case TempletType.AudioTemplet:
                    templets = ServiceSessionFactory.ServiceSession.AudioService.LoadEntityPage(pageIndex, 6, out totalCount, w => w.User.ID == userInfo.ID, w => w.TempletName, true);
                    break;
                default:
                    templets = ServiceSessionFactory.ServiceSession.WordTempletService.LoadEntityPage(pageIndex, 6, out totalCount, w => w.User.ID == userInfo.ID, w => w.TempletName, true);
                    break;
            }
            #endregion

            #region 判断搜索选项
            if (!string.IsNullOrWhiteSpace(modifyScreenResult.Search))
            {
                templets = from t in templets
                           where (t.TempletName.Contains(modifyScreenResult.Search))
                           select t;
                totalCount = templets.Count();
            }
            #endregion

            #region 处理返回值
            ViewData["Templets"] = templets;
            int pageCount = Convert.ToInt32(Math.Ceiling(((double)totalCount / 6)));
            pageIndex = pageIndex > pageCount ? pageCount : pageIndex;
            ViewData["pageCount"] = pageCount;
            ViewData["pageIndex"] = pageIndex;
            #endregion

            return View();
        }


    }
}
