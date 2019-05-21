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
using System.Threading.Tasks;

namespace WordVSTOShare
{
    public partial class Templet
    {

        private readonly string userFileName = "user.wtp";

        private async void Templet_Load(object sender, RibbonUIEventArgs e)
        {
            if (FileHelper.FileExist(userFileName))
            {
                try
                {
                    UserMsg userMsg = await FileHelper.ReadObject<UserMsg>(userFileName);
                    FormFactory.JWTToken = await WebHelper.GetJson<UserMsg, Token>(userMsg, userMsg.IPAddress + "/JsonAPI/GetUser/");
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
                        FormFactory.userMsg = userMsg;
                    }
                }
                catch
                {
                    await FileHelper.DeleteFile(userFileName);
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

        private async void btnSaveSetting_Click(object sender, RibbonControlEventArgs e)
        {
            UserMsg userMsg = new UserMsg() { UserName = UserName.Text, UserPassword = PassWord.Text, IPAddress = IPAddr.Text };
            FormFactory.JWTToken = await WebHelper.GetJson<UserMsg, Token>(userMsg, IPAddr.Text + @"/JsonAPI/GetUser");
            if (FormFactory.JWTToken.StateCode != StateCode.normal)
            {
                MessageBox.Show(FormFactory.JWTToken.StateDescription);
                FormFactory.JWTToken = null;
            }
            else
            {
                MessageBox.Show("登陆成功");
                await FileHelper.SaveObject(userMsg, userFileName);
                FormFactory.userMsg = userMsg;
            }
        }

        private void btnServerWeb_Click(object sender, RibbonControlEventArgs e)
        {
            if (FormFactory.JWTToken == null)
            {
                MessageBox.Show("无服务器信息或身份验证未通过");
                return;
            }
            System.Diagnostics.Process.Start("iexplore.exe", FormFactory.userMsg.IPAddress);
        }

        private void btnOfficalWeb_Click(object sender, RibbonControlEventArgs e)
        {
            System.Diagnostics.Process.Start("iexplore.exe", "office.xwyhome.top");
        }

        private async void btnUpload_Click(object sender, RibbonControlEventArgs e)
        {
            if (FormFactory.JWTToken == null)
            {
                MessageBox.Show("无服务器信息或身份验证未通过");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtIntroduction.Text))
            {
                MessageBox.Show("未填写模板名称或介绍");
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
            string tempFile = new string(word.Take(word.LastIndexOf('\\')).ToArray()) + @"\temp.png";
            await SaveImage(word, tempFile);
            TempletForJson templet = new TempletForJson() { TempletName = txtName.Text, TempletIntroduction = txtIntroduction.Text, TokenValue = FormFactory.JWTToken.TokenValue, StateCode = StateCode.request };
            switch (cmbUploadType.Text)
            {
                case "公共模板": templet.Accessibility = Model.Accessibility.Public; break;
                case "私有模板": templet.Accessibility = Model.Accessibility.Private; break;
                case "组织模板": templet.Accessibility = Model.Accessibility.Protected; break;
                default: MessageBox.Show("模板类型信息不正确"); await FileHelper.DeleteAbsolute(tempFile); return;
            }
            StateMessage state = await WebHelper.UploadFile<StateMessage>(FormFactory.userMsg.IPAddress + "/JsonAPI/UploadWord", templet, new string[] { word, tempFile });
            await FileHelper.DeleteAbsolute(tempFile);
            MessageBox.Show(state.StateDescription);
        }

        private async static Task SaveImage(string word, string tempFile)
        {
            await Task.Run(() =>
            {
                using (FileStream stream = new FileStream(word, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    Aspose.Words.Document doc = new Aspose.Words.Document(stream);
                    doc.Save(tempFile, Aspose.Words.SaveFormat.Png);
                }
                return tempFile;
            });
        }

    }
}
