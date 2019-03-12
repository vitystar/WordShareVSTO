using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALAPI
{
    /// <summary>
    /// 封装数据操作类
    /// </summary>
    public interface IDBSession
    {
        /// <summary>
        /// 用户操作对象
        /// </summary>
        IUserInfoDal UserInfoDal { get; }
        /// <summary>
        /// 文档模板操作对象
        /// </summary>
        IWordTempletDal WordTempletDal { get; }
        /// <summary>
        /// 组织成员操作对象
        /// </summary>
        IOrganizationInfoDal OrganizationInfoDal { get; }
        /// <summary>
        /// 表格模板操作对象
        /// </summary>
        IExcelDal ExcelDal { get; }
        /// <summary>
        /// 幻灯片模板操作对象
        /// </summary>
        IPPTDal PPTDal { get; }
        /// <summary>
        /// 图片素材操作对象
        /// </summary>
        IImageDal ImageDal { get; }
        /// <summary>
        /// 音频素材操作对象
        /// </summary>
        IAudioDal AudioDal { get; }
        /// <summary>
        /// 视频素材操作对象
        /// </summary>
        IVideoDal VideoDal { get; }
    }
}
