using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uploader
{
    public class UploaderConfig
    {
        public UploaderConfig()
        {
            this.ServerAddress = String.Empty;
            this.UserName = String.Empty;
            this.Password = String.Empty;
            this.ScannDirectorys = new List<string>();
            this.FileFormats = new List<string>();
        }

        public string ServerAddress { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public List<string> ScannDirectorys { get; set; }

        public List<string> FileFormats { get; set; }
    }

    public class UploadInfo
    {
        public UploadInfo(string CurrentFile, string TempFile)
        {
            this.CurrentFile = CurrentFile;
            this.TempFile = TempFile;
            this.Error = 0;
        }

        /**
         * 当前目标文件
         */
        public string CurrentFile { get; set; }

        /**
         * 临时文件
         */
        public string TempFile { get; set; }

        /**
         * 错误次数
         */
        public int Error { get; set; }
    }

    public class UserInfo
    {
        public int user_id { get; set; }
    }

    public class LoginResponse
    {
        public int code { get; set; }

        public string msg { get; set; }

        public UserInfo data { get; set; }
    }

    public class UploadResponse
    {
        public int code { get; set; }
    }
}
