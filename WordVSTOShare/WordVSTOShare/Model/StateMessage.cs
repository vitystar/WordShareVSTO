using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WordVSTOShare.Model
{
    /// <summary>
    /// 状态信息，由于与客户端交互几乎每条信息有成功或失败的状态，需要对该状态进行描述
    /// </summary>
    public class StateMessage
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public StateCode StateCode { get; set; }
        /// <summary>
        /// 状态的文字描述
        /// </summary>
        public string StateDescription { get; set; }
    }
}