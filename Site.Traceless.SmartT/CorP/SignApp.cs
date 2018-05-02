using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newbe.Mahua;
using Newbe.Mahua.MahuaEvents;
using Site.Traceless.SmartT.DAL;
using Newbe.Mahua.CQP.ApiExtensions;
using Traceless.TExtension.Tools;
using Site.Traceless.SmartT.Func;

namespace Site.Traceless.SmartT.CorP
{
    internal class SignApp : Approver
    {
        public DALSign DALSign = new DALSign();
        private readonly IMahuaApi _mahuaApi;
        public SignApp(IMahuaApi mahuaApi)
        {
            _mahuaApi = mahuaApi;
        }
        public override void ProcessRequset(GroupMessageReceivedContext msg, AnalysisMsg nowModel)
        {
            if (Config.ConfigModel.IsFuncOpen("签到"))
            {
                if (msg.Message == "签到")
                {
                    var signEnt = DALSign.GetSign(msg.FromQq);
                    bool signed = false;
                    string content = $"给小可爱10个赞！\r\n麻花疼：每天每Q最多点500赞~先到先得！";
                    if (signEnt != null)
                    {
                        signed = (signEnt.LastSign.Date == DateTime.Now.Date);
                        if (signed)
                        {
                            content = $"您于{signEnt.LastSign.ToShortTimeString()}在{(signEnt.SignGid == msg.FromGroup ? "本群" : "隔壁群")}签过到了！\r\n没有多的赞惹TuT";
                        }
                    }
                    if (!signed)
                    {

                        SendLike(msg.FromQq);
                        DALSign.SetSign(msg.FromQq, msg.FromGroup);
                    }
                    _mahuaApi.SendGroupMessage(msg.FromGroup).
                            Text(CQCode.SendLink(signed ? "您签过到了！" : "签到成功！", CQCode.GetQQHead(msg.FromQq), content))
                            .Done();
                    return;
                }
            }
            successor.ProcessRequset(msg,nowModel);
        }

        private void SendLike(string toQQ,int times=10)
        {
            int time = 0;
            do
            {
                _mahuaApi.SendLike(toQQ);
                time++;

            } while (time < times);
        }

        public override void ProcessRequset(PrivateMessageFromFriendReceivedContext msg, AnalysisMsg nowModel)
        {
            //私聊签到不处理，直接提交下级
            successor.ProcessRequset(msg, nowModel);
        }
    }
}
