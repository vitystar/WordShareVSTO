using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerForVSTO.Models
{
    /// <summary>
    /// 验证用户信息使用的Token，由GetList颁发。除登陆外几乎每个请求都要验证Token以保证安全性
    /// </summary>
    public class Token:StateMessage
    {
        public string TokenValue { get; set; }
    }
}