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
    public partial class Settings : Form
    {
        private bool bIsModify = false;

        public Settings()
        {
            InitializeComponent();

            InitData();
        }

        /**
         * 初始化数据
         */
        public void InitData()
        {
            ServerAddressTextBox.Text = Config.Base.ServerAddress;

            Option.ShareMutex.WaitOne();
            foreach (var item in Config.Base.ScannDirectorys)
            {
                ScanFolderListBox.Items.Add(item);
            }
            Option.ShareMutex.ReleaseMutex();

            foreach (var item in Config.Base.FileFormats)
            {
                FileFormatListBox.Items.Add(item);
            }

            CompressSizeTextBox.Text = Config.Base.CompressSize.ToString();

            CompressQualityTextBox.Text = Config.Base.CompressQuality.ToString();

            bIsModify = false;
        }

        /**
         * 服务器地址改变
         */
        private void ServerAddressTextBox_TextChanged(object sender, EventArgs e)
        {
            bIsModify = true;
        }

        /**
         * 添加扫描路径
         */
        private void AddScanFolderButton_Click(object sender, EventArgs e)
        {
            ShowScanFolderDialog();
        }
        
        /**
         * 编辑搜索文件夹
         */
        private void ScanFolderListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowScanFolderDialog(ScanFolderListBox.SelectedIndex);
        }

        /**
         * 显示选择搜索文件夹
         */
        private void ShowScanFolderDialog(int index = System.Windows.Forms.ListBox.NoMatches)
        {
            FolderBrowserDialog browserDialog = new FolderBrowserDialog();
            browserDialog.Description = "请选择文件路径";
            if (browserDialog.ShowDialog() == DialogResult.OK)
            {
                if (index == System.Windows.Forms.ListBox.NoMatches)
                {
                    ScanFolderListBox.Items.Add(browserDialog.SelectedPath);                    
                }
                else
                {
                    ScanFolderListBox.Items.RemoveAt(index);
                    ScanFolderListBox.Items.Insert(index, browserDialog.SelectedPath);
                }                

                bIsModify = true;
            }
        }

        /**
         * 移除扫描路径
         */
        private void RemoveScanFolderButton_Click(object sender, EventArgs e)
        {
            if (ScanFolderListBox.SelectedItem != null)
            {
                bIsModify = true;

                ScanFolderListBox.Items.Remove(ScanFolderListBox.SelectedItem);
            }
        }

        /**
         * 添加文件类型
         */
        private void AddFileFormatButton_Click(object sender, EventArgs e)
        {
            if ((string)FileFormatListBox.SelectedItem != String.Empty)
            {
                int index = FileFormatListBox.Items.Add(String.Empty);

                FileFormatListBox.SelectedIndex = index;

                ShowFileFormatDialog(index);
            }
        }

        /**
         * 编辑文件类型值
         */
        private void FileFormatListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = FileFormatListBox.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                ShowFileFormatDialog(index);
            }
        }

        /**
         * 显示编辑对话框
         */
        private void ShowFileFormatDialog(int index)
        {
            FileFormatDialog newForm = new FileFormatDialog();
            newForm.SetValue((string)FileFormatListBox.Items[index]);
            newForm.ShowDialog();
            FileFormatListBox.Items.RemoveAt(index);
            if (!String.IsNullOrEmpty(newForm.ReturnValue))
            {
                FileFormatListBox.Items.Insert(index, newForm.ReturnValue);
            }

            bIsModify = true;
        }

        /**
         * 移除文件类型
         */
        private void RemoveFileFormatButton_Click(object sender, EventArgs e)
        {
            if (FileFormatListBox.SelectedItem != null)
            {
                bIsModify = true;

                FileFormatListBox.Items.Remove(FileFormatListBox.SelectedItem);
            }
        }

        /**
         * 压缩大小修改
         */
        private void CompressSizeTextBox_TextChanged(object sender, EventArgs e)
        {
            bIsModify = true;
        }

        /**
         * 压缩质量修改
         */
        private void CompressQualityTextBox_TextChanged(object sender, EventArgs e)
        {
            bIsModify = true;
        }

        /**
         * 保存配置
         */
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (bIsModify)
            {
                bIsModify = false;

                try
                {
                    Config.Base.ServerAddress = ServerAddressTextBox.Text;

                    Option.ShareMutex.WaitOne();
                    Config.Base.ScannDirectorys.Clear();
                    foreach (var item in ScanFolderListBox.Items)
                    {
                        Config.Base.ScannDirectorys.Add(item.ToString());
                    }
                    Option.ShareMutex.ReleaseMutex();

                    Config.Base.FileFormats.Clear();
                    foreach (var item in FileFormatListBox.Items)
                    {
                        Config.Base.FileFormats.Add(item.ToString());
                    }

                    try
                    {
                        Config.Base.CompressSize = Convert.ToInt32(CompressSizeTextBox.Text);
                    }
                    catch
                    {
                        MessageBox.Show("压缩限制只能填写数字");
                        return;
                    }

                    if (Config.Base.CompressSize < 128)
                    {
                        MessageBox.Show("压缩限制不能小于128KB");
                        return;
                    }

                    try
                    {
                        Config.Base.CompressQuality = Convert.ToInt32(CompressQualityTextBox.Text);
                    }
                    catch
                    {
                        MessageBox.Show("压缩质量只能填写数字");
                        return;
                    }

                    if (Config.Base.CompressQuality < 1 || Config.Base.CompressQuality > 99)
                    {
                        MessageBox.Show("压缩质量只能介于1-99之间");
                    }

                    Config.Save();
                    
                    Option.InitScan();

                    MessageBox.Show("保存成功");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("保存失败：" + ex.Message);
                }
            }
        }

        /**
         * 退出设置
         */
        private void ExitButton_Click(object sender, EventArgs e)
        {
            if (bIsModify)
            {
                DialogResult result = MessageBox.Show("配置文件已经变更，确定要放弃保存", "退出", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    this.Close();
                }
                else
                {
                    return;
                }
            }
            else
            {
                this.Close();
            }
        }
    }
}
