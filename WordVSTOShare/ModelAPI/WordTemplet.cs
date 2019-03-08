using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelAPI
{
    /// <summary>
    /// word的模板信息
    /// </summary>
    public class WordTemplet
    {
        /// <summary>
        /// 模板标识
        /// </summary>
        [Key]
        public int ID { get; set; }
        /// <summary>
        /// 模板名称
        /// </summary>
        [StringLength(32),Required]
        public string TempletName { get; set; }
        /// <summary>
        /// 模板文件简介
        /// </summary>
        [StringLength(255)]
        public string TempletIntroduction { get; set; }
        /// <summary>
        /// 模板所属组织
        /// </summary>
        public virtual OrganizationInfo Organization { get; set; }
        /// <summary>
        /// 模板所属成员
        /// </summary>
        [Required]
        public virtual UserInfo User { get; set; }
        /// <summary>
        /// 文档的可访问性
        /// </summary>
        [Required]
        public Accessibility Accessibility { get; set; }
        /// <summary>
        /// 模板文件路径
        /// </summary>
        [StringLength(255),Required]
        public string FilePath { get; set; }
        /// <summary>
        /// 模板缩略图路径
        /// </summary>
        [StringLength(255),Required]
        public string ImagePath { get; set; }
        /// <summary>
        /// 模板上传的时间
        /// </summary>
        [Required]
        public DateTime ModTime { get; set; }
    }
}
