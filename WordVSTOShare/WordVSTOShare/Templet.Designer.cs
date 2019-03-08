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
            this.cmbDownloadType = this.Factory.CreateRibbonComboBox();
            this.GrpUpdate = this.Factory.CreateRibbonGroup();
            this.txtName = this.Factory.CreateRibbonEditBox();
            this.txtIntroduction = this.Factory.CreateRibbonEditBox();
            this.cmbUploadType = this.Factory.CreateRibbonComboBox();
            this.btnUpload = this.Factory.CreateRibbonButton();
            this.GrpOther = this.Factory.CreateRibbonGroup();
            this.btnServerWeb = this.Factory.CreateRibbonButton();
            this.btnOfficalWeb = this.Factory.CreateRibbonButton();
            this.btnAbout = this.Factory.CreateRibbonButton();
            this.PrivateShare.SuspendLayout();
            this.GrpOption.SuspendLayout();
            this.GrpBroswer.SuspendLayout();
            this.GrpUpdate.SuspendLayout();
            this.GrpOther.SuspendLayout();
            this.SuspendLayout();
            // 
            // PrivateShare
            // 
            this.PrivateShare.Groups.Add(this.GrpOption);
            this.PrivateShare.Groups.Add(this.GrpBroswer);
            this.PrivateShare.Groups.Add(this.GrpUpdate);
            this.PrivateShare.Groups.Add(this.GrpOther);
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
            this.GrpBroswer.Items.Add(this.cmbDownloadType);
            this.GrpBroswer.Label = "浏览";
            this.GrpBroswer.Name = "GrpBroswer";
            this.GrpBroswer.DialogLauncherClick += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.GrpBroswer_DialogLauncherClick);
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
            this.btnSaveSetting.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnSaveSetting_Click);
            // 
            // cmbDownloadType
            // 
            ribbonDropDownItemImpl1.Label = "所有模板";
            ribbonDropDownItemImpl2.Label = "公共模板";
            ribbonDropDownItemImpl3.Label = "私有模板";
            ribbonDropDownItemImpl4.Label = "组织模板";
            this.cmbDownloadType.Items.Add(ribbonDropDownItemImpl1);
            this.cmbDownloadType.Items.Add(ribbonDropDownItemImpl2);
            this.cmbDownloadType.Items.Add(ribbonDropDownItemImpl3);
            this.cmbDownloadType.Items.Add(ribbonDropDownItemImpl4);
            this.cmbDownloadType.Label = "模板类型";
            this.cmbDownloadType.Name = "cmbDownloadType";
            // 
            // GrpUpdate
            // 
            this.GrpUpdate.Items.Add(this.txtName);
            this.GrpUpdate.Items.Add(this.txtIntroduction);
            this.GrpUpdate.Items.Add(this.cmbUploadType);
            this.GrpUpdate.Items.Add(this.btnUpload);
            this.GrpUpdate.Label = "上传";
            this.GrpUpdate.Name = "GrpUpdate";
            // 
            // txtName
            // 
            this.txtName.Label = "模板名称";
            this.txtName.Name = "txtName";
            // 
            // txtIntroduction
            // 
            this.txtIntroduction.Label = "模板简介";
            this.txtIntroduction.Name = "txtIntroduction";
            // 
            // cmbUploadType
            // 
            ribbonDropDownItemImpl5.Label = "所有模板";
            ribbonDropDownItemImpl6.Label = "公共模板";
            ribbonDropDownItemImpl7.Label = "私有模板";
            ribbonDropDownItemImpl8.Label = "组织模板";
            this.cmbUploadType.Items.Add(ribbonDropDownItemImpl5);
            this.cmbUploadType.Items.Add(ribbonDropDownItemImpl6);
            this.cmbUploadType.Items.Add(ribbonDropDownItemImpl7);
            this.cmbUploadType.Items.Add(ribbonDropDownItemImpl8);
            this.cmbUploadType.Label = "模板类型";
            this.cmbUploadType.Name = "cmbUploadType";
            // 
            // btnUpload
            // 
            this.btnUpload.Label = "上传模板";
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnUpload_Click);
            // 
            // GrpOther
            // 
            this.GrpOther.Items.Add(this.btnServerWeb);
            this.GrpOther.Items.Add(this.btnOfficalWeb);
            this.GrpOther.Items.Add(this.btnAbout);
            this.GrpOther.Label = "其它";
            this.GrpOther.Name = "GrpOther";
            // 
            // btnServerWeb
            // 
            this.btnServerWeb.Label = "访问服务器网站";
            this.btnServerWeb.Name = "btnServerWeb";
            this.btnServerWeb.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnServerWeb_Click);
            // 
            // btnOfficalWeb
            // 
            this.btnOfficalWeb.Label = "访问官方网站";
            this.btnOfficalWeb.Name = "btnOfficalWeb";
            this.btnOfficalWeb.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnOfficalWeb_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.Label = "关于";
            this.btnAbout.Name = "btnAbout";
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
            this.GrpOther.ResumeLayout(false);
            this.GrpOther.PerformLayout();
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
        internal Microsoft.Office.Tools.Ribbon.RibbonComboBox cmbDownloadType;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup GrpUpdate;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox txtName;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox txtIntroduction;
        internal Microsoft.Office.Tools.Ribbon.RibbonComboBox cmbUploadType;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnUpload;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup GrpOther;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnServerWeb;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnOfficalWeb;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnAbout;
    }

    partial class ThisRibbonCollection
    {
        internal Templet Templet
        {
            get { return this.GetRibbon<Templet>(); }
        }
    }
}
