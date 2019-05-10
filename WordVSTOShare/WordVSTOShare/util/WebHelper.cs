﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordVSTOShare.util
{
    public static class WebHelper
    {

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
            HttpWebRequest request = WebRequest.Create(uri) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/json";
            //try
            //{
            string str = JsonConvert.SerializeObject(obj);
            byte[] buffer = Encoding.UTF8.GetBytes(str);
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            WebResponse response = request.GetResponse();
            str = (new StreamReader(response.GetResponseStream(), Encoding.UTF8)).ReadToEnd();
            return JsonConvert.DeserializeObject<T>(str);
            //}
            //catch
            //{

            //}
            //webClient.Headers["Accept"] = "application/json";
            //webClient.Encoding = Encoding.UTF8;
            //string result = webClient.UploadString(JsonConvert.SerializeObject(obj), uri);
            //return JsonConvert.DeserializeObject<T>(result);
        }
    }
}