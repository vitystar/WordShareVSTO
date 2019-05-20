using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVSTOShare.Model;

namespace WordVSTOShare
{
    public class FormFactory
    {

        public static Token JWTToken { get; set; }

        private static TempletList _templetForm;
        public static TempletList TempletForm
        {
            get
            {
                if (_templetForm == null)
                {
                    _templetForm = new TempletList("文档模板", "公共模板");
                }
                return _templetForm;
            }
            set
            {
                _templetForm = value;
            }
        }
    }
}
