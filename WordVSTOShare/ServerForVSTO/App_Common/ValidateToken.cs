using Microsoft.IdentityModel.Tokens;
using ModelAPI;
using ServerForVSTO.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Filters;

namespace ServerForVSTO.App_Common
{
    public class ValidateToken
    {

        private readonly JWTSetting setting = new JWTSetting();

        public UserForTemplet CheckUser(string token)
        {
            try
            {
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler(); // 创建一个JwtSecurityTokenHandler类，用来后续操作
                JwtSecurityToken jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken; // 将字符串token解码成token对象
                if (jwtToken == null)
                    return new UserForTemplet() { StateCode = StateCode.tokenError, StateDescription = "token格式不正确" };
                byte[] symmetricKey = Encoding.UTF8.GetBytes(setting.SecretKey); // 生成编码对应的字节数组
                var validationParameters = new TokenValidationParameters() // 生成验证token的参数
                {
                    RequireExpirationTime = true, // token是否包含有效期
                    ValidateIssuer = false, // 验证秘钥发行人，如果要验证在这里指定发行人字符串即可
                    ValidateAudience = false, // 验证秘钥的接受人，如果要验证在这里提供接收人字符串即可
                    IssuerSigningKey = new SymmetricSecurityKey(symmetricKey) // 生成token时的安全秘钥
                };
                // 接受解码后的token对象
                ClaimsPrincipal principal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken securityToken);// 返回秘钥的主体对象，包含秘钥的所有相关信息
                ClaimsIdentity identity = principal?.Identity as ClaimsIdentity; // 获取主声明标识
                if (identity == null) return new UserForTemplet() { StateCode = StateCode.tokenCheckError, StateDescription = "无法获取主证书" };
                if (!identity.IsAuthenticated) return new UserForTemplet() { StateCode = StateCode.identityError, StateDescription = "身份验证失败" };
                Claim userNameClaim = identity.FindFirst(ClaimTypes.Name); // 获取声明类型是ClaimTypes.Name的第一个声明
                Claim userIDClaim = identity.FindFirst(ClaimTypes.Sid);
                Claim usergidClaim = identity.FindFirst(ClaimTypes.GroupSid);
                Claim userAuthClaim = identity.FindFirst(ClaimTypes.Role);
                Enum.TryParse(userAuthClaim.Value, out UserAuth auth);
                return new UserForTemplet()
                {
                    ID = int.Parse(userIDClaim.Value),
                    UserName = userNameClaim.Value,
                    OrganizationID = new Guid(usergidClaim.Value),
                    Auth = auth,
                    StateCode = StateCode.normal,
                    StateDescription = "查询用户成功"
                };
            }

            catch (Exception ex)
            {
                return new UserForTemplet() { StateCode = StateCode.tokenCheckError, StateDescription = "token检查时出现内部错误" };
            }
        }
    }
}