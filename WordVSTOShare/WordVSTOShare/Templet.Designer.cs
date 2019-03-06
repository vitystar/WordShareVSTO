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
            this.PrivateShare = this.Factory.CreateRibbonTab();
            this.GrpOption = this.Factory.CreateRibbonGroup();
            this.UserName = this.Factory.CreateRibbonEditBox();
            this.btnSubmit = this.Factory.CreateRibbonButton();
            this.GrpBroswer = this.Factory.CreateRibbonGroup();
            this.labelTmpName = this.Factory.CreateRibbonLabel();
            this.PassWord = this.Factory.CreateRibbonEditBox();
            this.PrivateShare.SuspendLayout();
            this.GrpOption.SuspendLayout();
            this.GrpBroswer.SuspendLayout();
            this.SuspendLayout();
            // 
            // PrivateShare
            // 
            this.PrivateShare.Groups.Add(this.GrpOption);
            this.PrivateShare.Groups.Add(this.GrpBroswer);
            this.PrivateShare.Label = "私有共享";
            this.PrivateShare.Name = "PrivateShare";
            // 
            // GrpOption
            // 
            this.GrpOption.Items.Add(this.UserName);
            this.GrpOption.Items.Add(this.PassWord);
            this.GrpOption.Items.Add(this.btnSubmit);
            this.GrpOption.Label = "设置";
            this.GrpOption.Name = "GrpOption";
            // 
            // UserName
            // 
            this.UserName.Label = "用户名";
            this.UserName.Name = "UserName";
            this.UserName.Text = null;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Label = "验证并使用";
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnSubmit_Click);
            // 
            // GrpBroswer
            // 
            ribbonDialogLauncherImpl1.SuperTip = "打开浏览窗口";
            this.GrpBroswer.DialogLauncher = ribbonDialogLauncherImpl1;
            this.GrpBroswer.Items.Add(this.labelTmpName);
            this.GrpBroswer.Label = "浏览";
            this.GrpBroswer.Name = "GrpBroswer";
            // 
            // labelTmpName
            // 
            this.labelTmpName.Label = " ";
            this.labelTmpName.Name = "labelTmpName";
            // 
            // PassWord
            // 
            this.PassWord.Label = "密码";
            this.PassWord.Name = "PassWord";
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
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab PrivateShare;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup GrpOption;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox UserName;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnSubmit;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup GrpBroswer;
        internal Microsoft.Office.Tools.Ribbon.RibbonLabel labelTmpName;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox PassWord;
    }

    partial class ThisRibbonCollection
    {
        internal Templet Templet
        {
            get { return this.GetRibbon<Templet>(); }
        }
    }
}
