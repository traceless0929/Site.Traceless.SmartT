using MySql.Data.MySqlClient;
using Dapper;
using Dapper.Contrib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TModel;
using Dapper.Contrib.Extensions;

namespace Site.Traceless.SmartT.DAL
{
    public class DALConfig
    {
        public ConfigModel GetConfig()
        {
            ConfigModel ret = new ConfigModel();
            using (var db = new MySqlConnection(""))
            {
                var res = db.GetAll<TConfig>().ToList();
                ret.Name = GetConfigStr(res, "TName");
                ret.MenuStr= GetConfigStr(res, "MenuStr");
                ret.PrivateMenuStr= GetConfigStr(res, "PMenuStr");
                ret.MasterQQ = GetConfigStr(res, "MasterQQ");
                var funcs = db.Query<TFuncConfig>("select * from T_FuncConfig").ToList();
                funcs.ForEach(p =>
                {
                    ret.FunList.Add(MapperUtil.Map<FuncItem>(p));
                });
                return ret;
            }
        }

        public string GetConfigStr(List<TConfig> list,string name)
        {
            return list.Find(p => p.Name == name).Value;
        }

    }
}
