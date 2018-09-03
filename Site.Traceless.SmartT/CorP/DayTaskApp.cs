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
using Traceless.TExtension.Tools.Model;

namespace Site.Traceless.SmartT.CorP
{
    internal class DayTaskApp : Approver
    {
        private WeiBoContentItem lastestItem = null;
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
                WeiBoContentItem item = new WeiBoContentItem();
                if (nowModel.What == "查日常")
                {
                    if (lastestItem != null)
                    {
                        item = (lastestItem.Time.Date == DateTime.Now.Date) ? lastestItem : WeiboTool.GetWeiboByUid("1761587065", "1076031761587065", "#剑网3江湖百晓生#").OrderByDescending(p => p.Time).FirstOrDefault(); //WeiboTool.GetWeiBoTopicContentV1("剑网3江湖百晓生", "剑网3官方微博").FirstOrDefault();
                    }
                    else
                        item = WeiboTool.GetWeiboByUid("1761587065", "1076031761587065", "#剑网3江湖百晓生#").OrderByDescending(p => p.Time).FirstOrDefault();//WeiboTool.GetWeiBoTopicContentV1("剑网3江湖百晓生", "剑网3官方微博").OrderByDescending(p => p.Time).FirstOrDefault();

                    if (item == null)
                    {
                        if (Config.DefaltItem != null)
                        {
                            _mahuaApi.SendGroupMessage(msg.FromGroup).Text("[日常]QAQ官微又偷懒了，为您提供"+ Config.DefaltItem .Time.ToShortDateString()+ " 来自 " + Config.DefaltItem.Author + "：").Newline().Text(Config.DefaltItem.ContentStr).Newline().Text(@"本信息由官博偷懒没发日常倾情触发，更新请通过建议提交日常信息给我~").Done();
                        }
                        else
                        {
                            _mahuaApi.SendGroupMessage(msg.FromGroup, "[日常]QAQ查询失败，请联系管理员");
                        }
                    }
                        
                    else
                    {
                        lastestItem = item;
                        if (nowModel.Who=="文")
                            _mahuaApi.SendGroupMessage(msg.FromGroup).Text("[日常]来自 " + item.Author + "：").Newline().Text(item.ContentStr).Newline().Text(@"本信息由新浪微博-剑网3江湖百晓生-超话提供").Done();
                        else
                            _mahuaApi.SendGroupMessage(msg.FromGroup).Text(CQCode.SendLink("查日常-"+item.Time.ToShortDateString(), item.Pic,item.ContentStr.Replace("#剑网3江湖百晓生#","").Trim(),item.Pic)).Done();
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
