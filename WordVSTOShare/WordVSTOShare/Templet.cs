using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.Office.Tools.Ribbon;

namespace WordVSTOShare
{
    public partial class Templet
    {

        private readonly string userFileName = "user.wtp";

        private void Templet_Load(object sender, RibbonUIEventArgs e)
        {

        }
        

        private void GrpBroswer_DialogLauncherClick(object sender, RibbonControlEventArgs e)
        {
            if(FormFactory.UserMessage == null)
            {
                MessageBox.Show("无服务器信息或身份验证未通过");
                return;
            }
            FormFactory.TempletForm.Show();
        }

        private void btnSaveSetting_Click(object sender, RibbonControlEventArgs e)
        {
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
            System.Diagnostics.Process.Start("iexplore.exe", "word.xwyhome.top");
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
