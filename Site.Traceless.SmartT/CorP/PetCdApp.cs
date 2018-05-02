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
        private readonly IMahuaApi _mahuaApi;
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
                        var url = Config.jx3ToolClass.GetPetCd(nowModel.Who, nowModel.How);
                        if (url != "[宠物CD] 服务器不存在，请联系管理员！")
                            _mahuaApi.SendGroupMessage(msg.FromGroup).Text(CQCode.SendLink("宠物CD-" + nowModel.Who, "http://file.yayaquanzhidao.com/logo.ico", "点击查看'" + nowModel.Who + "' 结果【来自：鸭鸭宠物CD查询】", url)).Done();
                        else
                            _mahuaApi.SendGroupMessage(msg.FromGroup).Text(url).Done();
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
                    var url = Config.jx3ToolClass.GetPetCd(nowModel.Who, nowModel.How);
                    if (url != "[宠物CD] 服务器不存在，请联系管理员！")
                        _mahuaApi.SendPrivateMessage(msg.FromQq).Text(CQCode.SendLink("宠物CD-" + nowModel.Who, "http://file.yayaquanzhidao.com/logo.ico", "点击查看'" + nowModel.Who + "' 结果【来自：鸭鸭宠物CD查询】", url)).Done();
                    else
                        _mahuaApi.SendPrivateMessage(msg.FromQq).Text(url).Done();
                    return;
                }
            }
            successor.ProcessRequset(msg, nowModel);
        }
    }
}
