using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ServerForVSTO.Models
{
    public class JWTSetting : StateMessage
    {
        /// <summary>
        /// 证书颁发者
        /// </summary>
        public string Issuer { get; set; } = ConfigurationManager.AppSettings["Issuer"];
        /// <summary>
        /// 证书接收者
        /// </summary>
        public string Audience { get; set; } = ConfigurationManager.AppSettings["Audience"];
        /// <summary>
        /// 加密字符串
        /// </summary>
        public string SecretKey { get; set; } = ConfigurationManager.AppSettings["AuthKey"];
    }
}