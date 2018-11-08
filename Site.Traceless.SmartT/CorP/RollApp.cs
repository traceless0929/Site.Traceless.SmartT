using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newbe.Mahua;
using Newbe.Mahua.MahuaEvents;
using Site.Traceless.SmartT.Func;
using Traceless.TExtension.Tools;

namespace Site.Traceless.SmartT.CorP
{
    internal class RollApp : Approver
    {
        private readonly IMahuaApi _mahuaApi;
        public RollApp(IMahuaApi mahuaApi, Approver approver)
        {
            _mahuaApi = mahuaApi;
            this.SetSuccesser(approver);
        }
        public override void ProcessRequset(GroupMessageReceivedContext msg, AnalysisMsg nowModel)
        {
            if (Config.ConfigModel.IsFuncOpen("Roll点"))
            {
                if (nowModel.What.ToLower() == "/roll")
                {
                    _mahuaApi.SendGroupMessage(msg.FromGroup).At(msg.FromQq).Text($"Roll了 {ToolClass.RandomGet(0,100)} 点").Done();
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
