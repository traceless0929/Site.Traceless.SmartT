using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace Traceless.TExtension.Tools
{
    public static class ToolClass
    {
        public static string Cookie = string.Empty;
        private static CompareInfo Compare = CultureInfo.InvariantCulture.CompareInfo;
        private static int GetRandomSeed()
        {
            byte[] bytes = new byte[4];
            System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            rng.GetBytes(bytes);
            return BitConverter.ToInt32(bytes, 0);
        }

        public static int RandomGet(int min, int max)
        {
            long tick = DateTime.Now.Millisecond;
            Random rd = new Random(GetRandomSeed());
            int r = rd.Next(min, max);
            return r;
        }

        public static string[] GetIni(string path)
        {
            if (!File.Exists(path)) return null;
            Encoding encoding = Encoding.GetEncoding("GB2312");
            return File.ReadAllLines(path, encoding);
        }
        /// <summary>
        /// 随机产生结果(万分之CEN)
        /// </summary>
        /// <param name="cen">概率</param>
        /// <returns>true：中 false：不中</returns>
        public static bool RandomGet(int cen)
        {
            long tick = DateTime.Now.Millisecond;
            Random rd = new Random(GetRandomSeed());
            int r = rd.Next(0, 10000);
            if (cen < 0) return true;
            if (r < cen) return true;
            else return false;
        }

        public static string GetstrfromArr(string[] arr)
        {
            Random rd = new Random();
            int i = rd.Next(arr.Length);
            return arr[i];
        }

        /// <summary>
        /// 10进制转16进制
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static string Tentosixteen(string i)
        {
            try
            {
                long t = Convert.ToInt64(i);
                return Convert.ToString(t, 16).ToUpper();
            }
            catch { return string.Empty; }
        }

        /// <summary>
        /// 字符串形式的数字，16进制转10进制
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string SixteenToTen(string s)
        {
            return Convert.ToInt64(s, 16).ToString();
        }
        
        /// <summary>
        /// 调用GET API
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static T GetAPI<T>(string url) where T : class
        {
            System.Net.HttpWebRequest request = System.Net.WebRequest.Create(url) as System.Net.HttpWebRequest;
            request.Method = "GET";
            request.UserAgent = DefaultUserAgent;
            System.Net.HttpWebResponse result = request.GetResponse() as System.Net.HttpWebResponse;
            System.IO.StreamReader sr = new System.IO.StreamReader(result.GetResponseStream(), System.Text.Encoding.UTF8);
            string strResult = sr.ReadToEnd();
            var res = JsonConvert.DeserializeObject<T>(strResult);
            sr.Close();
            //Console.WriteLine(strResult);
            return res;
        }


        public static string fileToString(String fileName)
        {
            string strData = "";
            try
            {
                string line;
                // 创建一个 StreamReader 的实例来读取文件 ,using 语句也能关闭 StreamReader
                using (System.IO.StreamReader sr = new System.IO.StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName)))
                {
                    // 从文件读取并显示行，直到文件的末尾 
                    while ((line = sr.ReadLine()) != null)
                    {
                        //Console.WriteLine(line);
                        strData += line+Environment.NewLine;
                    }
                }
            }
            catch (Exception e)
            {
                // 向用户显示出错消息
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            return strData;
        }
        /// <summary>
        /// 调用GET API
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string GetAPI(string url)
        {
            System.Net.HttpWebRequest request = System.Net.WebRequest.Create(url) as System.Net.HttpWebRequest;
            request.Method = "GET";
            request.UserAgent = DefaultUserAgent;
            System.Net.HttpWebResponse result = request.GetResponse() as System.Net.HttpWebResponse;
            System.IO.StreamReader sr = new System.IO.StreamReader(result.GetResponseStream(), System.Text.Encoding.UTF8);
            string strResult = sr.ReadToEnd();
            sr.Close();
            //Console.WriteLine(strResult);
            return strResult;
        }


        #region 去掉HTML中的所有标签,只留下纯文本
        /// <summary>
        /// 去掉HTML中的所有标签,只留下纯文本
        /// </summary>
        /// <param name="strHtml"></param>
        /// <returns></returns>

        public static string CleanHtml(string strHtml)
        {
            if (string.IsNullOrEmpty(strHtml)) return strHtml;
            //删除脚本
            //Regex.Replace(strHtml, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase)
            strHtml = Regex.Replace(strHtml, "(<script(.+?)</script>)|(<style(.+?)<style>)", "", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            //删除标签
            var r = new Regex(@"</?[^>]*>", RegexOptions.IgnoreCase);
            Match m;
            for (m = r.Match(strHtml); m.Success; m = m.NextMatch())
            {
                strHtml = strHtml.Replace(m.Groups[0].ToString(), "");
            }
            return strHtml.Trim();
        }

        #endregion
        private static readonly string DefaultUserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";

        /// <summary>
        /// 调用POST请求
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="param">JSON数据</param>
        /// <returns></returns>
        public static T PostAPI<T>(string url, object param) where T : class
        {
            string strURL = url;
            System.Net.HttpWebRequest request;
            request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(strURL);
            request.Method = "POST";
            request.ContentType = "application/json;charset=UTF-8";
            request.UserAgent = DefaultUserAgent;
            string paraUrlCoded = JsonConvert.SerializeObject(param);
            byte[] payload;
            payload = System.Text.Encoding.UTF8.GetBytes(paraUrlCoded);
            request.ContentLength = payload.Length;
            System.IO.Stream writer = request.GetRequestStream();
            writer.Write(payload, 0, payload.Length);
            writer.Close();
            System.Net.HttpWebResponse response;
            response = (System.Net.HttpWebResponse)request.GetResponse();
            System.IO.Stream s;
            s = response.GetResponseStream();
            string StrDate = "";
            string strValue = "";
            System.IO.StreamReader Reader = new System.IO.StreamReader(s, System.Text.Encoding.UTF8);
            while ((StrDate = Reader.ReadLine()) != null)
            {
                strValue += StrDate;
            }
            var res = JsonConvert.DeserializeObject<T>(strValue);
            Reader.Close();
            return res;
        }

        /// <summary>
        /// 调用POST请求
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="param">JSON数据</param>
        /// <returns></returns>
        public static string PostAPI(string url, object param)
        {
            string strURL = url;
            System.Net.HttpWebRequest request;
            request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(strURL);
            request.Method = "POST";
            request.ContentType = "application/json;charset=UTF-8";
            request.UserAgent = DefaultUserAgent;
            string paraUrlCoded = JsonConvert.SerializeObject(param);
            byte[] payload;
            payload = System.Text.Encoding.UTF8.GetBytes(paraUrlCoded);
            request.ContentLength = payload.Length;
            System.IO.Stream writer = request.GetRequestStream();
            writer.Write(payload, 0, payload.Length);
            writer.Close();
            System.Net.HttpWebResponse response;
            response = (System.Net.HttpWebResponse)request.GetResponse();
            System.IO.Stream s;
            s = response.GetResponseStream();
            string StrDate = "";
            string strValue = "";
            System.IO.StreamReader Reader = new System.IO.StreamReader(s, System.Text.Encoding.UTF8);
            while ((StrDate = Reader.ReadLine()) != null)
            {
                strValue += StrDate;
            }
            Reader.Close();
            return strValue;
        }

        /// <summary>
        /// 得到本周第一天(以星期一为第一天)
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static DateTime GetWeekFirstDayMon(DateTime datetime)
        {
            //星期一为第一天
            int weeknow = Convert.ToInt32(datetime.DayOfWeek);

            //因为是以星期一为第一天，所以要判断weeknow等于0时，要向前推6天。
            weeknow = (weeknow == 0 ? (7 - 1) : (weeknow - 1));
            int daydiff = (-1) * weeknow;

            //本周第一天
            string FirstDay = datetime.AddDays(daydiff).ToString("yyyy-MM-dd");
            return Convert.ToDateTime(FirstDay);
        }

        /// <summary>
        /// 得到本周最后一天(以星期天为最后一天)
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static DateTime GetWeekLastDaySun(DateTime datetime)
        {
            //星期天为最后一天
            int weeknow = Convert.ToInt32(datetime.DayOfWeek);
            weeknow = (weeknow == 0 ? 7 : weeknow);
            int daydiff = (7 - weeknow);

            //本周最后一天
            string LastDay = datetime.AddDays(daydiff).ToString("yyyy-MM-dd");
            return Convert.ToDateTime(LastDay);
        }
        
        /// <summary>
        /// 获取公网IP
        /// </summary>
        /// <returns></returns>
        public static string GetIP()
        {
            string tempip = "";
            WebRequest request = WebRequest.Create("http://ip.qq.com/");
            request.Timeout = 10000;
            WebResponse response = request.GetResponse();
            Stream resStream = response.GetResponseStream();
            StreamReader sr = new StreamReader(resStream, System.Text.Encoding.Default);
            string htmlinfo = sr.ReadToEnd();
            //匹配IP的正则表达式
            Regex r = new Regex("((25[0-5]|2[0-4]\\d|1\\d\\d|[1-9]\\d|\\d)\\.){3}(25[0-5]|2[0-4]\\d|1\\d\\d|[1-9]\\d|[1-9])", RegexOptions.None);
            Match mc = r.Match(htmlinfo);
            //获取匹配到的IP
            tempip = mc.Groups[0].Value;
            resStream.Close();
            sr.Close();
            return tempip;
        }
    }
}
