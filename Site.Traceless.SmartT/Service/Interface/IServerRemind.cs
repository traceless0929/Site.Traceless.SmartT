using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.Traceless.SmartT.Service
{
    public interface IServerRemind
    {
        /// <summary>
        /// 开服监控
        /// </summary>
        /// <returns></returns>
        void GoServerRemind(string gid,string serverName);

        /// <summary>
        /// 开服提醒
        /// </summary>
        /// <returns></returns>
        void GoServerQuery(string gid, string serverName);
        Task StartAsync(string fromGroup, string who);
    }
}
