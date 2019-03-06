using System;
using System.Collections.Generic;
using System.Linq;
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

        }

        private void btnSubmit_Click(object sender, RibbonControlEventArgs e)
        {
            string ipaddr = UserName.Text;
            if (Regex.IsMatch(ipaddr.Trim(), @"(?=(\b|\D))(((\d{1,2})|(1\d{1,2})|(2[0-4]\d)|(25[0-5]))\.){3}((\d{1,2})|(1\d{1,2})|(2[0-4]\d)|(25[0-5]))(?=(\b|\D))"))
                MessageBox.Show("access");
            else
                MessageBox.Show("fail");
        }
    }
}
