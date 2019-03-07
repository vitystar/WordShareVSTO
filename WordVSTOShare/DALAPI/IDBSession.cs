using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALAPI
{
    public interface IDBSession
    {
        IUserInfoDal UserInfoDal { get; }
        IWordTempletDal WordTempletDal { get; }
        IOrganizationInfoDal OrganizationInfoDal { get; }
    }
}
