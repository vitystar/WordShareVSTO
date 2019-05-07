using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerForVSTO.Models
{
    public class RequestType
    {
        public string tmpType { get; set; }
        public string tmpAccess { get; set; }
        public UserMsg user { get; set; }
    }
}