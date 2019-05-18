using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerForVSTO.Models
{
    public class Token:StateMessage
    {
        public string TokenValue { get; set; }
    }
}