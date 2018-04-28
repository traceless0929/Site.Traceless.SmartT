using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Newbe.Mahua;
using Newbe.Mahua.MahuaEvents;
using Site.Traceless.SmartT.Func;
using Traceless.TExtension.Tools;

namespace Site.Traceless.SmartT.CorP
{
    internal class OpenTellApp : Approver
    {
        private IMahuaApi _mahuaApi;
        public OpenTellApp(IMahuaApi mahuaApi)
        {
            _mahuaApi = mahuaApi;
        }
        public override void ProcessRequset(GroupMessageReceivedContext msg, AnalysisMsg nowModel)
        {
            if (Config.ConfigModel.IsFuncOpen("开服监控"))
            {
                if(nowModel.What=="开服监控")
                {
                    ServerRemind(msg.FromGroup, nowModel.Who);
                    return;
                }
            }
            if (Config.ConfigModel.IsFuncOpen("开服查询"))
            {
                if (nowModel.What == "开服查询")
                {
                    ServerQueClu(msg.FromGroup, nowModel.Who);
                    return;
                }
            }
            successor.ProcessRequset(msg, nowModel);
        }

        public override void ProcessRequset(PrivateMessageFromFriendReceivedContext msg, AnalysisMsg nowModel)
        {
            successor.ProcessRequset(msg, nowModel);
        }

        #region 开服查询类

        private string[,] serList = Jx3OpenTell.GetSerList();

        private void ServerQueClu(string clu, string str)
        {
            bool flag = false;
            string text = str.Trim();
            string ip = string.Empty;
            string str2 = string.Empty;
            for (int i = 0; i < this.serList.GetLength(0); i++)
            {
                bool flag2 = text.Equals(this.serList[i, 1]);
                if (flag2)
                {
                    ip = this.serList[i, 2];
                    str2 = this.serList[i, 0];
                    string content = Jx3OpenTell.IsOpen(ip, 3724) ? (str2 + " " + text + "\r\n开") : (str2 + " " + text + "\r\n关");
                    _mahuaApi.SendGroupMessage(clu, CQCode.SendLink("开服查询",CQCode.GetQQHead(_mahuaApi.GetLoginQq()), content));
                    flag = true;
                }
                else
                {
                    bool flag3 = !flag && i == this.serList.GetLength(0) - 1;
                    if (flag3)
                    {
                        _mahuaApi.SendGroupMessage(clu, " 对不起，没有找到服务器 (づ╥﹏╥)づ");
                    }
                }
            }
        }

        private void ServerRemind(string clu, string str)
        {
            bool flag = false;
            string serName = str.Trim();
            string bigSer = string.Empty;
            for (int i = 0; i < serList.GetLength(0); i++)
            {
                if (serName.Equals(serList[i, 1]))
                {
                    bool existflag = false;
                    bigSer = serList[i, 0];
                    serList[i, 3] = "1";
                    serList[i, 4] += "|" + clu;
                    string[] cluList = serList[i, 4].Split('|');
                    foreach (var istr in cluList)
                    {
                        if (istr == clu + "") existflag = true;
                    }
                    if (!existflag)
                    {
                        serList[i, 4] += "|" + clu;
                    }
                    _mahuaApi.SendGroupMessage(clu, CQCode.SendLink("开服监控",CQCode.GetQQHead(_mahuaApi.GetLoginQq()), "已为您开启 " + str + "的监控~请关注群信息，将第一时间通知到群。"));
                    timer.Enabled = true;
                    flag = true;
                    continue;
                }
                else if (!flag && i == serList.GetLength(0) - 1)
                {
                    _mahuaApi.SendGroupMessage(clu, " 对不起，没有找到服务器 (づ╥﹏╥)づ \n监控开启失败");
                }
            }
        }

        private void SerOpenRemind_Tick(object sender, EventArgs e)
        {
            this.timer.Enabled = false;
            for (int i = 0; i < this.serList.GetLength(0); i++)
            {
                bool flag = this.serList[i, 3] != "1";
                if (!flag)
                {
                    string ip = this.serList[i, 2];
                    string[] array = this.serList[i, 4].Split(new char[]
                    {
                        '|'
                    });
                    string text = string.Empty;
                    string str = this.serList[i, 0];
                    string str2 = this.serList[i, 1];
                    bool flag2 = !Jx3OpenTell.IsOpen(ip, 3724);
                    if (!flag2)
                    {
                        text = CQCode.SendLink("开服监控", CQCode.GetQQHead(_mahuaApi.GetLoginQq()), str + " " + str2 + " 开服了！");
                        for (int j = 1; j < array.Length; j++)
                        {
                            _mahuaApi.SendGroupMessage(array[j], text);
                        }
                        this.serList[i, 3] = "0";
                        this.serList[i, 4] = "List";
                    }
                }
            }
            this.timer.Enabled = true;
        }

        private Timer timer;

        #endregion 开服查询类
    }
}
