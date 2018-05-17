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
                    _mahuaApi.SendGroupMessage(msg.FromGroup).Text(CQCode.SendLink("小T完全手册", CQCode.GetQQHead(_mahuaApi.GetLoginQq()), "小T操作手册：最新最全的小T使用攻略", "https://traceless.site/index.php/archives/62/")).Done();
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
                    _mahuaApi.SendPrivateMessage(msg.FromQq).Text(CQCode.SendLink("小T完全手册", CQCode.GetQQHead(_mahuaApi.GetLoginQq()), "小T操作手册：最新最全的小T使用攻略", "https://traceless.site/index.php/archives/62/")).Done();
                    return;
                }
            }
            successor.ProcessRequset(msg, nowModel);
        }
    }
}
