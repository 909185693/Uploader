using System;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace Uploader
{
    public partial class Login : Form
    {
        /**
         * 构造函数
         */
        public Login()
        {
            InitializeComponent();

            InitData();
        }

        /**
         * 初始化数据
         */
        private void InitData()
        {
            UserNameTextBox.Text = Config.Base.UserName;
            PasswordTextBox.Text = Config.Base.Password;
        }

        /**
         * 点击登录
         */
        private void LoginButton_Click(object sender, EventArgs e)
        {
            string message = null;
            if (Option.Login(UserNameTextBox.Text, PasswordTextBox.Text, out message, RememberCheckBox.Checked))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(message);
            }
        }
    }
}
