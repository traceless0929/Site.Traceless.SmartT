using Newbe.Mahua;
using Newbe.Mahua.MahuaEvents;
using Site.Traceless.SmartT.Func;
using Site.Traceless.SmartT.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traceless.TExtension.Tools;

namespace Site.Traceless.SmartT.CorP
{
    internal class DayTaskApp : Approver
    {
        private readonly IMahuaApi _mahuaApi;
        public DayTaskApp(IMahuaApi mahuaApi, Approver approver)
        {
            _mahuaApi = mahuaApi;
            this.SetSuccesser(approver);
        }
        public override void ProcessRequset(GroupMessageReceivedContext msg, AnalysisMsg nowModel)
        {
            if (Config.ConfigModel.IsFuncOpen("查日常"))
            {
                if (nowModel.What == "查日常")
                {
                    var item = WeiboTool.GetWeiBoTopicContent("剑网3江湖百晓生", "剑网3官方微博").FirstOrDefault();
                    if (item == null)
                        _mahuaApi.SendGroupMessage(msg.FromGroup, "[日常]QAQ查询失败，请联系管理员");
                    else
                    {
                        if(nowModel.Who=="文")
                            _mahuaApi.SendGroupMessage(msg.FromGroup).Text("[日常]来自 " + item.Author + "：").Newline().Text(item.ContentStr).Newline().Text(@"本信息由新浪微博-剑网3江湖百晓生-超话提供").Done();
                        else
                            _mahuaApi.SendGroupMessage(msg.FromGroup).Text(CQCode.SendLink("查日常-来自微博", item.Pic,item.ContentStr.Replace("\n","").Replace("#剑网3江湖百晓生#",""),item.Pic)).Done();
                    }
                }
            }
            successor.ProcessRequset(msg, nowModel);
        }

        public override void ProcessRequset(PrivateMessageFromFriendReceivedContext msg, AnalysisMsg nowModel)
        {
            successor.ProcessRequset(msg, nowModel);
        }
    }
}
