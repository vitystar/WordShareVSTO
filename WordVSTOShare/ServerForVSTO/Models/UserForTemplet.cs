using ModelAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerForVSTO.Models
{
    public class UserForTemplet : StateMessage
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public Guid OrganizationID { get; set; }
        public UserAuth Auth { get; set; }
    }
}