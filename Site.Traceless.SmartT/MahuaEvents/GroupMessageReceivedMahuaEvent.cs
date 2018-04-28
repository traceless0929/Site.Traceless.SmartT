using Newbe.Mahua;
using Newbe.Mahua.MahuaEvents;
using Site.Traceless.SmartT.CorP;
using Site.Traceless.SmartT.Func;
using System;

namespace Site.Traceless.SmartT.MahuaEvents
{
    /// <summary>
    /// 群消息接收事件
    /// </summary>
    public class GroupMessageReceivedMahuaEvent
        : IGroupMessageReceivedMahuaEvent
    {
        private readonly IMahuaApi _mahuaApi;

        public GroupMessageReceivedMahuaEvent(
            IMahuaApi mahuaApi)
        {
            _mahuaApi = mahuaApi;
            _MenuApp = new MenuApp(mahuaApi);
            _SignApp = new SignApp(mahuaApi);
            _OverApp = new OverApp(mahuaApi);
            _PetCdApp = new PetCdApp(mahuaApi);
            _OpenTellApp = new OpenTellApp(mahuaApi);

            _MenuApp.SetSuccesser(_SignApp);
            _SignApp.SetSuccesser(_OpenTellApp);
            _OpenTellApp.SetSuccesser(_PetCdApp);
            _PetCdApp.SetSuccesser(_OverApp);
        }
        private MenuApp _MenuApp;
        private SignApp _SignApp;
        private OverApp _OverApp;
        private PetCdApp _PetCdApp;
        private OpenTellApp _OpenTellApp;

        public void ProcessGroupMessage(GroupMessageReceivedContext context)
        {
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
