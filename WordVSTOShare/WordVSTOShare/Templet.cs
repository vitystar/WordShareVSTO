using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.Office.Tools.Ribbon;
using WordVSTOShare.Model;
using WordVSTOShare.util;

namespace WordVSTOShare
{
    public partial class Templet
    {

        private readonly string userFileName = "user.wtp";

        private void Templet_Load(object sender, RibbonUIEventArgs e)
        {
            if (FileHelper.FileExist(userFileName))
            {
                FormFactory.UserMessage = FileHelper.ReadObject<UserMessage>(userFileName);
                FormFactory.UserMessage = WebHelper.GetJson<UserMessage, UserMessage>(FormFactory.UserMessage, userFileName);
            }
            else
                IPAddr.Text = "http://office.xiaowenyu.top";
        }
        

        private void GrpBroswer_DialogLauncherClick(object sender, RibbonControlEventArgs e)
        {
            if(FormFactory.UserMessage == null)
            {
                MessageBox.Show("无服务器信息或身份验证未通过");
                return;
            }
            FormFactory.TempletForm = new TempletList(cmbDownloadType.Text, cmbDownloadAccess.Text);
            FormFactory.TempletForm.Show();
        }

        private void btnSaveSetting_Click(object sender, RibbonControlEventArgs e)
        {
            FormFactory.UserMessage = WebHelper.GetJson<UserMessage, UserMessage>(new UserMessage() { UserName = UserName.Text, UserPassword = PassWord.Text }, IPAddr.Text + @"/JsonAPI/GetUser");
            FormFactory.UserMessage.IPAddress = IPAddr.Text;
            FileHelper.SaveObject(FormFactory.UserMessage, userFileName);
        }

        private void btnServerWeb_Click(object sender, RibbonControlEventArgs e)
        {
            if(FormFactory.UserMessage == null)
            {
                MessageBox.Show("无服务器信息或身份验证未通过");
                return;
            }
            System.Diagnostics.Process.Start("iexplore.exe",FormFactory.UserMessage.IPAddress);
        }

        private void btnOfficalWeb_Click(object sender, RibbonControlEventArgs e)
        {
            System.Diagnostics.Process.Start("iexplore.exe", "office.xwyhome.top");
        }

        private void btnUpload_Click(object sender, RibbonControlEventArgs e)
        {
            if (FormFactory.UserMessage == null)
            {
                MessageBox.Show("无服务器信息或身份验证未通过");
                return;
            }
        }
    }
}
