using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Uploader
{
    public partial class FileFormatDialog : Form
    {
        public string ReturnValue = null;

        public FileFormatDialog()
        {
            InitializeComponent();
        }

        public void SetValue(string newValue)
        {
            ReturnValue = newValue;

            FileFormatTextBox.Text = newValue;
        }

        /**
         * 确定
         */
        private void DefineButton_Click(object sender, EventArgs e)
        {
            ReturnValue = FileFormatTextBox.Text;
            
            this.Close();
        }

        /**
         * 取消
         */
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
