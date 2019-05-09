using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordVSTOShare.Model
{
    public class Token:StateMessage
    {
        public int ID { get; set; }
        public string Key { get; set; }
        public DateTime CurrentTime { get; set; }
    }
}
