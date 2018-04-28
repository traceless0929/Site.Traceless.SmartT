using Newbe.Mahua;
using Newbe.Mahua.MahuaEvents;
using Site.Traceless.SmartT.CorP;
using Site.Traceless.SmartT.Func;
using System;

namespace Site.Traceless.SmartT.MahuaEvents
{
    /// <summary>
    /// 来自好友的私聊消息接收事件
    /// </summary>
    public class PrivateMessageFromFriendReceivedMahuaEvent
        : IPrivateMessageFromFriendReceivedMahuaEvent
    {
        private readonly IMahuaApi _mahuaApi;

        public PrivateMessageFromFriendReceivedMahuaEvent(
            IMahuaApi mahuaApi)
        {
            _mahuaApi = mahuaApi;
            _MenuApp = new MenuApp(mahuaApi);
            _SignApp = new SignApp(mahuaApi);
            _OverApp = new OverApp(mahuaApi);
            _ManagerApp = new ManagerApp(mahuaApi);
            _PetCdApp = new PetCdApp(mahuaApi);

            _ManagerApp.SetSuccesser(_MenuApp);
            _MenuApp.SetSuccesser(_SignApp);
            _SignApp.SetSuccesser(_PetCdApp);
            _PetCdApp.SetSuccesser(_OverApp);
        }
        private MenuApp _MenuApp;
        private SignApp _SignApp;
        private OverApp _OverApp;
        private ManagerApp _ManagerApp;
        private PetCdApp _PetCdApp;

        public void ProcessFriendMessage(PrivateMessageFromFriendReceivedContext context)
        {
            try
            {
                AnalysisMsg nowModel = new AnalysisMsg(context.Message);
                _ManagerApp.ProcessRequset(context, nowModel);
            }
            catch (Exception ex)
            {
                _mahuaApi.SendPrivateMessage(Config.ConfigModel.MasterQQ).Text(ex.ToString());
            }
            // 不要忘记在MahuaModule中注册
        }
    }
}
