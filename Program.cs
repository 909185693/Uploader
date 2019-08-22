using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Uploader
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            String ProcessName = System.Diagnostics.Process.GetCurrentProcess().ProcessName;
            System.Diagnostics.Process[] myProcesses = System.Diagnostics.Process.GetProcessesByName(ProcessName);
            if (myProcesses.Length > 1)
            {
                MessageBox.Show("程序已启动，请勿重复运行。");
            }
            else
            {
                try
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Uploader());
                }
                catch (Exception ex)
                {
                    var strDateInfo = "出现应用程序未处理的异常：" + DateTime.Now + "\r\n";
                    var message = string.Format(strDateInfo + "异常类型：{0}\r\n异常消息：{1}\r\n异常信息：{2}\r\n", ex.GetType().Name, ex.Message, ex.StackTrace);

                    Log.WriteLog(message);

                    throw ex;
                }
            }
        }
    }
}
