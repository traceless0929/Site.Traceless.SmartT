﻿using Newbe.Mahua;
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
            _SerOpenApp = new SerOpenApp(mahuaApi, serverRemind);
            _SignApp = new SignApp(mahuaApi);
            _OverApp = new OverApp(mahuaApi);
            _PetCdApp = new PetCdApp(mahuaApi);
            

            _MenuApp.SetSuccesser(_SignApp);
            _SignApp.SetSuccesser(_SerOpenApp);
            _SerOpenApp.SetSuccesser(_PetCdApp);
            _PetCdApp.SetSuccesser(_OverApp);
            
        }
        private MenuApp _MenuApp;
        private SignApp _SignApp;
        private OverApp _OverApp;
        private PetCdApp _PetCdApp;
        private SerOpenApp _SerOpenApp;

        public bool IsDebug = false;
        public string DebugGid = "516141713";
        public void ProcessGroupMessage(GroupMessageReceivedContext context)
        {
            if (IsDebug && context.FromGroup != DebugGid) return;
            try
            {
                AnalysisMsg nowModel = new AnalysisMsg(context.Message);
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
