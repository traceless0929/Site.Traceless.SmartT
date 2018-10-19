using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib;
using Dapper.Contrib.Extensions;

namespace Site.Traceless.SmartT.DAL
{
    public class DALSign
    {
        public TSign GetSign(string pid)
        {
            using (var db = new MySqlConnection(""))
            {
                var res = db.QueryFirstOrDefault<TSign>("select * from T_Config where pid=@pid",new {pid});
                return res;
            }
        }

        public void SetSign(string pid,string gid)
        {
            using (var db = new MySqlConnection(""))
            {
                var res = db.QueryFirstOrDefault<TSign>("select * from T_Config where pid=@pid", new { pid });
                if (res == null)
                {
                    res = new TSign
                    {
                        Gid = gid,
                        LastSign = DateTime.Now,
                        Pid = pid,
                        SignGid = gid,
                    };
                    db.Insert<TSign>(res);
                }
                else
                {
                    db.Update(res);
                }
            }
        }
    }
}
