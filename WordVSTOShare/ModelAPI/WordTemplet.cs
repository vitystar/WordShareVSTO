using System;
using System.Collections.Generic;
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
        public int ID { get; set; }
        /// <summary>
        /// 模板名称
        /// </summary>
        public string TempletName { get; set; }
        /// <summary>
        /// 模板文件简介
        /// </summary>
        public string TempletIntroduction { get; set; }
        /// <summary>
        /// 模板所属组织
        /// </summary>
        public Guid Organization { get; set; }
        /// <summary>
        /// 文档的可访问性
        /// </summary>
        public Accessibility Accessibility { get; set; }
        /// <summary>
        /// 模板文件路径
        /// </summary>
        public string FilePath { get; set; }
        /// <summary>
        /// 模板上传的时间
        /// </summary>
        public DateTime ModTime { get; set; }
    }
}
