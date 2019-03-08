namespace WordVSTOShare
{
    partial class Templet : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public Templet()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            Microsoft.Office.Tools.Ribbon.RibbonDialogLauncher ribbonDialogLauncherImpl1 = this.Factory.CreateRibbonDialogLauncher();
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItemImpl1 = this.Factory.CreateRibbonDropDownItem();
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItemImpl2 = this.Factory.CreateRibbonDropDownItem();
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItemImpl3 = this.Factory.CreateRibbonDropDownItem();
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItemImpl4 = this.Factory.CreateRibbonDropDownItem();
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItemImpl5 = this.Factory.CreateRibbonDropDownItem();
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItemImpl6 = this.Factory.CreateRibbonDropDownItem();
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItemImpl7 = this.Factory.CreateRibbonDropDownItem();
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItemImpl8 = this.Factory.CreateRibbonDropDownItem();
            this.PrivateShare = this.Factory.CreateRibbonTab();
            this.GrpOption = this.Factory.CreateRibbonGroup();
            this.UserName = this.Factory.CreateRibbonEditBox();
            this.PassWord = this.Factory.CreateRibbonEditBox();
            this.GrpBroswer = this.Factory.CreateRibbonGroup();
            this.labelTmpName = this.Factory.CreateRibbonLabel();
            this.IPAddr = this.Factory.CreateRibbonEditBox();
            this.btnSaveSetting = this.Factory.CreateRibbonButton();
            this.accessableChoose = this.Factory.CreateRibbonComboBox();
            this.GrpUpdate = this.Factory.CreateRibbonGroup();
            this.editBox1 = this.Factory.CreateRibbonEditBox();
            this.editBox2 = this.Factory.CreateRibbonEditBox();
            this.comboBox1 = this.Factory.CreateRibbonComboBox();
            this.button1 = this.Factory.CreateRibbonButton();
            this.PrivateShare.SuspendLayout();
            this.GrpOption.SuspendLayout();
            this.GrpBroswer.SuspendLayout();
            this.GrpUpdate.SuspendLayout();
            this.SuspendLayout();
            // 
            // PrivateShare
            // 
            this.PrivateShare.Groups.Add(this.GrpOption);
            this.PrivateShare.Groups.Add(this.GrpBroswer);
            this.PrivateShare.Groups.Add(this.GrpUpdate);
            this.PrivateShare.Label = "私有共享";
            this.PrivateShare.Name = "PrivateShare";
            // 
            // GrpOption
            // 
            this.GrpOption.Items.Add(this.UserName);
            this.GrpOption.Items.Add(this.PassWord);
            this.GrpOption.Items.Add(this.IPAddr);
            this.GrpOption.Items.Add(this.btnSaveSetting);
            this.GrpOption.Label = "设置";
            this.GrpOption.Name = "GrpOption";
            // 
            // UserName
            // 
            this.UserName.Label = "用户名";
            this.UserName.Name = "UserName";
            this.UserName.Text = null;
            // 
            // PassWord
            // 
            this.PassWord.Label = "密码";
            this.PassWord.Name = "PassWord";
            this.PassWord.Text = null;
            // 
            // GrpBroswer
            // 
            ribbonDialogLauncherImpl1.SuperTip = "打开浏览窗口";
            this.GrpBroswer.DialogLauncher = ribbonDialogLauncherImpl1;
            this.GrpBroswer.Items.Add(this.labelTmpName);
            this.GrpBroswer.Items.Add(this.accessableChoose);
            this.GrpBroswer.Label = "浏览";
            this.GrpBroswer.Name = "GrpBroswer";
            // 
            // labelTmpName
            // 
            this.labelTmpName.Label = " ";
            this.labelTmpName.Name = "labelTmpName";
            // 
            // IPAddr
            // 
            this.IPAddr.Label = "服务器地址";
            this.IPAddr.Name = "IPAddr";
            // 
            // btnSaveSetting
            // 
            this.btnSaveSetting.Label = "保存设置";
            this.btnSaveSetting.Name = "btnSaveSetting";
            // 
            // accessableChoose
            // 
            ribbonDropDownItemImpl1.Label = "所有模板";
            ribbonDropDownItemImpl2.Label = "公共模板";
            ribbonDropDownItemImpl3.Label = "私有模板";
            ribbonDropDownItemImpl4.Label = "组织模板";
            this.accessableChoose.Items.Add(ribbonDropDownItemImpl1);
            this.accessableChoose.Items.Add(ribbonDropDownItemImpl2);
            this.accessableChoose.Items.Add(ribbonDropDownItemImpl3);
            this.accessableChoose.Items.Add(ribbonDropDownItemImpl4);
            this.accessableChoose.Label = "模板类型";
            this.accessableChoose.Name = "accessableChoose";
            // 
            // GrpUpdate
            // 
            this.GrpUpdate.Items.Add(this.editBox1);
            this.GrpUpdate.Items.Add(this.editBox2);
            this.GrpUpdate.Items.Add(this.comboBox1);
            this.GrpUpdate.Items.Add(this.button1);
            this.GrpUpdate.Label = "group1";
            this.GrpUpdate.Name = "GrpUpdate";
            // 
            // editBox1
            // 
            this.editBox1.Label = "editBox1";
            this.editBox1.Name = "editBox1";
            // 
            // editBox2
            // 
            this.editBox2.Label = "editBox2";
            this.editBox2.Name = "editBox2";
            // 
            // comboBox1
            // 
            ribbonDropDownItemImpl5.Label = "所有模板";
            ribbonDropDownItemImpl6.Label = "公共模板";
            ribbonDropDownItemImpl7.Label = "私有模板";
            ribbonDropDownItemImpl8.Label = "组织模板";
            this.comboBox1.Items.Add(ribbonDropDownItemImpl5);
            this.comboBox1.Items.Add(ribbonDropDownItemImpl6);
            this.comboBox1.Items.Add(ribbonDropDownItemImpl7);
            this.comboBox1.Items.Add(ribbonDropDownItemImpl8);
            this.comboBox1.Label = "模板类型";
            this.comboBox1.Name = "comboBox1";
            // 
            // button1
            // 
            this.button1.Label = "button1";
            this.button1.Name = "button1";
            // 
            // Templet
            // 
            this.Name = "Templet";
            this.RibbonType = "Microsoft.Word.Document";
            this.Tabs.Add(this.PrivateShare);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Templet_Load);
            this.PrivateShare.ResumeLayout(false);
            this.PrivateShare.PerformLayout();
            this.GrpOption.ResumeLayout(false);
            this.GrpOption.PerformLayout();
            this.GrpBroswer.ResumeLayout(false);
            this.GrpBroswer.PerformLayout();
            this.GrpUpdate.ResumeLayout(false);
            this.GrpUpdate.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab PrivateShare;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup GrpOption;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox UserName;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup GrpBroswer;
        internal Microsoft.Office.Tools.Ribbon.RibbonLabel labelTmpName;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox PassWord;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox IPAddr;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnSaveSetting;
        internal Microsoft.Office.Tools.Ribbon.RibbonComboBox accessableChoose;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup GrpUpdate;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox editBox1;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox editBox2;
        internal Microsoft.Office.Tools.Ribbon.RibbonComboBox comboBox1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button1;
    }

    partial class ThisRibbonCollection
    {
        internal Templet Templet
        {
            get { return this.GetRibbon<Templet>(); }
        }
    }
}
