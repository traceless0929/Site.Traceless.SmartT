using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newbe.Mahua;
using Newbe.Mahua.MahuaEvents;
using Site.Traceless.SmartT.DAL;
using Site.Traceless.SmartT.Func;
using Traceless.TExtension.Tools;

namespace Site.Traceless.SmartT.CorP
{
    internal class MenuApp : Approver
    {
        private readonly IMahuaApi _mahuaApi;
        public MenuApp(IMahuaApi mahuaApi, Approver approver)
        {
            _mahuaApi = mahuaApi;
            this.SetSuccesser(approver);
        }

        public override void ProcessRequset(GroupMessageReceivedContext msg, AnalysisMsg nowModel)
        {
            if (Config.ConfigModel.IsFuncOpen("菜单"))
            {
                if (msg.Message.Trim() == "菜单")
                {
                    _mahuaApi.SendGroupMessage(msg.FromGroup).Text(Config.ConfigModel.MenuStr).Done();
                    _mahuaApi.SendGroupMessage(msg.FromGroup).Text(@"小T完全手册：https://traceless.site/index.php/archives/62/").Newline().Text("网站没交保护费提醒危险网站，在这里本人实名点X麻花疼！甘霖娘！").Done();
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
                    _mahuaApi.SendPrivateMessage(msg.FromQq).Text(@"小T完全手册：https://traceless.site/index.php/archives/62/").Newline().Text("网站没交保护费提醒危险网站，在这里本人实名点X麻花疼！甘霖娘！").Done();
                    return;
                }
            }
            successor.ProcessRequset(msg, nowModel);
        }
    }
}
