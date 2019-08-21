using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Uploader
{
    public class FileHelper
    {
        #region 读取文件字符串
        /// <summary>
        /// 读取文件字符串
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns>内容字符串</returns>
        public static string ReadStringFromFile(string path)
        {
            if (!File.Exists(path))
            {
                throw new Exception(String.Format("文件不存在：{0}", path));
            }

            try
            {
                StringBuilder result = new StringBuilder();
                StreamReader streamReader = new StreamReader(path, Encoding.Default);

                string temp;

                while ((temp = streamReader.ReadLine()) != null)
                {
                    result.Append(temp);
                }

                streamReader.Close();

                return result.ToString();
            }
            catch
            {
                return String.Empty;
            }
        }
        #endregion

        #region 读取文件字符串
        /// <summary>
        /// 读取文件字符串
        /// </summary>
        /// <param name="path">文件流</param>
        /// <returns>内容字符串</returns>
        public static string ReadStringFromStream(Stream stream)
        {
            try
            {
                StringBuilder result = new StringBuilder();
                StreamReader streamReader = new StreamReader(stream, Encoding.GetEncoding("GB2312"));

                string temp;

                while ((temp = streamReader.ReadLine()) != null)
                {
                    result.Append(temp);
                }

                streamReader.Close();

                return result.ToString();
            }
            catch
            {
                return String.Empty;
            }
        }
        #endregion

        #region 写入文件
        /// <summary>
        /// 写入文件
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <param name="str">写入字符串</param>
        /// <param name="isAdd">是否追加到结尾</param>
        static public void WriteStringInFile(string path, string str, Encoding encoding, bool isAdd = false)
        {
            try
            {
                if (!Directory.Exists(Directory.GetParent(path).FullName))
                {
                    Directory.CreateDirectory(Directory.GetParent(path).FullName);
                }

                using (StreamWriter sw = new StreamWriter(path, isAdd, encoding))
                {

                    //str = str.Replace(@"\\", @"\");
                    sw.WriteLine(@str);
                    sw.Flush();
                    sw.Close();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion
    }
}
