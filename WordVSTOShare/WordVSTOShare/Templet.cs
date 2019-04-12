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
        private void Templet_Load(object sender, RibbonUIEventArgs e)
        {
            FormFactory.WordTemplet = this;
            if (File.Exists(FormFactory.MessagePath))
            {
                try
                {
                    using (Stream stream = new FileStream(FormFactory.MessagePath, FileMode.Open, FileAccess.ReadWrite))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        FormFactory.UserMessage = (UserMessage)bf.Deserialize(stream);
                        stream.Close();
                    }
                    UserName.Text = FormFactory.UserMessage.UserName;
                    PassWord.Text = FormFactory.UserMessage.UserPassword;
                    IPAddr.Text = FormFactory.UserMessage.IPAddress;
                }
                catch
                {
                    MessageBox.Show("信息文件损坏");
                }
            }
            else
                IPAddr.Text = "word.xwyhome.top";
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
            string ipaddr = UserName.Text;

            if (true)
            {
                FormFactory.UserMessage = new UserMessage() {UserName = UserName.Text,UserPassword =  PassWord.Text,IPAddress=IPAddr.Text};
                //try
                //{
                    using(FileStream stream = new FileStream(FormFactory.MessagePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        bf.Serialize(stream, FormFactory.UserMessage);
                    }
                //}
                //catch
                //{
                //    MessageBox.Show("保存失败，请检查权限");
                //}
            }

            if (Regex.IsMatch(ipaddr.Trim(), @"(?=(\b|\D))(((\d{1,2})|(1\d{1,2})|(2[0-4]\d)|(25[0-5]))\.){3}((\d{1,2})|(1\d{1,2})|(2[0-4]\d)|(25[0-5]))(?=(\b|\D))"))
                MessageBox.Show("access");
            else
                MessageBox.Show("IP地址不规范");
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
