using DALAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLAPI
{
    public class DBSessionFactory
    {
        private static IDBSession _dBSession;
        public static IDBSession DBSession
        {
            get
            {
                if (_dBSession == null)
                    _dBSession = new DBSession();
                return _dBSession;
            }
        }
    }
}
