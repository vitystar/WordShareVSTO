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
    }
}
