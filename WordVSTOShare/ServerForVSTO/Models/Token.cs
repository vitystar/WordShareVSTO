using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerForVSTO.Models
{
    public class Token:StateMessage
    {
        public int ID { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public DateTime CurrentTime { get; set; }
    }
}