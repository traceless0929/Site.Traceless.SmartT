using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newbe.Mahua;
using Newbe.Mahua.MahuaEvents;
using Site.Traceless.SmartT.Func;
using Traceless.TExtension.Tools;
using Traceless.TExtension.Tools.Model;

namespace Site.Traceless.SmartT.CorP
{
    internal class ManagerApp : Approver
    {
        private readonly IMahuaApi _mahuaApi;
        public ManagerApp(IMahuaApi mahuaApi, Approver approver)
        {
            _mahuaApi = mahuaApi;
            this.SetSuccesser(approver);
        }
        public override void ProcessRequset(GroupMessageReceivedContext msg, AnalysisMsg nowModel)
        {

            successor.ProcessRequset(msg, nowModel);
        }

        public override void ProcessRequset(PrivateMessageFromFriendReceivedContext msg, AnalysisMsg nowModel)
        {
            if(msg.FromQq==Config.ConfigModel.MasterQQ)
            {
                if (nowModel.What == "反馈")
                {
                    _mahuaApi.SendGroupMessage(nowModel.Who).Text($"{nowModel.How}").Newline().Text("[来自作者的反馈]").Done();
                    return;
                }
                if (nowModel.What == "个人反馈")
                {
                    _mahuaApi.SendPrivateMessage(nowModel.Who).Text($"{nowModel.How}").Newline().Text("[来自作者的反馈]").Done();
                    return;
                }

                if (nowModel.What == "设日常")
                {
                    Config.DefaltItem = new WeiBoContentItem
                    {
                        Author = "帅气的作者手动创建",
                        Time = Convert.ToDateTime(nowModel.Who),
                        ContentStr = nowModel.How,
                        Pic = @"https://traceless.site/"
                    };
                }
            }

            successor.ProcessRequset(msg, nowModel);
        }
    }
}
