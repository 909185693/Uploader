using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;

namespace Uploader
{
    public class Option
    {
        /**
         * 扫描文件线程
         */
        public static Thread ScanThread = null;
        public static bool RunScanThread = true;

        /**
         * 当前登录的用户信息
         */
        public static UserInfo UserInfo = null;

        /**
         * Web客户端
         */
        private static WebClient UploadClient = null;

        /**
         * 当前正在上传文件信息
         */
        private static UploadInfo UploadInfo = null;

        /**
         * 线程互斥锁
         */
        public static Mutex ShareMutex = new Mutex();

        /**
         * 已扫描的文件
         */
        private static List<string> InternalScannedFiles = new List<string>();

        /**
         * 准备上传的文件
         */
        private static Dictionary<string, string> InternalPenddingFiles = new Dictionary<string, string>();
        public static Dictionary<string, string> PenddingFiles = new Dictionary<string, string>();

        /**
         * 成功列表
         */
        public static List<string> InternalSuccessList = new List<string>();
        private static Dictionary<string, string> InternalSuccessFiles = new Dictionary<string, string>();
        public static Dictionary<string, string> SuccessFiles = new Dictionary<string, string>();

        /**
         * 初始化扫描文件
         */
        public static void InitScan()
        {
            Option.ShareMutex.WaitOne();
            foreach (var item in Config.Base.ScannDirectorys)
            {
                ScanCatalogue(item);
            }

            PenddingFiles.Clear();
            InternalPenddingFiles.Clear();

            Option.ShareMutex.ReleaseMutex();

            if (Option.ScanThread == null)
            {
                Option.ScanThread = new Thread(ScanThreadMethod);
                Option.ScanThread.Start();
            }
        }

        /**
         * 扫描检查
         */
        private static void ScanThreadMethod()
        {
            while (RunScanThread)
            {
                Option.ShareMutex.WaitOne();
                var ScannDirectorys = new List<string>();
                foreach (var item in Config.Base.ScannDirectorys)
                {
                    ScannDirectorys.Add(item);
                }
                var ServerAddress = Config.Base.ServerAddress;
                Option.ShareMutex.ReleaseMutex();

                foreach (var item in ScannDirectorys)
                {
                    ScanCatalogue(item, true);
                }

                if (UserInfo != null && UploadClient == null && InternalPenddingFiles.Count > 0)
                {
                    // 更新上传信息
                    if (UploadInfo == null)
                    {
                        string currentFile = InternalPenddingFiles.First().Key;
                        string tempFile = currentFile;

                        try
                        {
                            // 图片压缩处理
                            if (File.Exists(currentFile))
                            {
                                FileInfo fileInfo = new FileInfo(currentFile);
                                if (fileInfo.Length / 1024.0 > 2048)
                                {
                                    int flag = (int)System.Math.Ceiling(2048.0 / (fileInfo.Length / 1024.0) * 100.0);

                                    string newPath = System.AppDomain.CurrentDomain.BaseDirectory + "Temp/" + DateTime.Now.ToString("yyyyMMddHHmmssffff") + Path.GetExtension(currentFile);
                                    if (!Directory.Exists(Directory.GetParent(newPath).FullName))
                                    {
                                        Directory.CreateDirectory(Directory.GetParent(newPath).FullName);
                                    }

                                    if (GetPicThumbnail(currentFile, newPath, flag))
                                    {
                                        tempFile = newPath;
                                    }
                                }
                            }
                        }
                        catch
                        {
                            Log.WriteRecord(currentFile + " | 图片压缩失败");
                        }

                        UploadInfo = new UploadInfo(currentFile, tempFile);
                    }

                    // 发起上传请求，监听进度和完成回调
                    if (File.Exists(UploadInfo.TempFile))
                    {
                        try
                        {
                            Uri uri = new Uri(ServerAddress + "/upload/scenic?scenic_id=&user_id=" + UserInfo.user_id);

                            UploadClient = new WebClient();
                            UploadClient.Credentials = CredentialCache.DefaultCredentials;
                            UploadClient.UploadFileAsync(uri, "POST", UploadInfo.TempFile);
                            UploadClient.UploadProgressChanged += new UploadProgressChangedEventHandler(OnUploadProgressChangedEventHandler);
                            UploadClient.UploadFileCompleted += new UploadFileCompletedEventHandler(OnUploadFileCompleted);
                        }
                        catch (Exception ex)
                        {
                            OnUploadCompleted(ex.Message, false);
                        }
                    }
                    else
                    {
                        OnUploadCompleted("上传失败，文件不存在", false);
                    }
                }

                Option.ShareMutex.WaitOne();
                PenddingFiles.Clear();
                foreach (var item in InternalPenddingFiles)
                {
                    PenddingFiles.Add(item.Key, item.Value);
                }
                SuccessFiles.Clear();
                while (InternalSuccessList.Count > 100)
                {
                    string key = InternalSuccessList[0];
                    InternalSuccessList.Remove(key);
                    InternalSuccessFiles.Remove(key);
                }

                foreach (var item in InternalSuccessFiles)
                {
                    SuccessFiles.Add(item.Key, item.Value);
                }
                Option.ShareMutex.ReleaseMutex();

                Thread.Sleep(1000);
            }
        }

