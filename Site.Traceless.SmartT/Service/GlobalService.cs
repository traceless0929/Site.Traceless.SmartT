using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traceless.TExtension.Tools;

namespace Site.Traceless.SmartT.Service
{
    public class GlobalService
    {
        static string _APP_ID = System.Configuration.ConfigurationManager.AppSettings["BaiDu_APP_ID"];
        static string _API_KEY = System.Configuration.ConfigurationManager.AppSettings["BaiDu_API_KEY"];
        static string _SECRET_KEY = System.Configuration.ConfigurationManager.AppSettings["BaiDu_SECRET_KEY"];
        public static BaiDuAi BaiDuAiIns = new BaiDuAi(_APP_ID, _API_KEY, _SECRET_KEY);
    }
}
