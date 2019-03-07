using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLAPI
{
    public class ServiceSession:IServiceSession
    {
        private IUserInfoService _userInfoService;
        private IOrganizationInfoService _organizationInfoService;
        private IWordTempletService _wordTempletService;

        public IUserInfoService UserInfoService
        {
            get
            {
                if (_userInfoService == null)
                    _userInfoService = new UserInfoService();
                return _userInfoService;
            }
        }

        public IOrganizationInfoService OrganizationInfoService
        {
            get
            {
                if (_organizationInfoService == null)
                    _organizationInfoService = new OrganizationInfoService();
                return _organizationInfoService;
            }
        }

        public IWordTempletService WordTempletService
        {
            get
            {
                if (_wordTempletService == null)
                    _wordTempletService = new WordTempletService();
                return _wordTempletService;
            }
        }
    }
}
