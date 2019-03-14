using ModelAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLAPI
{
    /// <summary>
    /// 组织成员操作接口
    /// </summary>
    public interface IOrganizationInfoService:IBaseService<OrganizationInfo>
    {
        /// <summary>
        /// 添加组织成员
        /// </summary>
        /// <param name="organizationName">组织名称</param>
        /// <param name="password">组织密码</param>
        /// <param name="userAuth">组织成员默认权限</param>
        /// <returns>添加的组织成员</returns>
        OrganizationInfo AddOrganization(string organizationName, string password, UserAuth userAuth);
        /// <summary>
        /// 判断并删除组织
        /// </summary>
        /// <param name="organization">需要鉴定的组织对象</param>
        /// <returns>删除结果</returns>
        bool OrganizationDelete(OrganizationInfo organization);
    }
}
