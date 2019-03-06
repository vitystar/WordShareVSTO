using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelAPI
{
    /// <summary>
    /// 用户权限信息
    /// </summary>
    public enum UserAuth
    {
        /// <summary>
        /// 访客权限
        /// </summary>
        Guest,
        /// <summary>
        /// 普通用户
        /// </summary>
        User,
        /// <summary>
        /// 管理员权限
        /// </summary>
        Admin
    }
}
