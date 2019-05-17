using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerForVSTO.Models
{
    public enum StateCode
    {
        request = 6,
        normal = 8,
        tokenError = 10,
        nullToken = 11,
        tokenCheckError = 12,
        noUser = 15,
        wrongPassword = 16,
        identityError = 18,
    }
}