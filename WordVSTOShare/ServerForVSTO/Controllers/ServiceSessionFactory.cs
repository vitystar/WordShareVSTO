﻿using BLLAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace ServerForVSTO.Controllers
{
    public class ServiceSessionFactory
    {

        private static IServiceSession _serviceSession;
        public static IServiceSession ServiceSession
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