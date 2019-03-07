using DALAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
                _dBSession = (IDBSession)CallContext.GetData("dbSession");
                if (_dBSession == null)
                {
                    _dBSession = new DBSession();
                    CallContext.SetData("dbSession", _dBSession);
                }
                return _dBSession;
            }
        }
    }
}