        /**
         * 扫描目录
         */
        private static void ScanCatalogue(string catalogue, bool bCheckUpload = false)
        {
            if (Directory.Exists(catalogue))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(catalogue);

                // 保存搜索到的文件
                FileInfo[] files = directoryInfo.GetFiles();
                foreach (var file in files)
                {
                    if (!InternalScannedFiles.Contains(file.FullName) && TestFileFormat(file.Extension))
                    {
                        AddScanedFile(file.FullName, bCheckUpload);
                    }
                }

                // 递归子目录
                DirectoryInfo[] directoryInfos = directoryInfo.GetDirectories();
                foreach (var item in directoryInfos)
                {
                    ScanCatalogue(item.FullName, bCheckUpload);
                }
            }
        }

        /**
         * 检测文件格式
         */
        private static bool TestFileFormat(string format)
        {
            return Config.Base.FileFormats.Contains(format);
        }

        /**
         * 添加扫描文件
         */
        private static void AddScanedFile(string filename, bool bCheckUpload = false)
        {
            if (bCheckUpload && !InternalPenddingFiles.Keys.Contains(filename))
            {
                InternalPenddingFiles.Add(filename, "等待上传");
                return;
            }

            InternalScannedFiles.Add(filename);
        }

        /**
         * 上传文件进度
         */
        private static void OnUploadProgressChangedEventHandler(object sender, UploadProgressChangedEventArgs e)
        {
            if (UploadInfo != null)
            {
                Option.ShareMutex.WaitOne();
                string value = "正在上传 " + e.ProgressPercentage * 2 + "%";
                if (UploadInfo.Error > 0)
                {
                    value += "(重试第" + UploadInfo.Error + "次)";
                }
                InternalPenddingFiles.Remove(UploadInfo.CurrentFile);
                InternalPenddingFiles.Add(UploadInfo.CurrentFile, value);
                Option.ShareMutex.ReleaseMutex();
            }
        }

        /**
         * 请求上传完成
         */
        private static void OnUploadFileCompleted(object sender, UploadFileCompletedEventArgs e)
        {
            string message = " 上传失败:未知错误";
            if (e.Error != null)
            {
                ++UploadInfo.Error;

                message = " 上传失败:" + e.Error.Message + " Error(" + UploadInfo.Error + ")";
            }
            else if (e.Result != null)
            {
                try
                {
                    string data = System.Text.Encoding.UTF8.GetString(e.Result);

                    Console.WriteLine(data);

                    UploadResponse uploadResponse = JsonHelper.GetModelFromJson<UploadResponse>(data);
                    if (uploadResponse.code == 0)
                    {
                        UploadInfo.Error = 0;

                        message = "上传成功";
                    }
                    else
                    {
                        ++UploadInfo.Error;

                        message = "上传失败：code=" + uploadResponse.code;
                    }
                }
                catch (Exception ex)
                {
                    ++UploadInfo.Error;

                    message = "上传失败：" + ex.Message;
                }
            }
            else
            {
                ++UploadInfo.Error;
            }

            Option.ShareMutex.WaitOne();

            if (UploadInfo.Error == 0 || UploadInfo.Error >= 3)
            {
                OnUploadCompleted(message, UploadInfo.Error > 0);
            }

            Option.ShareMutex.ReleaseMutex();
        }

        /**
         * 任务完成
         */
        private static void OnUploadCompleted(string message, bool bSuccess)
        {
            InternalPenddingFiles.Remove(UploadInfo.CurrentFile);

            InternalScannedFiles.Add(UploadInfo.CurrentFile);
            InternalSuccessList.Add(UploadInfo.CurrentFile);
            InternalSuccessFiles.Add(UploadInfo.CurrentFile, message);

            // 创建失败记录
            if (!bSuccess)
            {
                Log.WriteRecord(UploadInfo.CurrentFile + " | " + message);
            }

            // 删除临时文件
            if (UploadInfo.CurrentFile != UploadInfo.TempFile && File.Exists(UploadInfo.TempFile))
            {
                File.Delete(UploadInfo.TempFile);
            }

            UploadInfo = null;

            UploadClient.Dispose();
            UploadClient = null;
        }

