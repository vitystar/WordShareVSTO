using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Key]
        public Guid ID { get; set; }
        /// <summary>
        /// 组织名称
        /// </summary>
        [StringLength(32),Required]
        public string OrganizationName { get; set; }
        /// <summary>
        /// 组织密码，注册用户时需要该密码来加入组织
        /// </summary>
        [StringLength(32),Required]
        public string Password { get; set; }
        /// <summary>
        /// 组织中的模板文件
        /// </summary>
        public virtual ICollection<WordTemplet> WordTemplets { get; set; }
        /// <summary>
        /// 组织成员
        /// </summary>
        public virtual ICollection<UserInfo> UserInfos { get; set; }
    }
}
