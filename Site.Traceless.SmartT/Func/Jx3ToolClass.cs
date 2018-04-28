using Site.Traceless.SmartT.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traceless.TExtension.Tools;

namespace Site.Traceless.SmartT.Func
{
    public class Jx3ToolClass
    {
        private static Dictionary<string, string> serbiglist = new Dictionary<string, string>();
        private static Dictionary<string, string> aslist = new Dictionary<string, string>();
        private static Dictionary<string, int> PetServerList = new Dictionary<string, int>();
        public Jx3ToolClass()
        {
            serbiglist.Clear();
            aslist.Clear();
            string[] temp = Jx3OpenTell.GetSerIni();
            foreach (var item in temp)
            {
                string[] additem = item.Split('\t');
                if (additem.Length > 9)
                {
                    try
                    {
                        serbiglist.Add(additem[1], additem[10].Replace("双线", ""));
                        aslist.Add(additem[1], additem[0]);
                    }
                    catch
                    {
                        continue;
                    }
                }
            }

            var petDic = ToolClass.GetDataFromUrl(@"http://file.yayaquanzhidao.com/JavaScript/FuName.js");
            var petDicstr = petDic.GetMidStrings(@"'", @"'")[0];
            PetServerList = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, int>>(petDicstr);

        }

        public static string GetPetCd(string serverName, string petName = "")
        {
            serbiglist.TryGetValue(serverName, out string factServerName);
            if (string.IsNullOrEmpty(factServerName)) return "[宠物CD] 服务器不存在，请联系管理员！";
            PetServerList.TryGetValue(factServerName, out int serverId);
            return @"http://www.yayaquanzhidao.top/?ID=" + serverId;
        }

        //http://file.yayaquanzhidao.com/fu/funame.js
    }
}
