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

        //public override bool EditEntity(UserInfo entity)
        //{
        //    UserInfo temp = CurrentDal.LoadEntity(u => u.ID == entity.ID).FirstOrDefault();
        //    temp.UserName = entity.UserName;
        //    temp.UserPwd = entity.UserPwd;
        //    temp.UserAuth = entity.UserAuth;
        //    temp.PhoneNumber = entity.PhoneNumber;
        //    temp.Organization = entity.Organization;
        //    return CurrentDal.EditEntity(temp);
        //}
    }
}
