namespace Uploader
{
    partial class FileFormatDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileFormatDialog));
            this.FileFormatTextBox = new System.Windows.Forms.TextBox();
            this.DefineButton = new System.Windows.Forms.Button();
            this.CanceledButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FileFormatTextBox
            // 
            this.FileFormatTextBox.Location = new System.Drawing.Point(13, 13);
            this.FileFormatTextBox.Name = "FileFormatTextBox";
            this.FileFormatTextBox.Size = new System.Drawing.Size(199, 21);
            this.FileFormatTextBox.TabIndex = 0;
            // 
            // DefineButton
            // 
            this.DefineButton.Location = new System.Drawing.Point(13, 40);
            this.DefineButton.Name = "DefineButton";
            this.DefineButton.Size = new System.Drawing.Size(75, 23);
            this.DefineButton.TabIndex = 1;
            this.DefineButton.Text = "确定";
            this.DefineButton.UseVisualStyleBackColor = true;
            this.DefineButton.Click += new System.EventHandler(this.DefineButton_Click);
            // 
            // CanceledButton
            // 
            this.CanceledButton.Location = new System.Drawing.Point(137, 41);
            this.CanceledButton.Name = "CanceledButton";
            this.CanceledButton.Size = new System.Drawing.Size(75, 23);
            this.CanceledButton.TabIndex = 2;
            this.CanceledButton.Text = "取消";
            this.CanceledButton.UseVisualStyleBackColor = true;
            this.CanceledButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // FileFormatDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 73);
            this.Controls.Add(this.CanceledButton);
            this.Controls.Add(this.DefineButton);
            this.Controls.Add(this.FileFormatTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FileFormatDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "文件类型";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox FileFormatTextBox;
        private System.Windows.Forms.Button DefineButton;
        private System.Windows.Forms.Button CanceledButton;
    }
}