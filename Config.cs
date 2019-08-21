using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uploader
{
    public class Config
    {
        public static UploaderConfig Base = Loading();

        private const string Filename = "Uploader.config";

        private static UploaderConfig Loading()
        {
            try
            {
                string filec = FileHelper.ReadStringFromFile(System.AppDomain.CurrentDomain.BaseDirectory + Filename);
                Base = JsonHelper.GetModelFromJson<UploaderConfig>(filec);
            }
            catch
            {
                Base = new UploaderConfig();

                Save();
            }

            return Base;
        }

        public static void Save()
        {
            string json = JsonHelper.FormatJsonString(Base);

            FileHelper.WriteStringInFile(System.AppDomain.CurrentDomain.BaseDirectory + Filename, json, Encoding.UTF8);
        }
    }
}
