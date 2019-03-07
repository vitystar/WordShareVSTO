using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelAPI
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class UserInfo
    {
        /// <summary>
        /// 用户标识
        /// </summary>
        [Key]
        public int ID { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        [StringLength(32), Required]
        public string UserName { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        [StringLength(32), Required]
        public string UserPwd { get; set; }
        /// <summary>
        /// 用户权限
        /// </summary>
        [Required]
        public UserAuth UserAuth { get; set; }
        /// <summary>
        /// 所属组织
        /// </summary>
        public virtual OrganizationInfo Organization { get; set; }
        /// <summary>
        /// 创建的文档
        /// </summary>
        public virtual ICollection<WordTemplet> WordTemplets { get; set; }
    }
}
