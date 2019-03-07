using DALAPI;
using ModelAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLAPI
{
    public class UserInfoService : BaseService<UserInfo>,IUserInfoService
    {
        public UserInfoService() : base(DBSessionFactory.DBSession.UserInfoDal) { }



    }
}
