using Newbe.Mahua;
using Site.Traceless.SmartT.Func;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using TModel;
using Traceless.TExtension.Tools;
using Traceless.TExtension.Tools.Model;

namespace Site.Traceless.SmartT
{
    public class Config
    {
        public static ConfigModel ConfigModel { get; set; } = new ConfigModel();
        public static string[,] serList = Jx3OpenTell.GetSerList();
        public static Jx3ToolClass jx3ToolClass = new Jx3ToolClass();
        public static WeiBoContentItem DefaltItem { get; set; } = new WeiBoContentItem();
    }
}
