using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerForVSTO.Models
{
    public class UserMsg:StateMessage
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string IPAddress { get; set; }
    }
}