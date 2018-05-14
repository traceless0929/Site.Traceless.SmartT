using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Traceless.Api.Services.Interface;
using System.Linq;
using Traceless.Util;

namespace Traceless.Api.Services
{
    /// <summary>
    /// 统计服务
    /// </summary>
    public class StasticService : IStasticService
    {
        /// <summary>
        /// 根据日期获取签到排名
        /// </summary>
        /// <param name="dt">日期</param>
        /// <param name="count">数量</param>
        /// <returns></returns>
        public Dictionary<long,string> GetTopSignByDay(DateTime dt,int count=3)
        {
            using (var db = new SmartTSqlDB())
            {
                var res = db.TSigns.Where(p => p.LastSign.Date == dt.Date).OrderBy(p => p.LastSign.Ticks).Take(count).ToDictionary(c => c.LastSign.ConvertToTimeStamp(), c => c.Pid);
                return res;
            }
        }
    }
}
