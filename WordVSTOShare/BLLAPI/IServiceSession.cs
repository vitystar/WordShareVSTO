using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLAPI
{
    /// <summary>
    /// 业务服务接口
    /// </summary>
    public interface IServiceSession
    {
        /// <summary>
        /// 用户信息服务
        /// </summary>
        IUserInfoService UserInfoService { get; }
        /// <summary>
        /// 文档模板服务
        /// </summary>
        IWordTempletService WordTempletService { get; }
        /// <summary>
        /// 组织成员服务
        /// </summary>
        IOrganizationInfoService OrganizationInfoService { get; }
        /// <summary>
        /// 表格模板服务
        /// </summary>
        IExcelService ExcelService { get; }
        /// <summary>
        /// 幻灯片模板服务
        /// </summary>
        IPPTService PPTService { get; }
        /// <summary>
        /// 图片素材服务
        /// </summary>
        IImageService ImageService { get; }
        /// <summary>
        /// 音频素材服务
        /// </summary>
        IAudioService AudioService { get; }
        /// <summary>
        /// 视频素材服务
        /// </summary>
        IVideoService VideoService { get; }

    }
}
