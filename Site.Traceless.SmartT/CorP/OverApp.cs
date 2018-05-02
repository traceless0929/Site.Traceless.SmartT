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
    internal class OverApp : Approver
    {
        private readonly IMahuaApi _mahuaApi;
        public OverApp(IMahuaApi mahuaApi)
        {
            _mahuaApi = mahuaApi;
        }
        public override void ProcessRequset(GroupMessageReceivedContext msg, AnalysisMsg nowModel)
        {
            return;
        }

        public override void ProcessRequset(PrivateMessageFromFriendReceivedContext msg, AnalysisMsg nowModel)
        {
            return;
        }
    }
}
