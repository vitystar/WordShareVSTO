using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordVSTOShare.Model
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
        /// 只读权限
        /// </summary>
        User,
        /// <summary>
        /// 可上传权限
        /// </summary>
        Uploader,
        /// <summary>
        /// 管理员权限
        /// </summary>
        Admin
    }
}
