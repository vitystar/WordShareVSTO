using DALAPI;
using ModelAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLAPI
{
    public class WordTempletService : BaseService<WordTemplet>,IWordTempletService
    {
        public WordTempletService() : base(DBSessionFactory.DBSession.WordTempletDal) { }

    }
}
