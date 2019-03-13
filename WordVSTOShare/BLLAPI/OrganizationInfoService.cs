using DALAPI;
using ModelAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLAPI
{
    public class OrganizationInfoService : BaseService<OrganizationInfo>, IOrganizationInfoService
    {
        public OrganizationInfoService() : base(DBSessionFactory.DBSession.OrganizationInfoDal) { }

        /// <summary>
        /// 创建组织对象并添加组织
        /// </summary>
        /// <param name="organizationName">组织名称</param>
        /// <param name="password">组织密码</param>
        /// <param name="userAuth">组织成员默认权限</param>
        /// <returns>组织对象</returns>
        public OrganizationInfo AddOrganization(string organizationName,string password,UserAuth userAuth)
        {
            OrganizationInfo organizationInfo = new OrganizationInfo() { ID = Guid.NewGuid(), OrganizationName = organizationName,Password = password, DefaultUserAuth = userAuth };
            CurrentDal.AddEntity(organizationInfo);
            return organizationInfo;
        }
    }
}
