using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newbe.Mahua;
using Newbe.Mahua.MahuaEvents;
using Site.Traceless.SmartT.Func;

namespace Site.Traceless.SmartT.CorP
{
    internal class AdviseApp : Approver
    {
        private readonly IMahuaApi _mahuaApi;
        public AdviseApp(IMahuaApi mahuaApi, Approver approver)
        {
            _mahuaApi = mahuaApi;
            this.SetSuccesser(approver);
        }
        public override void ProcessRequset(GroupMessageReceivedContext msg, AnalysisMsg nowModel)
        {
            if (Config.ConfigModel.IsFuncOpen("建议"))
            {
                if (nowModel.What == "建议")
                {
                    _mahuaApi.SendPrivateMessage(Config.ConfigModel.MasterQQ).Text($"来自群{msg.FromGroup}的{msg.FromQq}:{nowModel.Who} {nowModel.How}").Done();
                    return;
                }
            }
            successor.ProcessRequset(msg, nowModel);
        }

        public override void ProcessRequset(PrivateMessageFromFriendReceivedContext msg, AnalysisMsg nowModel)
        {
            if (Config.ConfigModel.IsFuncOpen("建议"))
            {
                if (nowModel.What == "建议")
                {
                    _mahuaApi.SendPrivateMessage(Config.ConfigModel.MasterQQ).Text($"来自个人{msg.FromQq}:{nowModel.Who} {nowModel.How}").Done();
                    return;
                }
            }
            successor.ProcessRequset(msg, nowModel);
        }
    }
}
