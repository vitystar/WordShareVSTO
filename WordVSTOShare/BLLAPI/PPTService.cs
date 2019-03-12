using DALAPI;
using ModelAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLAPI
{
    public class PPTService : BaseService<PPTTemplet>, IPPTService
    {
        public PPTService() : base(DBSessionFactory.DBSession.PPTDal)
        {
        }
    }
}
