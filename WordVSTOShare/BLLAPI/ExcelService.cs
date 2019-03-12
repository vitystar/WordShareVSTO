using DALAPI;
using ModelAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLAPI
{
    public class ExcelService : BaseService<ExcelTemplet>, IExcelService
    {
        public ExcelService() : base(DBSessionFactory.DBSession.ExcelDal)
        {
        }
    }
}
