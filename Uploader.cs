using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Uploader
{
    public partial class Uploader : Form
    {
        private bool ActiveExit = false;

        public Uploader()
        {
            InitializeComponent();
            
            Option.InitScan();
            
            if (!String.IsNullOrEmpty(Config.Base.UserName) && !String.IsNullOrEmpty(Config.Base.Password))
            {
                string message = null;
                if (Option.Login(Config.Base.UserName, Config.Base.Password, out message))
                {
                    PrepareLabel.Text = "准备列表（帐号：" + Config.Base.UserName + "）";
                }
                else
                {
                    MessageBox.Show("自动" + message);
                }
            }
        }

        /**
         * 窗体计时器
         */
        private void Form_Tick(object sender, EventArgs e)
        {
            Option.ShareMutex.WaitOne();
            foreach (var item in PrepareListBox.Items)
            {
                int index = 0;
                var data = (KeyValuePair<string, string>)item;

                bool hasItem = false;
                foreach (var file in Option.PenddingFiles)
                {
                    if (file.Key == data.Key)
                    {
                        hasItem = true;
                    }
                }

                if (!hasItem)
                {
                    PrepareListBox.Items.RemoveAt(index);
                    break;
                }

                ++index;
            }

            foreach (var file in Option.PenddingFiles)
            {
                int index = 0;
                bool hasItem = false;
                bool valueChanged = false;
                
                foreach (var item in PrepareListBox.Items)
                {
                    var data = (KeyValuePair<string, string>)item;
                    if (data.Key == file.Key) 
                    {
                        hasItem = true;
                        if (data.Value != file.Value)
                        {
                            valueChanged = true;
                        }
                        break;
                    }

                    ++index;
                }

                if (!hasItem)
                {
                    PrepareListBox.Items.Add(file);
                }
                else if (valueChanged)
                {
                    PrepareListBox.Items.RemoveAt(index);
                    PrepareListBox.Items.Insert(index, file);
                }
            }

            foreach (var item in SuccessListBox.Items)
            {
                int index = 0;
                var data = (KeyValuePair<string, string>)item;

                bool hasItem = false;
                foreach (var file in Option.SuccessFiles)
                {
                    if (file.Key == data.Key)
                    {
                        hasItem = true;
                    }
                }

                if (!hasItem)
                {
                    SuccessListBox.Items.RemoveAt(index);
                    break;
                }

                ++index;
            }

            foreach (var file in Option.SuccessFiles)
            {
                foreach (var item in PrepareListBox.Items)
                {
                    var data = (KeyValuePair<string, string>)item;
                    if (data.Key == file.Key)
                    {
                        PrepareListBox.Items.Remove(item);
                        break;
                    }
                }

                int index = 0;
                bool hasItem = false;
                bool valueChanged = false;

                foreach (var item in SuccessListBox.Items)
                {
                    var data = (KeyValuePair<string, string>)item;
                    if (data.Key == file.Key)
                    {
                        hasItem = true;
                        if (data.Value != file.Value)
                        {
                            valueChanged = true;
                        }
                        break;
                    }

                    ++index;
                }

                if (!hasItem)
                {
                    SuccessListBox.Items.Add(file);
                }
                else if (valueChanged)
                {
                    SuccessListBox.Items.RemoveAt(index);
                    SuccessListBox.Items.Insert(index, file);
                }
            }

            Option.ShareMutex.ReleaseMutex();
        }

        /**
         * 打开设置窗口
         */
        private void SettingStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings newForm = new Settings();
            newForm.ShowDialog();
        }

        /**
         * 登录
         */
        private void LoginStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Option.UserInfo == null)
            {
                Login newForm = new Login();
                if (newForm.ShowDialog() == DialogResult.OK)
                {
                    PrepareLabel.Text = "准备列表（帐号：" + Config.Base.UserName + "）";
                }
            }
            else
            {
                MessageBox.Show("请先注销当前账户！");
            }
        }

        /**
         * 注销登录
         */
        private void LogoutStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Option.UserInfo != null)
            {
                Option.UserInfo = null;

                PrepareLabel.Text = "准备列表（未登录）";

                Option.AutoStart(false);

                MessageBox.Show("注销成功！");
            }
            else
            {
                MessageBox.Show("请先登录账户！");
            }
        }

        /**
         * 退出程序
         */
        private void ExitStripMenuItem_Click(object sender, EventArgs e)
        {
            ActiveExit = true;

            this.Close();
        }

        /**
         * 退出回调
         */
        private void Uploader_FormClosed(object sender, FormClosedEventArgs e)
        {
            // 终止扫描线程
            Option.RunScanThread = false;
        }

        /**
         * Form关闭事件
         */
        private void Uploader_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ActiveExit)
            {
                e.Cancel = true;

                this.WindowState = FormWindowState.Minimized;
            }
        }

        /**
         * 窗体大小改变事件
         */
        private void Uploader_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                ShowInTaskbar = false;
                NotifyIcon.Visible = true;
            }
            else
            {
                ShowInTaskbar = true;
                NotifyIcon.Visible = false;
            }
        }

        /**
         * 双击托盘显示
         */
        private void NotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            WindowState = FormWindowState.Normal;
        }
    }
}
