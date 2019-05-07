using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordVSTOShare
{
    public partial class TempletList : Form
    {

        private string tmpType;
        private string tmpAccess;

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
                case "所有模板": tmpAccess = "All"; break;
                case "私有模板": tmpAccess = "Private"; break;
                case "组织模板": tmpAccess = "Protected"; break;
                default: tmpAccess = "Public"; break;
            }
        }

        private void TempletList_Load(object sender, EventArgs e)
        {

        }
    }
}
