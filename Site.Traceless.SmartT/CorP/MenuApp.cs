using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newbe.Mahua;
using Newbe.Mahua.MahuaEvents;
using Site.Traceless.SmartT.DAL;
using Site.Traceless.SmartT.Func;

namespace Site.Traceless.SmartT.CorP
{
    internal class MenuApp : Approver
    {
        private IMahuaApi _mahuaApi;
        public MenuApp(IMahuaApi mahuaApi)
        {
            _mahuaApi = mahuaApi;
        }

        public override void ProcessRequset(GroupMessageReceivedContext msg, AnalysisMsg nowModel)
        {
            if (Config.ConfigModel.IsFuncOpen("菜单"))
            {
                if (msg.Message.Trim() == "菜单")
                {
                    _mahuaApi.SendGroupMessage(msg.FromGroup).Text(Config.ConfigModel.MenuStr).Done();
                    return;
                }
            }
            successor.ProcessRequset(msg, nowModel);
        }

        public override void ProcessRequset(PrivateMessageFromFriendReceivedContext msg, AnalysisMsg nowModel)
        {
            if (Config.ConfigModel.IsFuncOpen("个人菜单"))
            {
                if (msg.Message.Trim() == "菜单")
                {
                    _mahuaApi.SendPrivateMessage(msg.FromQq).Text(Config.ConfigModel.PrivateMenuStr).Done();
                    return;
                }
            }
            successor.ProcessRequset(msg, nowModel);
        }
    }
}
