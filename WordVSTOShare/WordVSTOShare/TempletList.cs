using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WordVSTOShare.Model;
using WordVSTOShare.util;
using Word = Microsoft.Office.Interop.Word;
using Microsoft.Office.Tools;

namespace WordVSTOShare
{
    public partial class TempletList : Form
    {

        private string tmpType;
        private string tmpAccess;
        private List<TempletForJson> templets;
        private ScreenResultModel screen;

        public TempletList(string type, string access)
        {
            InitializeComponent();
            switch (type)
            {
                case "音频": tmpType = "AudioTemplet"; break;
                case "视频": tmpType = "VideoTemplet"; break;
                case "图片": tmpType = "ImageTemplet"; break;
                default: tmpType = "WordTemplet"; break;
            }
            switch (access)
            {
                case "私有模板": tmpAccess = "Private"; break;
                case "组织模板": tmpAccess = "Protected"; break;
                default: tmpAccess = "Public"; break;
            }
        }

        private async void TempletList_Load(object sender, EventArgs e)
        {
            if (!Enum.TryParse(tmpType, out TempletType type))
            {
                MessageBox.Show("模板类型不正确");
                Close();
                return;
            }
            if (!Enum.TryParse(tmpAccess, out Model.Accessibility access))
            {
                MessageBox.Show("模板权限信息不正确");
                Close();
                return;
            }
            screen = new ScreenResultModel() { TokenValue = FormFactory.JWTToken.TokenValue, TempletType = type, Accessable = access, PageIndex = 1, StateCode = StateCode.request };
            await FullList(screen);
        }

        private void lstTemp_Click(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = FormFactory.userMsg.IPAddress + templets[lstTemp.SelectedIndex].ImagePath;
        }

        private async void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int typeNum = cmbType.SelectedIndex == 0 ? 0 : cmbType.SelectedIndex + 2;
            if (screen != null)
                screen.TempletType = (TempletType)typeNum;
            await FullList(screen);
        }

        private async void cmbAccess_SelectedIndexChanged(object sender, EventArgs e)
        {
            int accessNum = cmbType.SelectedIndex;
            if (screen != null)
                screen.Accessable = (Model.Accessibility)accessNum;
            await FullList(screen);
        }

        private async Task FullList(ScreenResultModel screen)
        {
            templets = await WebHelper.GetJson<ScreenResultModel, List<TempletForJson>>(screen, FormFactory.userMsg.IPAddress + "/JsonAPI/GetList");
            lstTemp.Invoke(new Action(() =>
            {
                lstTemp.Items.Clear();
                foreach (TempletForJson templet in templets)
                {
                    lstTemp.Items.Add(templet.TempletName);
                }
            }));
        }

        private async void lstTemp_DoubleClick(object sender, EventArgs e)
        {
            if (!Globals.ThisAddIn.Application.ActiveDocument.Saved)
            {
                var result = MessageBox.Show("保存当前文档？", "保存", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (!(result == DialogResult.OK))
                    return;
                Globals.ThisAddIn.Application.ActiveDocument.Save();
            }
            string word = Globals.ThisAddIn.Application.ActiveDocument.FullName;
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "请选择模板保存路径";
            sfd.InitialDirectory = new string(word.Take(word.LastIndexOf('\\')).ToArray());
            sfd.Filter = "Word文档|*.docx";
            sfd.ShowDialog();
            string tempFile = sfd.FileName;
            if (string.IsNullOrWhiteSpace(tempFile))
                return;
            await WebHelper.GetFile(FormFactory.userMsg.IPAddress + templets[lstTemp.SelectedIndex].FilePath, tempFile);
            Word.Application app = Globals.ThisAddIn.Application;
            app.Documents.Add(tempFile);
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            templets = await WebHelper.GetJson<ScreenResultModel, List<TempletForJson>>(screen, FormFactory.userMsg.IPAddress + "/JsonAPI/GetList");
            var temps = from templet in templets
                       where templet.TempletName.Contains(txtSearch.Text)
                       select templet;
            lstTemp.Invoke(new Action(() =>
            {
                lstTemp.Items.Clear();
                foreach (TempletForJson templet in temps)
                {
                    lstTemp.Items.Add(templet.TempletName);
                }
            }));
        }
    }
}
