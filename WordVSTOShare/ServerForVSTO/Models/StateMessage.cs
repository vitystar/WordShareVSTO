using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerForVSTO.Models
{
    public class StateMessage
    {
        public StateCode StateCode { get; set; }
        public string StateDescription { get; set; }
    }
}