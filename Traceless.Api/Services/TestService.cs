using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Traceless.Api.Services.Interface;
using System.Linq;

namespace Traceless.Api.Services
{
    /// <summary>
    /// 测试用服务
    /// </summary>
    public class TestService:ITestService
    {
        /// <summary>
        /// 根据日期获取签到排名
        /// </summary>
        /// <param name="dt">日期</param>
        /// <param name="count">数量</param>
        /// <returns></returns>
        public Dictionary<string, DateTime> GetTopSignByDay(DateTime dt,int count=3)
        {
            using (var db = new SmartTSqlDB())
            {
                return db.TSigns.Where(p => p.LastSign.Date == dt.Date).OrderByDescending(p => p.LastSign.Ticks).Take(count).ToDictionary(c=>c.Pid,c=>c.LastSign);
            }
        }
    }
}
