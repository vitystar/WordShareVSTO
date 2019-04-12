﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Word = Microsoft.Office.Interop.Word;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Word;
using System.IO;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.AccessControl;

namespace WordVSTOShare
{
    public partial class ThisAddIn
    {

        public Word.Application app;

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            app = Globals.ThisAddIn.Application;
            FormFactory.MessagePath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+@"\wordTemplet\mymessage.wtp";

            InheritanceFlags flags = InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit;



            //FileInfo fileInfo = new FileInfo(FormFactory.MessagePath);
            //FileSecurity fileACL = fileInfo.GetAccessControl();
            //fileACL.AddAccessRule(new FileSystemAccessRule(Environment.UserName, FileSystemRights.FullControl, AccessControlType.Allow));
            //fileInfo.SetAccessControl(fileACL);
        }
        

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

        #region VSTO 生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
