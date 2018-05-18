using Newbe.Mahua;
using Newbe.Mahua.MahuaEvents;
using Site.Traceless.SmartT.Func;
using Site.Traceless.SmartT.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.Traceless.SmartT.CorP
{
    internal class ZJSubmitApp : Approver
    {
        private readonly IMahuaApi _mahuaApi;
        public ZJSubmitApp(IMahuaApi mahuaApi, Approver approver)
        {
            _mahuaApi = mahuaApi;
            this.SetSuccesser(approver);
        }
        public override void ProcessRequset(GroupMessageReceivedContext msg, AnalysisMsg nowModel)
        {
            if (Config.ConfigModel.IsFuncOpen("查排名"))
            {
                if (nowModel.What == "查排名")
                {
                    
                }
            }
            successor.ProcessRequset(msg, nowModel);
        }

        public override void ProcessRequset(PrivateMessageFromFriendReceivedContext msg, AnalysisMsg nowModel)
        {
            if (Config.ConfigModel.IsFuncOpen("站街申报"))
            {
                if (nowModel.What == "站街申报")
                {
                    
                    return;
                }
            }
            successor.ProcessRequset(msg, nowModel);
        }
    }
}
