using BLLAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace ServerForVSTO.Controllers
{
    public class ServiceSessionFactory
    {

        private IServiceSession _serviceSession;
        /// <summary>
        /// 获取服务实体对象
        /// </summary>
        public IServiceSession ServiceSession
        {
            get
            {
                _serviceSession = (IServiceSession)CallContext.GetData("serviceSession");
                if (_serviceSession == null)
                {
                    _serviceSession = new ServiceSession();
                    CallContext.SetData("serviceSession", _serviceSession);
                }
                return _serviceSession;
            }
        }
    }
}