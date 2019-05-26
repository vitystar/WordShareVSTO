using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WordVSTOShare.Model;

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
        public static async Task<T> GetJson<S, T>(S obj, string uri) where T : class, new() where S : class, new()
        {
            HttpWebRequest request;
            if (uri.StartsWith("https", StringComparison.OrdinalIgnoreCase))
            {
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback((object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors) => true);
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Ssl3;
                request = WebRequest.Create(uri) as HttpWebRequest;
                request.ProtocolVersion = HttpVersion.Version10;

            }
            else
            {
                request = WebRequest.Create(uri) as HttpWebRequest;
            }
            request.Method = "POST";
            request.ContentType = "application/json";
            //try
            //{
            string str = JsonConvert.SerializeObject(obj);
            byte[] buffer = Encoding.UTF8.GetBytes(str);
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            WebResponse response;
            return await Task.Run(() =>
            {
                response = request.GetResponse();
                str = (new StreamReader(response.GetResponseStream(), Encoding.UTF8)).ReadToEnd();
                return JsonConvert.DeserializeObject<T>(str);
            });
            //}
            //catch
            //{

            //}
        }

        /// <summary>
        /// 上传模板
        /// </summary>
        /// <typeparam name="T">返回值的类型</typeparam>
        /// <param name="url">服务器地址</param>
        /// <param name="templet">上传的模板信息实体</param>
        /// <param name="filePath">文档路径和缩略图路径，顺序不能交换</param>
        /// <returns>服务端的返回信息</returns>
        public async static Task<T> UploadFile<T>(string url, TempletForJson templet, params string[] filePath) where T : StateMessage, new()
        {
            if (filePath.Length == 2)
                return await Task.Run(() =>
                {
                    #region 构建WebClient对象
                    using (WebClient client = new WebClient())
                    {
                        if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
                        {
                            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback((object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors) => true);
                            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Ssl3;

                        }
                        string responseContent;
                        MemoryStream memStream = new MemoryStream();
                        HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
                        #endregion
                        #region 构建文件流对象
                        FileStream fileStream1 = new FileStream(filePath[0], FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                        FileStream fileStream2 = new FileStream(filePath[1], FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                        #endregion
                        #region 边界符
                        string boundary = "---------------" + DateTime.Now.Ticks.ToString("x");
                        byte[] beginBoundary = Encoding.ASCII.GetBytes("--" + boundary + "\r\n");
                        #endregion
                        #region 结束符
                        byte[] endBoundary = Encoding.ASCII.GetBytes("--" + boundary + "--\r\n");
                        #endregion
                        #region 初始化Client属性，POST方式，超时时间和表单提交
                        webRequest.Method = "POST";
                        webRequest.Timeout = 2000;
                        webRequest.ContentType = "multipart/form-data; boundary=" + boundary;
                        #endregion
                        #region 写入文件1
                        const string filePartHeader =
                            "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\n" +
                             "Content-Type: application/octet-stream\r\n\r\n";
                        string header = string.Format(filePartHeader, "File1", filePath[0]);//构建参数头
                        byte[] headerbytes = Encoding.UTF8.GetBytes(header);
                        memStream.Write(beginBoundary, 0, beginBoundary.Length);
                        memStream.Write(headerbytes, 0, headerbytes.Length);//向流中写入参数头
                        var buffer = new byte[1024];//创建缓冲区
                        int bytesRead;
                        while ((bytesRead = fileStream1.Read(buffer, 0, buffer.Length)) != 0)
                        {
                            memStream.Write(buffer, 0, bytesRead);//读取文件内容
                        }
                        #endregion
                        #region 写入文件2
                        header = string.Format(filePartHeader, "File2", filePath[1]);//构建参数头
                        header = "\r\n--" + boundary + "\r\n" + header;
                        headerbytes = Encoding.UTF8.GetBytes(header);
                        memStream.Write(headerbytes, 0, headerbytes.Length);//向流中写入参数头
                        while ((bytesRead = fileStream2.Read(buffer, 0, buffer.Length)) != 0)
                        {
                            memStream.Write(buffer, 0, bytesRead);
                        }
                        #endregion
                        #region 写入所有其他字符参数
                        var stringKeyHeader = "\r\n--" + boundary +
                                                   "\r\nContent-Disposition: form-data; name=\"{0}\"" +
                                                   "\r\n\r\n{1}\r\n";
                        Model.Accessibility Access = templet.Accessibility;
                        Dictionary<string, string> stringDict = new Dictionary<string, string>();
                        stringDict.Add("TokenValue", templet.TokenValue);
                        stringDict.Add("TempletName", templet.TempletName);
                        stringDict.Add("TempletIntroduction", templet.TempletIntroduction);
                        stringDict.Add("Accessibility", ((int)templet.Accessibility).ToString());//构建字典以遍历写入流信息
                        string str = "";
                        foreach (string formitem in from string key in stringDict.Keys
                                                    select string.Format(stringKeyHeader, key, stringDict[key])
                                                             into formitem
                                                    select formitem)
                        {
                            str += formitem;
                            byte[] formitembytes = Encoding.UTF8.GetBytes(formitem);
                            memStream.Write(formitembytes, 0, formitembytes.Length);
                        }
                        #endregion
                        #region 写入结束符
                        memStream.Write(endBoundary, 0, endBoundary.Length);
                        #endregion
                        #region 发送请求，获取结果并释放对象
                        webRequest.ContentLength = memStream.Length;
                        var requestStream = webRequest.GetRequestStream();
                        memStream.Position = 0;
                        var tempBuffer = new byte[memStream.Length];
                        memStream.Read(tempBuffer, 0, tempBuffer.Length);
                        memStream.Close();
                        requestStream.Write(tempBuffer, 0, tempBuffer.Length);
                        requestStream.Close();
                        var httpWebResponse = (HttpWebResponse)webRequest.GetResponse();
                        using (var httpStreamReader = new StreamReader(httpWebResponse.GetResponseStream(),
                                                                        Encoding.GetEncoding("utf-8")))
                        {
                            responseContent = httpStreamReader.ReadToEnd();
                        }
                        fileStream1.Close();
                        fileStream2.Close();
                        httpWebResponse.Close();
                        webRequest.Abort();
                        #endregion
                        return JsonConvert.DeserializeObject<T>(responseContent);
                    }
                });
            else
                return new T() { StateCode = StateCode.requestBodyError, StateDescription = "请求参数不正确" };
        }

        public async static Task GetFile(string url,string filePath)
        {
            await Task.Run(() =>
            {
                WebClient client = new WebClient();
                byte[] data = client.DownloadData(url);//一个真正存放数据的地址，一般我们将连接存在数据库中，数据存放在数据服务器上
                FileStream fs = new FileStream(filePath, FileMode.Create);
                //将byte数组写入文件中
                fs.Write(data, 0, data.Length);
                fs.Close();
            });
        }
    }
}
