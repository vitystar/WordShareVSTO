using Microsoft.IdentityModel.Tokens;
using ModelAPI;
using Newtonsoft.Json;
using ServerForVSTO.App_Common;
using ServerForVSTO.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ServerForVSTO.Controllers
{
    public class JsonAPIController : Controller
    {
        /// <summary>
        /// 定义秘钥常量
        /// </summary>
        private readonly JWTSetting token = new JWTSetting();
        private Common util = new Common();

        /// <summary>
        /// 由User信息获取Token，以实现客户端和服务器交互时的身份验证
        /// </summary>
        /// <param name="user">用户实体模型</param>
        /// <returns>Token的JSON对象</returns>
        [AllowAnonymous]
        public ActionResult GetUser(UserMsg user)
        {
            UserInfo userInfo = ServiceSessionFactory.ServiceSession.UserInfoService.LoadEntity(u => u.UserName == user.UserName).FirstOrDefault();//验证用户名并取用户实体
            if (userInfo == null)
                return Json(new Token() { StateCode = StateCode.noUser, StateDescription = "用户不存在" });
            if (userInfo.UserPwd != user.UserPassword)
                return Json(new Token() { StateCode = StateCode.wrongPassword, StateDescription = "用户名或密码错误" });
            userInfo.Organization = userInfo.Organization ?? new OrganizationInfo() { ID = new Guid() };
            Claim[] claims = new Claim[] {//新建证书
                new Claim(ClaimTypes.Sid,userInfo.ID.ToString()),//用户ID
                new Claim(ClaimTypes.Name,user.UserName),//用户名
                new Claim(ClaimTypes.GroupSid,userInfo.Organization.ID.ToString()),//用户所在组织ID
                new Claim(ClaimTypes.Role,userInfo.UserAuth.ToString())//用户权限
            };
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(token.SecretKey));//创建秘钥
            SigningCredentials sign = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);//从秘钥创建签名
            JwtSecurityToken jwtToken = new JwtSecurityToken(//创建TOKEN
                token.Issuer,
                token.Audience,
                claims,
                DateTime.Now,
                DateTime.Now.AddMinutes(30),
                sign
                );
            return Json(new Token() { StateCode = StateCode.normal, StateDescription = "登陆成功", TokenValue = new JwtSecurityTokenHandler().WriteToken(jwtToken) });//返回生成的Token
        }

        public ActionResult GetList(ScreenResultModel screen)
        {

            UserForTemplet user = new ValidateToken().CheckUser(screen.TokenValue);
            IQueryable<BaseTemplet> templets = util.GetScreenResult(user, screen, out int totalcount);//根据筛选条件查询结果
            List<BaseTemplet> temp = templets.ToList();//由于直接使用IQueryable赋值会抛出DataReader未释放的异常，故先转换为List。推测是IQueryable的数据库访问是用时查询，缺少异步封装导致的(就是懒得写异步了)
            List<TempletForJson> result = new List<TempletForJson>();//由于外键链接，直接使用Json实例化查询结果会导致重复引用，所以这里建立新模型以方便Json传输
            foreach (BaseTemplet templet in temp)
            {
                result.Add(new TempletForJson()
                {
                    ID = templet.ID,
                    UserID = templet.User.ID,
                    Organization = templet.Organization == null?new Guid(): templet.Organization.ID,
                    Accessibility = templet.Accessibility,
                    TempletName = templet.TempletName,
                    TempletIntroduction = templet.TempletIntroduction,
                    ImagePath = templet.ImagePath,
                    FilePath = templet.FilePath,
                    ModTime = templet.ModTime
                });
            }

            return Json(result);

        }

    }
}