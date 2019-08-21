using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uploader
{
    public class Log
    {
        public static void WriteLog(string message)
        {
            string filename = String.Format("Log/Log_{0}.txt", DateTime.Now.ToString("yyyyMMdd"));
            FileHelper.WriteStringInFile(System.AppDomain.CurrentDomain.BaseDirectory + filename, message, Encoding.UTF8, true);
        }

        public static void WriteRecord(string message)
        {
            string filename = String.Format("Record/Record_{0}.txt", DateTime.Now.ToString("yyyyMMdd"));
            FileHelper.WriteStringInFile(System.AppDomain.CurrentDomain.BaseDirectory + filename, message, Encoding.UTF8, true);
        }
    }
}
