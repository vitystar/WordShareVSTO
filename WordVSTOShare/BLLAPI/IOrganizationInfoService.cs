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
        OrganizationInfo AddOrganization(string organizationName, string password, UserAuth userAuth);
    }
}
