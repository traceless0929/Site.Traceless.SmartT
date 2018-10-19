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
    internal class ChoseApp : Approver
    {
        private readonly IMahuaApi _mahuaApi;
        public ChoseApp(IMahuaApi mahuaApi, Approver approver)
        {
            _mahuaApi = mahuaApi;
            this.SetSuccesser(approver);
        }
        public override void ProcessRequset(GroupMessageReceivedContext msg, AnalysisMsg nowModel)
        {
            if (Config.ConfigModel.IsFuncOpen("抽锦鲤"))
            {
                
                var res = _mahuaApi.GetGroupMemebersWithModel(msg.FromGroup);
               
            }
            successor.ProcessRequset(msg, nowModel);
        }

        public override void ProcessRequset(PrivateMessageFromFriendReceivedContext msg, AnalysisMsg nowModel)
        {
            successor.ProcessRequset(msg, nowModel);
        }

    }
}
