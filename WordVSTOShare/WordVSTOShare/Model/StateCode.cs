using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WordVSTOShare.Model
{
    /// <summary>
    /// 与客户端交互使用的状态码
    /// </summary>
    public enum StateCode
    {
        requestBodyError = 5,
        request = 6,
        normal = 8,
        tokenError = 10,
        nullToken = 11,
        tokenCheckError = 12,
        noUser = 15,
        wrongPassword = 16,
        identityError = 18,
        noRequestError = 21,
        permissionDenied = 30
    }
}