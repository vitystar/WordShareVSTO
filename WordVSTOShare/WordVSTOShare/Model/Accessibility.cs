using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordVSTOShare.Model
{
    public enum Accessibility
    {
        /// <summary>
        /// 仅自己可见
        /// </summary>
        Private,
        /// <summary>
        /// 公共的
        /// </summary>
        Public,
        /// <summary>
        /// 仅本组织可见
        /// </summary>
        Protected
    }
}
