using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelAPI
{
    public class OrganizationInfo
    {
        /// <summary>
        /// 组织标识符，使用GUID保证唯一性并初步保证隐私
        /// </summary>
        public Guid ID { get; set; }
        /// <summary>
        /// 组织名称
        /// </summary>
        public string OrganizationName { get; set; }
        /// <summary>
        /// 组织密码，注册用户时需要该密码来加入组织
        /// </summary>
        public string Password { get; set; }
    }
}
