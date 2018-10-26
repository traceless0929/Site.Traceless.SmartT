using Newbe.Mahua;
using Site.Traceless.SmartT.Func;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Traceless.TExtension.Tools;

namespace Site.Traceless.SmartT.Service
{
    public class ServerRemind : IServerRemind
    {
        private static IMahuaApi _mahuaApi;
        public ServerRemind(IMahuaApi mahuaApi)
        {
            _mahuaApi = mahuaApi;
            if(timer==null)
            {
                timer = new Timer
                {
                    Interval = 1000.0
                };
                timer.Elapsed += SerOpenRemind_Tick;
            }
        }

        public Task StartAsync(string clu, string Server)
        {
            
            GoServerRemind(clu, Server);
            return Task.FromResult(0);
        }
        #region 开服查询类

        

        public void GoServerQuery(string clu, string serverstr)
        {
            string serName = serverstr.Trim();
            string ip = string.Empty;
            string bigSer = string.Empty;
            for (int i = 0; i < Config.serList.GetLength(0); i++)
            {
                if (serName.Equals(Config.serList[i, 1]))
                {
                    ip = Config.serList[i, 2];
                    bigSer = Config.serList[i, 0];
                    string content = Jx3OpenTell.IsOpen(ip, 3724) ? (bigSer + " " + serName + "\r\n开") : (bigSer + " " + serName + "\r\n关");
                    _mahuaApi.SendGroupMessage(clu, CQCode.SendLink("开服查询", CQCode.GetQQHead(_mahuaApi.GetLoginQq()), content));
                    return;
                }
                else
                {
                    if (i == Config.serList.GetLength(0) - 1)
                    {
                        _mahuaApi.SendGroupMessage(clu, " 对不起，没有找到服务器 (づ╥﹏╥)づ");
                    }
                }
            }
        }

        public void GoServerRemind(string clu, string serverstr)
        {
            string serName = serverstr.Trim();
            string bigSer = string.Empty;
            for (int i = 0; i < Config.serList.GetLength(0); i++)
            {
                if (serName.Equals(Config.serList[i, 1]))
                {
                    bool existflag = false;
                    bigSer = Config.serList[i, 0];
                    Config.serList[i, 3] = "1";
                    string[] cluList = Config.serList[i, 4].Split('|');
                    foreach (var istr in cluList)
                    {
                        if (istr == clu + "") existflag = true;
                    }
                    if (!existflag)
                    {
                        Config.serList[i, 4] += "|" + clu;
                    }
                    _mahuaApi.SendGroupMessage(clu, CQCode.SendLink("开服监控", CQCode.GetQQHead(_mahuaApi.GetLoginQq()), "已为您开启 " + serName + "的监控~请关注群信息，将第一时间通知到群。"));
                    timer.Enabled = true;
                    return;
                }
                else if (i == Config.serList.GetLength(0) - 1)
                {
                    _mahuaApi.SendGroupMessage(clu, " 对不起，没有找到服务器 (づ╥﹏╥)づ \n监控开启失败");
                }
            }
        }

        private void SerOpenRemind_Tick(object sender, EventArgs e)
        {
            timer.Enabled = false;
            for (int i = 0; i < Config.serList.GetLength(0); i++)
            {
                bool flag = Config.serList[i, 3] != "1";
                if (!flag)
                {
                    string ip = Config.serList[i, 2];
                    string[] array = Config.serList[i, 4].Split(new char[]
                    {
                        '|'
                    });
                    string text = string.Empty;
                    string bigSer = Config.serList[i, 0];
                    string serName = Config.serList[i, 1];
                    if (Jx3OpenTell.IsOpen(ip, 3724))
                    {
                        text = CQCode.SendLink("开服监控", CQCode.GetQQHead(_mahuaApi.GetLoginQq()), bigSer + " " + serName + " 开服了！");
                        array.Where(p=>p!="List").ToList().ForEach(p => { _mahuaApi.SendGroupMessage(p, text); });
                        Config.serList[i, 3] = "0";
                        Config.serList[i, 4] = "List";
                    }
                }
            }
            timer.Enabled = true;
        }

        public static Timer timer;
        #endregion 开服查询类
    }
}
