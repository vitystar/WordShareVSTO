using DALAPI;
using ModelAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLAPI
{
    public class UserInfoService : BaseService<UserInfo>, IUserInfoService
    {
        public UserInfoService() : base(DBSessionFactory.DBSession.UserInfoDal) { }

        public override bool EditEntity(UserInfo entity) => EditEntityWithSelect(u => u.ID == entity.ID, (temp) =>
            {
                temp.UserName = entity.UserName;
                temp.UserPwd = entity.UserPwd;
                temp.UserAuth = entity.UserAuth;
                temp.PhoneNumber = entity.PhoneNumber;
                if (temp.Organization != entity.Organization)
                    temp.Organization = entity.Organization;
                return temp;
            });
    }
}
