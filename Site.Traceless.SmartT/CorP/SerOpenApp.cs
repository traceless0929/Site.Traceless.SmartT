using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newbe.Mahua;
using Newbe.Mahua.MahuaEvents;
using Site.Traceless.SmartT.Func;
using Site.Traceless.SmartT.Service;

namespace Site.Traceless.SmartT.CorP
{
    internal class SerOpenApp : Approver
    {
        private readonly IMahuaApi _mahuaApi;
        private readonly IServerRemind _serverRemind;
        public SerOpenApp(IMahuaApi mahuaApi, IServerRemind serverRemind)
        {
            _mahuaApi = mahuaApi;
            _serverRemind = serverRemind;
        }
        public override void ProcessRequset(GroupMessageReceivedContext msg, AnalysisMsg nowModel)
        {
            if (Config.ConfigModel.IsFuncOpen("开服监控"))
            {
                if (nowModel.What == "开服监控")
                {
                    _serverRemind.StartAsync(msg.FromGroup, nowModel.Who).GetAwaiter().GetResult();
                    return;
                }
            }
            if (Config.ConfigModel.IsFuncOpen("开服查询"))
            {
                if (nowModel.What == "开服查询")
                {
                    _serverRemind.GoServerQuery(msg.FromGroup, nowModel.Who);
                    return;
                }
            }
            successor.ProcessRequset(msg, nowModel);
        }

        public override void ProcessRequset(PrivateMessageFromFriendReceivedContext msg, AnalysisMsg nowModel)
        {
            successor.ProcessRequset(msg, nowModel);
        }
    }
}
