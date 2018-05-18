using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traceless.TExtension.Tools
{
    class BaiDuAi
    {
        string _APP_ID = "";
        string _API_KEY = "";
        string _SECRET_KEY = "";

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
        public BaiDuAi(string APP_ID,string API_KEY,string SECRET_KEY)
        {
            _APP_ID = APP_ID;
            _API_KEY = API_KEY;
            _SECRET_KEY = SECRET_KEY;
            
        }
    }
}
