using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WordVSTOShare.Model
{
    public class TempletForJson : Token
    {
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
        /// 模板所属成员
        /// </summary>
        public int UserID { get; set; }
        /// <summary>
        /// 文档的可访问性
        /// </summary>
        public Accessibility Accessibility { get; set; }
        /// <summary>
        /// 模板文件路径
        /// </summary>
        public string FilePath { get; set; }
        /// <summary>
        /// 模板缩略图路径
        /// </summary>
        public string ImagePath { get; set; }
        /// <summary>
        /// 模板上传的时间
        /// </summary>
        public DateTime ModTime { get; set; }

    }
}