using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Exceptions;
using Aliyun.Acs.Core.Http;
using Aliyun.Acs.Core.Profile;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLAPI
{
    public class SMSSender : ISMSSender
    {
        public void SendSMS(string phoneNumber, TemplateCode templateCode, string signName = "signName")
        {

            IClientProfile profile = DefaultProfile.GetProfile("default", ConfigurationManager.AppSettings["accessKeyId"], ConfigurationManager.AppSettings["accessSecret"]);
            DefaultAcsClient client = new DefaultAcsClient(profile);
            CommonRequest request = new CommonRequest
            {
                Method = MethodType.POST,
                Domain = "dysmsapi.aliyuncs.com",
                Version = "2017-05-25",
                Action = "SendSms"
            };
            // request.Protocol = ProtocolType.HTTP;
            request.AddQueryParameters("PhoneNumbers", phoneNumber);
            request.AddQueryParameters("SignName", ConfigurationManager.AppSettings[signName]);
            request.AddQueryParameters("TemplateCode", ConfigurationManager.AppSettings[templateCode.ToString()]);
            try
            {
                CommonResponse response = client.GetCommonResponse(request);
                Console.WriteLine(Encoding.Default.GetString(response.HttpResponse.Content));
            }
            catch (ServerException e)
            {
                Console.WriteLine(e);
            }
            catch (ClientException e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
