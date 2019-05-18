using ModelAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerForVSTO.Models
{
    /// <summary>
    /// 用于查找模板信息的用户模型，不包含密码等敏感冗余信息
    /// </summary>
    public class UserForTemplet : StateMessage
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public Guid OrganizationID { get; set; }
        public UserAuth Auth { get; set; }
    }
}