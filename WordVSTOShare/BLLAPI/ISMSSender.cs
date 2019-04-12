namespace BLLAPI
{
    /// <summary>
    /// 发送短信方法
    /// </summary>
    public interface ISMSSender
    {
        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="phoneNumber">接收人</param>
        /// <param name="templateCode">模板名称</param>
        /// <param name="signName">签名</param>
        void SendSMS(string phoneNumber, TemplateCode templateCode, string signName);
    }
}