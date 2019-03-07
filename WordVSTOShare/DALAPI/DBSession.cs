using ModelAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALAPI
{
    /// <summary>
    /// 封装数据操作类
    /// </summary>
    public class DBSession
    {
        

        private IUserInfoDal _userInfoDal;
        private IOrganizationInfoDal _organizationInfoDal;
        private IWordTempletDal _wordTempletDal;

        /// <summary>
        /// 组织数据操作对象
        /// </summary>
        public IOrganizationInfoDal OrganizationInfoDal
        {
            get
            {
                if (_organizationInfoDal == null)
                {
                    _organizationInfoDal = new OrganizationInfoDal();
                    _userInfoDal.CreateDataBase();
                }
                return _organizationInfoDal;
            }
        }

        /// <summary>
        /// 模板数据操作对象
        /// </summary>
        public IWordTempletDal WordTempletDal
        {
            get
            {
                if (_wordTempletDal == null)
                {
                    _wordTempletDal = new WordTempletDal();
                    _wordTempletDal.CreateDataBase();
                }
                return _wordTempletDal;
            }
        }

        /// <summary>
        /// 用户数据操作对象
        /// </summary>
        public IUserInfoDal UserInfoDal
        {
            get
            {
                if (_userInfoDal == null)
                {
                    _userInfoDal = new UserInfoDal();
                    _userInfoDal.CreateDataBase();
                }
                return _userInfoDal;
            }
        }
    }
}
