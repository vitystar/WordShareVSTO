using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordVSTOShare
{
    public class FormFactory
    {

        public static UserMessage UserMessage { get; set; }

        private static TempletList _templetForm;
        public static TempletList TempletForm
        {
            get
            {
                if (_templetForm == null)
                {
                    _templetForm = new TempletList();
                }
                return _templetForm;
            }
        }
    }
}
