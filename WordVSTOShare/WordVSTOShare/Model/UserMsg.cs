using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerForVSTO.Models
{
    /// <summary>
    /// 登陆时使用的用户模型，仅用于用户登陆时的参数传递
    /// </summary>
    public class UserMsg:StateMessage
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string IPAddress { get; set; }
    }
}