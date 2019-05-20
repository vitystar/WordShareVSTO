using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WordVSTOShare.Model
{
    /// <summary>
    /// 筛选选项
    /// </summary>
    public class ScreenResultModel:Token
    {

        public ScreenResultModel()
        {

        }

        public ScreenResultModel(int pageIndex,string search,Accessibility accessibility,TempletType templetType)
        {
            PageIndex = pageIndex;
            Search = search;
            Accessable = accessibility;
            TempletType = templetType;
        }
        /// <summary>
        /// 当前页码
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        /// 搜索字符串
        /// </summary>
        public string Search { get; set; }
        /// <summary>
        /// 权限
        /// </summary>
        public Accessibility Accessable { get; set; }
        /// <summary>
        /// 模板类型
        /// </summary>
        public TempletType TempletType { get; set; }


    }
}