        /**
         * 用户登录
         */
        public static bool Login(string userName, string password, out string message, bool remember = true)
        {
            try
            {
                string url = Config.Base.ServerAddress + "/admin/user/login?username=" + userName + "&password=" + password;

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.AllowAutoRedirect = false;
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream myResponseStream = response.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myResponseStream, System.Text.Encoding.GetEncoding("utf-8"));
                string retString = myStreamReader.ReadToEnd();
                myStreamReader.Close();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    LoginResponse loginResponse = JsonHelper.GetModelFromJson<LoginResponse>(retString);
                    if (loginResponse != null && loginResponse.code == 1 && loginResponse.data != null)
                    {
                        Option.UserInfo = loginResponse.data;

                        Config.Base.UserName = userName;
                        if (remember)
                        {
                            Config.Base.Password = password;
                        }
                        else
                        {
                            Config.Base.Password = String.Empty;
                        }
                        Config.Save();

                        message = string.Empty;

                        AutoStart(true);

                        return true;
                    }
                    else
                    {
                        message = "登录失败:" + loginResponse.code;

                        AutoStart(false);

                        return false;
                    }
                }
                else
                {
                    message = "登录失败:" + response.StatusCode;

                    AutoStart(false);

                    return false;
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;

                AutoStart(false);

                return false;
            }
        }

        /**
         * 开机启动
         */
        public static void AutoStart(bool isAuto)
        {
            try
            {
                if (isAuto == true)
                {
                    RegistryKey R_local = Registry.CurrentUser;
                    RegistryKey R_run = R_local.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
                    R_run.SetValue("Uploader", "\"" + System.Windows.Forms.Application.ExecutablePath + "\" -s");
                    R_run.Close();
                    R_local.Close();

                    RegistryKey S_local = Registry.LocalMachine;
                    RegistryKey S_run = S_local.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
                    S_run.SetValue("Uploader", "\"" + System.Windows.Forms.Application.ExecutablePath + "\" -s");
                    S_run.Close();
                    S_local.Close();
                }
                else
                {
                    RegistryKey R_local = Registry.CurrentUser;
                    RegistryKey R_run = R_local.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
                    R_run.DeleteValue("Uploader", false);
                    R_run.Close();
                    R_local.Close();

                    RegistryKey S_local = Registry.LocalMachine;
                    RegistryKey S_run = S_local.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
                    S_run.DeleteValue("Uploader", false);
                    S_run.Close();
                    S_local.Close();
                }
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("没有权限开机启动，请以管理员身份运行程序。" + ex.Message);
            }
        }

        /**
         * 无损压缩图片
         */
        public static bool GetPicThumbnail(string sFile, string dFile, int flag)
        {
            System.Drawing.Image iSource = System.Drawing.Image.FromFile(sFile);
            ImageFormat tFormat = iSource.RawFormat;
            
            int sW = iSource.Width, sH = iSource.Height;
            int dWidth = (int)(sW * Math.Min(1.0, 2 * flag / 100.0));
            int dHeight = (int)(sH * Math.Min(1.0, 2 * flag / 100.0));

            //按比例缩放
            Size tem_size = new Size(iSource.Width, iSource.Height);
            if (tem_size.Width > dHeight || tem_size.Width > dWidth)
            {
                if ((tem_size.Width * dHeight) > (tem_size.Width * dWidth))
                {
                    sW = dWidth;
                    sH = (dWidth * tem_size.Height) / tem_size.Width;
                }
                else
                {
                    sH = dHeight;
                    sW = (tem_size.Width * dHeight) / tem_size.Height;
                }
            }
            else
            {
                sW = tem_size.Width;
                sH = tem_size.Height;
            }
            
            Bitmap ob = new Bitmap(dWidth, dHeight);
            Graphics g = Graphics.FromImage(ob);

            g.Clear(Color.WhiteSmoke);
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            g.DrawImage(iSource, new Rectangle((dWidth - sW) / 2, (dHeight - sH) / 2, sW, sH), 0, 0, iSource.Width, iSource.Height, GraphicsUnit.Pixel);
            g.Dispose();

            //以下代码为保存图片时，设置压缩质量  
            EncoderParameters ep = new EncoderParameters();
            long[] qy = new long[1];
            qy[0] = 100;//设置压缩的比例1-100  
            EncoderParameter eParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, qy);
            ep.Param[0] = eParam;
            try
            {
                ImageCodecInfo[] arrayICI = ImageCodecInfo.GetImageEncoders();
                ImageCodecInfo jpegICIinfo = null;
                for (int x = 0; x < arrayICI.Length; x++)
                {
                    if (arrayICI[x].FormatDescription.Equals("JPEG"))
                    {
                        jpegICIinfo = arrayICI[x];
                        break;
                    }
                }
                if (jpegICIinfo != null)
                {
                    ob.Save(dFile, jpegICIinfo, ep);//dFile是压缩后的新路径  
                }
                else
                {
                    ob.Save(dFile, tFormat);
                }
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                iSource.Dispose();
                ob.Dispose();
            }
        }
    }
}
