using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Traceless.TExtension.Tools
{
    public class BaiDuAi
    {
        string _APP_ID = ConfigurationManager.AppSettings["BaiDu_APP_ID"].ToString();
        string _API_KEY = ConfigurationManager.AppSettings["BaiDu_API_KEY"].ToString();
        string _SECRET_KEY = ConfigurationManager.AppSettings["BaiDu_SECRET_KEY"].ToString();
        string _TemplateSign_= ConfigurationManager.AppSettings["BaiDu_TASKDAY_TID"].ToString();

        Baidu.Aip.Ocr.Ocr _ocRclient = null;
        public Baidu.Aip.Ocr.Ocr ocRclient
        {
            get
            {
                if (_ocRclient == null)
                {
                    if (string.IsNullOrEmpty(_APP_ID) || string.IsNullOrEmpty(_API_KEY) || string.IsNullOrEmpty(_SECRET_KEY))
                    {
                        throw new Exception("AppId或Key为空，请先初始化BaiDuAi", null);
                    }
                    _ocRclient = new Baidu.Aip.Ocr.Ocr(_API_KEY, _SECRET_KEY);
                    _ocRclient.Timeout = 60000;
                }
                return _ocRclient;
            }
        }

        public void Custom(byte[] image, string templateSign, Dictionary<string, object> options = null)
        {
            JObject res = _ocRclient.Custom(image, _TemplateSign_, options);
        }
    }
}
