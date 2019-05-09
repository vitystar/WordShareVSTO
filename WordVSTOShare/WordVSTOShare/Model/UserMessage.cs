using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordVSTOShare.Model
{
    [Serializable]
    public class UserMessage
    {
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string IPAddress { get; set; }
    }
}
