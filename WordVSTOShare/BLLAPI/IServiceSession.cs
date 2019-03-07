using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLAPI
{
    public interface IServiceSession
    {
        IUserInfoService UserInfoService { get; }
        IWordTempletService WordTempletService { get; }
        IOrganizationInfoService OrganizationInfoService { get; }
    }
}
