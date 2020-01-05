namespace Uploader
{
    partial class Settings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.SaveButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.ServerAddress = new System.Windows.Forms.Label();
            this.ScannLable = new System.Windows.Forms.Label();
            this.ServerAddressTextBox = new System.Windows.Forms.TextBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.ScanFolderListBox = new System.Windows.Forms.ListBox();
            this.FileFormatLable = new System.Windows.Forms.Label();
            this.FileFormatListBox = new System.Windows.Forms.ListBox();
            this.AddFileFormatButton = new System.Windows.Forms.Button();
            this.RemoveFileFormatButton = new System.Windows.Forms.Button();
            this.CompressSizeLabel = new System.Windows.Forms.Label();
            this.CompressSizeTextBox = new System.Windows.Forms.TextBox();
            this.CompressSizeUniTlabel = new System.Windows.Forms.Label();
            this.CompressQualityLabel = new System.Windows.Forms.Label();
            this.CompressQualityTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.Location = new System.Drawing.Point(236, 317);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 0;
            this.SaveButton.Text = "保存";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ExitButton.Location = new System.Drawing.Point(317, 317);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(75, 23);
            this.ExitButton.TabIndex = 0;
            this.ExitButton.Text = "退出";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // ServerAddress
            // 
            this.ServerAddress.AutoSize = true;
            this.ServerAddress.Location = new System.Drawing.Point(14, 16);
            this.ServerAddress.Name = "ServerAddress";
            this.ServerAddress.Size = new System.Drawing.Size(77, 12);
            this.ServerAddress.TabIndex = 1;
            this.ServerAddress.Text = "服务器地址：";
            // 
            // ScannLable
            // 
            this.ScannLable.AutoSize = true;
            this.ScannLable.Location = new System.Drawing.Point(14, 49);
            this.ScannLable.Name = "ScannLable";
            this.ScannLable.Size = new System.Drawing.Size(65, 12);
            this.ScannLable.TabIndex = 1;
            this.ScannLable.Text = "扫描路径：";
            // 
            // ServerAddressTextBox
            // 
            this.ServerAddressTextBox.Location = new System.Drawing.Point(97, 13);
            this.ServerAddressTextBox.Name = "ServerAddressTextBox";
            this.ServerAddressTextBox.Size = new System.Drawing.Size(295, 21);
            this.ServerAddressTextBox.TabIndex = 2;
            this.ServerAddressTextBox.TextChanged += new System.EventHandler(this.ServerAddressTextBox_TextChanged);
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(317, 44);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(75, 23);
            this.AddButton.TabIndex = 4;
            this.AddButton.Text = "添加";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddScanFolderButton_Click);
            // 
            // RemoveButton
            // 
            this.RemoveButton.Location = new System.Drawing.Point(318, 74);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(75, 23);
            this.RemoveButton.TabIndex = 5;
            this.RemoveButton.Text = "移除";
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveScanFolderButton_Click);
            // 
            // ScanFolderListBox
            // 
            this.ScanFolderListBox.FormattingEnabled = true;
            this.ScanFolderListBox.ItemHeight = 12;
            this.ScanFolderListBox.Location = new System.Drawing.Point(97, 44);
            this.ScanFolderListBox.Name = "ScanFolderListBox";
            this.ScanFolderListBox.Size = new System.Drawing.Size(214, 88);
            this.ScanFolderListBox.TabIndex = 6;
            this.ScanFolderListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ScanFolderListBox_MouseDoubleClick);
            // 
            // FileFormatLable
            // 
            this.FileFormatLable.AutoSize = true;
            this.FileFormatLable.Location = new System.Drawing.Point(16, 143);
            this.FileFormatLable.Name = "FileFormatLable";
            this.FileFormatLable.Size = new System.Drawing.Size(65, 12);
            this.FileFormatLable.TabIndex = 7;
            this.FileFormatLable.Text = "文件类型：";
            // 
            // FileFormatListBox
            // 
            this.FileFormatListBox.FormattingEnabled = true;
            this.FileFormatListBox.ItemHeight = 12;
            this.FileFormatListBox.Location = new System.Drawing.Point(97, 143);
            this.FileFormatListBox.Name = "FileFormatListBox";
            this.FileFormatListBox.Size = new System.Drawing.Size(214, 88);
            this.FileFormatListBox.TabIndex = 8;
            this.FileFormatListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.FileFormatListBox_MouseDoubleClick);
            // 
            // AddFileFormatButton
            // 
            this.AddFileFormatButton.Location = new System.Drawing.Point(317, 142);
            this.AddFileFormatButton.Name = "AddFileFormatButton";
            this.AddFileFormatButton.Size = new System.Drawing.Size(75, 23);
            this.AddFileFormatButton.TabIndex = 4;
            this.AddFileFormatButton.Text = "添加";
            this.AddFileFormatButton.UseVisualStyleBackColor = true;
            this.AddFileFormatButton.Click += new System.EventHandler(this.AddFileFormatButton_Click);
            // 
            // RemoveFileFormatButton
            // 
            this.RemoveFileFormatButton.Location = new System.Drawing.Point(318, 172);
            this.RemoveFileFormatButton.Name = "RemoveFileFormatButton";
            this.RemoveFileFormatButton.Size = new System.Drawing.Size(75, 23);
            this.RemoveFileFormatButton.TabIndex = 5;
            this.RemoveFileFormatButton.Text = "移除";
            this.RemoveFileFormatButton.UseVisualStyleBackColor = true;
            this.RemoveFileFormatButton.Click += new System.EventHandler(this.RemoveFileFormatButton_Click);
            // 
            // CompressSizeLabel
            // 
            this.CompressSizeLabel.AutoSize = true;
            this.CompressSizeLabel.Location = new System.Drawing.Point(16, 245);
            this.CompressSizeLabel.Name = "CompressSizeLabel";
            this.CompressSizeLabel.Size = new System.Drawing.Size(65, 12);
            this.CompressSizeLabel.TabIndex = 9;
            this.CompressSizeLabel.Text = "压缩限制：";
            // 
            // CompressSizeTextBox
            // 
            this.CompressSizeTextBox.Location = new System.Drawing.Point(97, 242);
            this.CompressSizeTextBox.Name = "CompressSizeTextBox";
            this.CompressSizeTextBox.Size = new System.Drawing.Size(100, 21);
            this.CompressSizeTextBox.TabIndex = 10;
            this.CompressSizeTextBox.TextChanged += new System.EventHandler(this.CompressSizeTextBox_TextChanged);
            // 
            // CompressSizeUniTlabel
            // 
            this.CompressSizeUniTlabel.AutoSize = true;
            this.CompressSizeUniTlabel.Location = new System.Drawing.Point(203, 245);
            this.CompressSizeUniTlabel.Name = "CompressSizeUniTlabel";
            this.CompressSizeUniTlabel.Size = new System.Drawing.Size(17, 12);
            this.CompressSizeUniTlabel.TabIndex = 9;
            this.CompressSizeUniTlabel.Text = "KB";
            // 
            // CompressQualityLabel
            // 
            this.CompressQualityLabel.AutoSize = true;
            this.CompressQualityLabel.Location = new System.Drawing.Point(16, 281);
            this.CompressQualityLabel.Name = "CompressQualityLabel";
            this.CompressQualityLabel.Size = new System.Drawing.Size(65, 12);
            this.CompressQualityLabel.TabIndex = 9;
            this.CompressQualityLabel.Text = "压缩质量：";
            // 
            // CompressQualityTextBox
            // 
            this.CompressQualityTextBox.Location = new System.Drawing.Point(97, 278);
            this.CompressQualityTextBox.Name = "CompressQualityTextBox";
            this.CompressQualityTextBox.Size = new System.Drawing.Size(100, 21);
            this.CompressQualityTextBox.TabIndex = 10;
            this.CompressQualityTextBox.TextChanged += new System.EventHandler(this.CompressQualityTextBox_TextChanged);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 352);
            this.Controls.Add(this.CompressQualityTextBox);
            this.Controls.Add(this.CompressSizeTextBox);
            this.Controls.Add(this.CompressQualityLabel);
            this.Controls.Add(this.CompressSizeUniTlabel);
            this.Controls.Add(this.CompressSizeLabel);
            this.Controls.Add(this.FileFormatListBox);
            this.Controls.Add(this.FileFormatLable);
            this.Controls.Add(this.ScanFolderListBox);
            this.Controls.Add(this.RemoveFileFormatButton);
            this.Controls.Add(this.AddFileFormatButton);
            this.Controls.Add(this.RemoveButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.ServerAddressTextBox);
            this.Controls.Add(this.ScannLable);
            this.Controls.Add(this.ServerAddress);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.SaveButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "设置";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Label ServerAddress;
        private System.Windows.Forms.Label ScannLable;
        private System.Windows.Forms.TextBox ServerAddressTextBox;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.ListBox ScanFolderListBox;
        private System.Windows.Forms.Label FileFormatLable;
        public System.Windows.Forms.ListBox FileFormatListBox;
        private System.Windows.Forms.Button AddFileFormatButton;
        private System.Windows.Forms.Button RemoveFileFormatButton;
        private System.Windows.Forms.Label CompressSizeLabel;
        private System.Windows.Forms.TextBox CompressSizeTextBox;
        private System.Windows.Forms.Label CompressSizeUniTlabel;
        private System.Windows.Forms.Label CompressQualityLabel;
        private System.Windows.Forms.TextBox CompressQualityTextBox;
    }
}