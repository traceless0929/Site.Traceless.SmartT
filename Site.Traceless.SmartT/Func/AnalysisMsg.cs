using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TModel;

namespace Site.Traceless.SmartT.Func
{
    public class AnalysisMsg
    {
        private static OrderInfoModel _msg = new OrderInfoModel("");

        public string What
        {
            get => _msg.What.Trim() ?? "";
        }

        public string How
        {
            get => _msg.How.Trim() ?? "";
        }

        public string Who
        {
            get => _msg.Who.Trim() ?? "";
        }

        public int OrderCount
        {
            get => _msg.OrderCount;
        }

        /// <summary>
        /// 解析消息结构
        /// </summary>
        /// <param name="msg"></param>
        public AnalysisMsg(string msg)
        {
            if (!string.IsNullOrEmpty(msg))
            {
                string str = new System.Text.RegularExpressions.Regex("[\\s]+").Replace(msg, " ");
                _msg = new OrderInfoModel(str);
            }
            else
            {
                _msg = new OrderInfoModel("");
            }
        }

        ~AnalysisMsg()
        {
        }

        public static long GetAtQq(string atCode)
        {
            string regexCode = "[1-9]([0-9]{5,})"; //正则代码

            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(regexCode);//初始化正则对象

            List<System.Collections.Specialized.NameValueCollection> ncList = new List<System.Collections.Specialized.NameValueCollection>(); //返回的结果集

            System.Text.RegularExpressions.MatchCollection mc = reg.Matches(atCode);//匹配;
            if (mc.Count > 0)
                return Convert.ToInt64(mc[0].Groups[0]);
            return -1;
        }
    }
}
