using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using Word = Microsoft.Office.Interop.Word;
using System.Windows.Forms;
using Microsoft.Office.Tools.Ribbon;
using WordVSTOShare.Model;
using WordVSTOShare.util;
using System.Drawing;

namespace WordVSTOShare
{
    public partial class Templet
    {

        private readonly string userFileName = "user.wtp";

        private void Templet_Load(object sender, RibbonUIEventArgs e)
        {
            if (FileHelper.FileExist(userFileName))
            {
                try
                {
                    UserMsg userMsg = FileHelper.ReadObject<UserMsg>(userFileName);
                    FormFactory.JWTToken = WebHelper.GetJson<UserMsg, Token>(userMsg, userMsg.IPAddress + "/JsonAPI/GetUser/");
                    if (FormFactory.JWTToken.StateCode != StateCode.normal)
                    {
                        MessageBox.Show(FormFactory.JWTToken.StateDescription);
                        FormFactory.JWTToken = null;
                    }
                    else
                    {
                        UserName.Text = userMsg.UserName;
                        PassWord.Text = userMsg.UserPassword;
                        IPAddr.Text = userMsg.IPAddress;
                    }
                }
                catch
                {
                    FileHelper.DeleteFile(userFileName);
                    IPAddr.Text = "http://office.xiaowenyu.top";
                }
            }
            else
                IPAddr.Text = "http://office.xiaowenyu.top";
        }


        private void GrpBroswer_DialogLauncherClick(object sender, RibbonControlEventArgs e)
        {
            if (FormFactory.JWTToken == null)
            {
                MessageBox.Show("无服务器信息或身份验证未通过");
                return;
            }
            FormFactory.TempletForm = new TempletList(cmbDownloadType.Text, cmbDownloadAccess.Text);
            FormFactory.TempletForm.Show();
        }

        private void btnSaveSetting_Click(object sender, RibbonControlEventArgs e)
        {
            UserMsg userMsg = new UserMsg() { UserName = UserName.Text, UserPassword = PassWord.Text, IPAddress = IPAddr.Text };
            FormFactory.JWTToken = WebHelper.GetJson<UserMsg, Token>(userMsg, IPAddr.Text + @"/JsonAPI/GetUser");
            if (FormFactory.JWTToken.StateCode != StateCode.normal)
            {
                MessageBox.Show(FormFactory.JWTToken.StateDescription);
                FormFactory.JWTToken = null;
            }
            else
            {
                MessageBox.Show("登陆成功");
                FileHelper.SaveObject(userMsg, userFileName);
            }
        }

        private void btnServerWeb_Click(object sender, RibbonControlEventArgs e)
        {
            if (FormFactory.JWTToken == null)
            {
                MessageBox.Show("无服务器信息或身份验证未通过");
                return;
            }
            System.Diagnostics.Process.Start("iexplore.exe", IPAddr.Text);
        }

        private void btnOfficalWeb_Click(object sender, RibbonControlEventArgs e)
        {
            System.Diagnostics.Process.Start("iexplore.exe", "office.xwyhome.top");
        }

        private void btnUpload_Click(object sender, RibbonControlEventArgs e)
        {
            if (FormFactory.JWTToken == null)
            {
                MessageBox.Show("无服务器信息或身份验证未通过");
                return;
            }
            if (!Globals.ThisAddIn.Application.ActiveDocument.Saved)
            {
                var result = MessageBox.Show("保存当前文档？", "保存", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (!(result == DialogResult.OK))
                    return;
                Globals.ThisAddIn.Application.ActiveDocument.Save();
            }
                string word = Globals.ThisAddIn.Application.ActiveDocument.FullName;
                Word.Range range = Globals.ThisAddIn.Application.ActiveDocument.Range(0, 0);
                range.Select();
                Bitmap image = new Bitmap(1920, 1080);//初始化一个相同大小的窗口
                Graphics g = Graphics.FromImage(image);
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;//高质量
                g.CopyFromScreen(0, 0, 0, 0, new Size(1920, 1080));//截屏
                string tempFile = new string(word.Take(word.LastIndexOf('\\')).ToArray()) + @"\temp.png";
                image.Save(tempFile, System.Drawing.Imaging.ImageFormat.Png);//保存为图片

        }
    }
}
