using Newbe.Mahua;
using Newbe.Mahua.MahuaEvents;
using Site.Traceless.SmartT.CorP;
using Site.Traceless.SmartT.Func;
using Site.Traceless.SmartT.Service;
using System;
using System.Timers;
using Traceless.TExtension.Tools;

namespace Site.Traceless.SmartT.MahuaEvents
{
    /// <summary>
    /// 群消息接收事件
    /// </summary>
    public class GroupMessageReceivedMahuaEvent
        : IGroupMessageReceivedMahuaEvent
    {
        private readonly IMahuaApi _mahuaApi;
        private readonly IServerRemind _serverRemind;

        public GroupMessageReceivedMahuaEvent(
            IMahuaApi mahuaApi, IServerRemind serverRemind)
        {
            _mahuaApi = mahuaApi;
            _serverRemind = serverRemind;
            _MenuApp = new MenuApp(mahuaApi);
            _SignApp = new SignApp(mahuaApi);
            _OverApp = new OverApp(mahuaApi);
            _PetCdApp = new PetCdApp(mahuaApi);
            

            _MenuApp.SetSuccesser(_SignApp);
            _SignApp.SetSuccesser(_PetCdApp);
            _PetCdApp.SetSuccesser(_OverApp);
            
        }
        private MenuApp _MenuApp;
        private SignApp _SignApp;
        private OverApp _OverApp;
        private PetCdApp _PetCdApp;
        

        public void ProcessGroupMessage(GroupMessageReceivedContext context)
        {
            try
            {
                AnalysisMsg nowModel = new AnalysisMsg(context.Message);
                if (Config.ConfigModel.IsFuncOpen("开服监控"))
                {
                    if (nowModel.What == "开服监控")
                    {
                        _serverRemind.StartAsync(context.FromGroup, nowModel.Who).GetAwaiter().GetResult();
                        return;
                    }
                }
                if (Config.ConfigModel.IsFuncOpen("开服查询"))
                {
                    if (nowModel.What == "开服查询")
                    {
                        _serverRemind.GoServerQuery(context.FromGroup, nowModel.Who);
                        return;
                    }
                }
                
                _MenuApp.ProcessRequset(context, nowModel);
            }
            catch(Exception ex)
            {
                _mahuaApi.SendPrivateMessage(Config.ConfigModel.MasterQQ).Text(ex.ToString());
            }
            // 不要忘记在MahuaModule中注册
        }
    }
}
