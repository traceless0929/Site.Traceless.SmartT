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
    internal class PetCdApp : Approver
    {
        private IMahuaApi _mahuaApi;
        public PetCdApp(IMahuaApi mahuaApi)
        {
            _mahuaApi = mahuaApi;
        }
        public override void ProcessRequset(GroupMessageReceivedContext msg,AnalysisMsg nowModel)
        {
            if (Config.ConfigModel.IsFuncOpen("宠物"))
            {
                if(nowModel.What=="宠物")
                {
                   if(nowModel.OrderCount>1)
                    {
                        _mahuaApi.SendGroupMessage(msg.FromGroup).Text(CQCode.SendLink("宠物CD-" + nowModel.Who, "http://www.yayaquanzhidao.top/logo.ico", "点击查看'" + nowModel.Who + "' 结果【来自：鸭鸭宠物CD查询】", Jx3ToolClass.GetPetCd(nowModel.Who, nowModel.How))).Done();
                        return;
                    }
                }
            }
            successor.ProcessRequset(msg, nowModel);
        }

        public override void ProcessRequset(PrivateMessageFromFriendReceivedContext msg, AnalysisMsg nowModel)
        {
            if (nowModel.What == "宠物")
            {
                if (nowModel.OrderCount > 1)
                {
                    _mahuaApi.SendPrivateMessage(msg.FromQq).Text(CQCode.SendLink("宠物CD-" + nowModel.Who, "http://www.yayaquanzhidao.top/logo.ico", "点击查看'" + nowModel.Who + "' 结果【来自：鸭鸭宠物CD查询】", Jx3ToolClass.GetPetCd(nowModel.Who, nowModel.How))).Done();
                    return;
                }
            }
            successor.ProcessRequset(msg, nowModel);
        }
    }
}
