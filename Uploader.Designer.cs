namespace Uploader
{
    partial class Uploader
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Uploader));
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.FileStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoginStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LogoutStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelplStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PrepareLabel = new System.Windows.Forms.Label();
            this.PrepareListBox = new System.Windows.Forms.ListBox();
            this.SuccessLabel = new System.Windows.Forms.Label();
            this.SuccessListBox = new System.Windows.Forms.ListBox();
            this.FormTicker = new System.Windows.Forms.Timer(this.components);
            this.NotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.MenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileStripMenuItem,
            this.AboutStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(784, 25);
            this.MenuStrip.TabIndex = 0;
            this.MenuStrip.Text = "menuStrip1";
            // 
            // FileStripMenuItem
            // 
            this.FileStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LoginStripMenuItem,
            this.LogoutStripMenuItem,
            this.SettingStripMenuItem,
            this.ExitStripMenuItem});
            this.FileStripMenuItem.Name = "FileStripMenuItem";
            this.FileStripMenuItem.Size = new System.Drawing.Size(58, 21);
            this.FileStripMenuItem.Text = "文件(&F)";
            // 
            // LoginStripMenuItem
            // 
            this.LoginStripMenuItem.Name = "LoginStripMenuItem";
            this.LoginStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.LoginStripMenuItem.Text = "登录(&L)";
            this.LoginStripMenuItem.Click += new System.EventHandler(this.LoginStripMenuItem_Click);
            // 
            // LogoutStripMenuItem
            // 
            this.LogoutStripMenuItem.Name = "LogoutStripMenuItem";
            this.LogoutStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.LogoutStripMenuItem.Text = "注销(&O)";
            this.LogoutStripMenuItem.Click += new System.EventHandler(this.LogoutStripMenuItem_Click);
            // 
            // SettingStripMenuItem
            // 
            this.SettingStripMenuItem.Name = "SettingStripMenuItem";
            this.SettingStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.SettingStripMenuItem.Text = "设置(&S)";
            this.SettingStripMenuItem.Click += new System.EventHandler(this.SettingStripMenuItem_Click);
            // 
            // ExitStripMenuItem
            // 
            this.ExitStripMenuItem.Name = "ExitStripMenuItem";
            this.ExitStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.ExitStripMenuItem.Text = "退出(&E)";
            this.ExitStripMenuItem.Click += new System.EventHandler(this.ExitStripMenuItem_Click);
            // 
            // AboutStripMenuItem
            // 
            this.AboutStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HelplStripMenuItem});
            this.AboutStripMenuItem.Name = "AboutStripMenuItem";
            this.AboutStripMenuItem.Size = new System.Drawing.Size(60, 21);
            this.AboutStripMenuItem.Text = "关于(&A)";
            // 
            // HelplStripMenuItem
            // 
            this.HelplStripMenuItem.Name = "HelplStripMenuItem";
            this.HelplStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.HelplStripMenuItem.Text = "帮助(&H)";
            // 
            // PrepareLabel
            // 
            this.PrepareLabel.AutoSize = true;
            this.PrepareLabel.Location = new System.Drawing.Point(13, 29);
            this.PrepareLabel.Name = "PrepareLabel";
            this.PrepareLabel.Size = new System.Drawing.Size(101, 12);
            this.PrepareLabel.TabIndex = 1;
            this.PrepareLabel.Text = "准备列表(未登录)";
            // 
            // PrepareListBox
            // 
            this.PrepareListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PrepareListBox.FormattingEnabled = true;
            this.PrepareListBox.ItemHeight = 12;
            this.PrepareListBox.Location = new System.Drawing.Point(15, 45);
            this.PrepareListBox.Name = "PrepareListBox";
            this.PrepareListBox.Size = new System.Drawing.Size(757, 268);
            this.PrepareListBox.TabIndex = 2;
            // 
            // SuccessLabel
            // 
            this.SuccessLabel.AutoSize = true;
            this.SuccessLabel.Location = new System.Drawing.Point(13, 330);
            this.SuccessLabel.Name = "SuccessLabel";
            this.SuccessLabel.Size = new System.Drawing.Size(53, 12);
            this.SuccessLabel.TabIndex = 1;
            this.SuccessLabel.Text = "完成列表";
            // 
            // SuccessListBox
            // 
            this.SuccessListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SuccessListBox.FormattingEnabled = true;
            this.SuccessListBox.ItemHeight = 12;
            this.SuccessListBox.Location = new System.Drawing.Point(15, 345);
            this.SuccessListBox.Name = "SuccessListBox";
            this.SuccessListBox.Size = new System.Drawing.Size(757, 244);
            this.SuccessListBox.TabIndex = 2;
            // 
            // FormTicker
            // 
            this.FormTicker.Enabled = true;
            this.FormTicker.Tick += new System.EventHandler(this.Form_Tick);
            // 
            // NotifyIcon
            // 
            this.NotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("NotifyIcon.Icon")));
            this.NotifyIcon.Text = "照片自动上传";
            this.NotifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon_MouseDoubleClick);
            // 
            // Uploader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 601);
            this.Controls.Add(this.SuccessListBox);
            this.Controls.Add(this.PrepareListBox);
            this.Controls.Add(this.SuccessLabel);
            this.Controls.Add(this.PrepareLabel);
            this.Controls.Add(this.MenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuStrip;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Uploader";
            this.Text = "照片自动上传";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Uploader_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Uploader_FormClosed);
            this.SizeChanged += new System.EventHandler(this.Uploader_SizeChanged);
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem FileStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SettingStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HelplStripMenuItem;
        private System.Windows.Forms.Label PrepareLabel;
        private System.Windows.Forms.ListBox PrepareListBox;
        private System.Windows.Forms.Label SuccessLabel;
        private System.Windows.Forms.ListBox SuccessListBox;
        private System.Windows.Forms.Timer FormTicker;
        private System.Windows.Forms.ToolStripMenuItem LoginStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LogoutStripMenuItem;
        private System.Windows.Forms.NotifyIcon NotifyIcon;
    }
}

