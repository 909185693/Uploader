using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uploader
{
    public class JsonHelper
    {
        #region JSON 反序列化
        /// <summary>
        /// JSON 反序列化
        /// </summary>
        public static T GetModelFromJson<T>(string json) where T : class
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
        #endregion

        #region 序列化JSON字符串
        public static string GetJsonFromModel(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
        #endregion

        #region 格式化Json字符串
        /// <summary>
        /// 格式化Json字符串
        /// </summary>
        public static string FormatJsonString(string json)
        {
            JsonSerializer serializer = new JsonSerializer();
            TextReader tr = new StringReader(json);
            JsonTextReader jtr = new JsonTextReader(tr);
            object obj = serializer.Deserialize(jtr);

            if (obj != null)
            {
                StringWriter textWriter = new StringWriter();
                JsonTextWriter jsonWriter = new JsonTextWriter(textWriter)
                {
                    Formatting = Formatting.Indented,
                    Indentation = 4,
                    IndentChar = ' '
                };
                serializer.Serialize(jsonWriter, obj);
                return textWriter.ToString();
            }

            return json;
        }

        #endregion

        #region 格式化Json字符串
        /// <summary>
        /// 格式化Json字符串
        /// </summary>
        public static string FormatJsonString(object obj)
        {
            JsonSerializer serializer = new JsonSerializer();
            StringWriter textWriter = new StringWriter();

            JsonTextWriter jsonWriter = new JsonTextWriter(textWriter)
            {
                Formatting = Formatting.Indented,
                Indentation = 4,
                IndentChar = ' '
            };

            serializer.Serialize(jsonWriter, obj);

            return textWriter.ToString();
        }
        #endregion

        #region  Json字符串转字典
        /// <summary>
        /// Json字符串转字典
        /// </summary>
        public static object ConvertJsonDictionary(object jObj)
        {
            if (jObj.GetType().Equals(typeof(JArray)))
            {
                List<object> list = new List<object>();

                foreach (var item in jObj as JArray)
                {
                    if (item.GetType().Equals(typeof(JArray)))
                    {
                        ConvertJsonDictionary(item);
                    }
                    else if (item.GetType().Equals(typeof(JValue)))
                    {
                        return jObj;
                    }
                    else
                    {
                        Dictionary<string, object> dic = new Dictionary<string, object>();

                        foreach (var obj in item as JObject)
                        {
                            dic.Add(obj.Key, obj.Value);
                        }

                        list.Add(dic);
                    }
                }

                return list;
            }
            else if (jObj.GetType().Equals(typeof(JObject)))
            {
                Dictionary<string, object> dic = new Dictionary<string, object>();

                foreach (var obj in jObj as JObject)
                {
                    dic.Add(obj.Key, obj.Value);
                }

                return dic;
            }

            return null;
        }
        #endregion

        #region 写入Json文件
        public static void WriteJsonFromObject(object obj, string path, Encoding encoding)
        {
            try
            {
                string json = FormatJsonString(obj);
                FileHelper.WriteStringInFile(path, json, encoding);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion
    }
}
