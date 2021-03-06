﻿using ModelAPI;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DALAPI
{
    public class EFFactory
    {
        /// <summary>
        /// 获取线程内唯一的EF对象
        /// </summary>
        /// <returns>数据操作对象</returns>
        public static WordDBContext GetEF()
        {
            WordDBContext dbContext = (WordDBContext)CallContext.GetData("dbContext");//保证EF对象线程内唯一
            if (dbContext == null)
            {
                dbContext = new WordDBContext();
                dbContext.Configuration.ValidateOnSaveEnabled = false;
                CallContext.SetData("dbContext", dbContext);
            }
            return dbContext;

        }
    }
}
