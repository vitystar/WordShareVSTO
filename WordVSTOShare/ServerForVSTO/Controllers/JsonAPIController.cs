using Microsoft.IdentityModel.Tokens;
using ModelAPI;
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

        private readonly JWTToken token = new JWTToken();

        [AllowAnonymous]
        public ActionResult GetUser(UserMsg user)
        {
            UserInfo userInfo = ServiceSessionFactory.ServiceSession.UserInfoService.LoadEntity(u => u.UserName == user.UserName).FirstOrDefault();
            if (userInfo == null)
                return Json(new Token() { StateCode = StateCode.noUser, StateDescription = "用户不存在" });
            if (userInfo.UserPwd != user.UserPassword)
                return Json(new Token() { StateCode = StateCode.wrongPassword, StateDescription = "用户名或密码错误" });
            Claim[] claims = new Claim[] {
                new Claim(ClaimTypes.Sid,userInfo.ID.ToString()),
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(ClaimTypes.GroupSid,userInfo.Organization.ID.ToString()),
                new Claim(ClaimTypes.Role,userInfo.UserAuth.ToString())
            };
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(token.SecretKey));
            SigningCredentials sign = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken jwtToken = new JwtSecurityToken(
                token.Issuer,
                token.Audience,
                claims,
                DateTime.Now,
                DateTime.Now.AddMinutes(30),
                sign
                );
            return Json(new Token() { StateCode = StateCode.normal, StateDescription = "登陆成功", Value = new JwtSecurityTokenHandler().WriteToken(jwtToken) });
        }

        // GET: JsonAPI
        //public ActionResult GetUser(UserMsg user)
        //{
        //    UserInfo userInfo = ServiceSessionFactory.ServiceSession.UserInfoService.LoadEntity(u => u.UserName == user.UserName).FirstOrDefault();
        //    if (userInfo != null)
        //        if (userInfo.UserPwd == userInfo.UserPwd)
        //        {
        //            SHA256Managed sha = new SHA256Managed();
        //            Random r = new Random();
        //            string key = Guid.NewGuid().ToString().Replace("-", "");
        //            DateTime currentTime = DateTime.Now;
        //            string value = BitConverter.ToString(sha.ComputeHash(Encoding.UTF8.GetBytes(userInfo.ID+ currentTime.ToString() + key+r.Next().ToString()))).Replace("-", "");
        //            value = BitConverter.ToString(sha.ComputeHash(Encoding.UTF8.GetBytes(value))).Replace("-", "");
        //            Token token = new Token() { ID = userInfo.ID, Key = key, Value = value, CurrentTime = currentTime, StateCode= StateCode.normal, StateDescription="获取token成功"};
        //            UserMsg userMsg = new UserMsg() { Id=userInfo.ID,UserName = userInfo.UserName, UserPassword = userInfo.UserPwd, StateCode = StateCode.normal, StateDescription = "获取token成功" };
        //            HttpRuntime.Cache.Insert(key, userMsg, null, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(30));
        //            return Json(token);
        //        }
        //        else
        //            return Json(new Token() { StateCode = StateCode.wrongPassword, StateDescription = "密码错误" });
        //    else
        //        return Json(new Token() { StateCode = StateCode.noUser, StateDescription = "用户不存在" });

        //}


        public ActionResult GetList(Token token)//RequestType type)
        {

            UserForTemplet user = new ValidateToken().CheckUser(token.Value);
            return Json(user);

            //Enum.TryParse(type.tmpType, out TempletType temp);
            //switch (temp)
            //{
            //    case TempletType.WordTemplet:
            //        return Json(ServiceSessionFactory.ServiceSession.WordTempletService.LoadEntity(w => w.User.UserName == type.user.UserName && (w.Accessibility.ToString() == type.tmpAccess)).ToArray());
            //    case TempletType.ExcelTemplet:
            //        return Json(ServiceSessionFactory.ServiceSession.ExcelService.LoadEntity(w => w.User.UserName == type.user.UserName && w.Accessibility.ToString() == type.tmpAccess).ToArray());
            //    case TempletType.PPTTemplet:
            //        return Json(ServiceSessionFactory.ServiceSession.PPTService.LoadEntity(w => w.User.UserName == type.user.UserName && w.Accessibility.ToString() == type.tmpAccess).ToArray());
            //    case TempletType.ImageTemplet:
            //        return Json(ServiceSessionFactory.ServiceSession.ImageService.LoadEntity(w => w.User.UserName == type.user.UserName && w.Accessibility.ToString() == type.tmpAccess).ToArray());
            //    case TempletType.VideoTemplet:
            //        return Json(ServiceSessionFactory.ServiceSession.VideoService.LoadEntity(w => w.User.UserName == type.user.UserName && w.Accessibility.ToString() == type.tmpAccess).ToArray());
            //    case TempletType.AudioTemplet:
            //        return Json(ServiceSessionFactory.ServiceSession.AudioService.LoadEntity(w => w.User.UserName == type.user.UserName && w.Accessibility.ToString() == type.tmpAccess).ToArray());
            //    default:
            //        return Json(ServiceSessionFactory.ServiceSession.WordTempletService.LoadEntity(w => w.User.UserName == type.user.UserName && w.Accessibility.ToString() == type.tmpAccess).ToArray());
            //}
        }

    }
}