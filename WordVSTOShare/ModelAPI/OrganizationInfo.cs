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
        [StringLength(32), Required]
        public string OrganizationName { get; set; }
        /// <summary>
        /// 组织密码，注册用户时需要该密码来加入组织
        /// </summary>
        [StringLength(32), Required]
        public string Password { get; set; }
        /// <summary>
        /// 组织人员默认权限
        /// </summary>
        public UserAuth DefaultUserAuth { get; set; }
        /// <summary>
        /// 组织中的文档模板
        /// </summary>
        public virtual ICollection<WordTemplet> WordTemplets { get; set; }
        /// <summary>
        /// 组织中的幻灯片模板
        /// </summary>
        public virtual ICollection<PPTTemplet> PPTTemplets {get;set;}
        /// <summary>
        /// 组织中的表格模板
        /// </summary>
        public virtual ICollection<ExcelTemplet> ExcelTemplets { get; set; }
        /// <summary>
        /// 组织中的图片模板
        /// </summary>
        public virtual ICollection<ImageTemplet> ImageTemplets { get; set; }
        /// <summary>
        /// 组织中的音频模板
        /// </summary>
        public virtual ICollection<AudioTemplet> AudioTemplets { get; set; }
        /// <summary>
        /// 组织中的视频模板
        /// </summary>
        public virtual ICollection<VideoTemplet> VideoTemplets { get; set; }
        /// <summary>
        /// 组织成员
        /// </summary>
        public virtual ICollection<UserInfo> UserInfos { get; set; }
    }
}
