using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB;

namespace Site.Traceless.SmartT.DAL
{
    public class DALSign
    {
        public TSign GetSign(string pid)
        {
            using (var db = new SmartTSqlDB())
            {
                var res = db.TSigns.FirstOrDefault(p => p.Pid==pid);
                return res;
            }
        }

        public void SetSign(string pid,string gid)
        {
            using (var db = new SmartTSqlDB())
            {
                var res = db.TSigns.FirstOrDefault(p => p.Pid == pid);
                if (res == null)
                {
                    db.TSigns
                        .Value(p => p.Gid, gid)
                        .Value(p => p.Pid, pid)
                        .Value(p => p.SignGid, gid)
                        .Value(p => p.LastSign, DateTime.Now)
                        .Insert();
                }
                else
                {
                    db.TSigns
                        .Where(p => p.Id == res.Id)
                        .Set(p => p.Pid, pid)
                        .Set(p => p.SignGid, gid)
                        .Set(p => p.LastSign, DateTime.Now)
                        .Update();
                }
            }
        }
    }
}
