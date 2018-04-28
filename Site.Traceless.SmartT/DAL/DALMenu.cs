using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.Traceless.SmartT.DAL
{
    public class DALMenu
    {
        public string GetMenuStr()
        {
            using (var db = new SmartTSqlDB())
            {
                var res = db.TConfigs.FirstOrDefault(p => p.Name == "MenuStr").Value;
                return res;
            }
        }
    }
}
