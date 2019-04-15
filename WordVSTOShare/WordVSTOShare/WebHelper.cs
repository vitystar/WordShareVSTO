using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordVSTOShare
{
    public static class WebHelper
    {
        private static WebClient webClient = new WebClient();

        /// <summary>
        /// 发送post请求
        /// </summary>
        /// <typeparam name="S">传入的对象实体类型</typeparam>
        /// <typeparam name="T">获得的对象实体类型</typeparam>
        /// <param name="obj">传入的对象实体</param>
        /// <param name="uri">上传的地址信息</param>
        /// <returns>获得的对象实体</returns>
        public static T GetJson<S, T>(S obj, string uri) where T : class, new() where S : class, new()
        {
            webClient.Headers["Accept"] = "application/json";
            webClient.Encoding = Encoding.UTF8;
            string result = webClient.UploadString(JsonConvert.SerializeObject(obj), uri);
            return JsonConvert.DeserializeObject<T>(result);
        }


    }
}
