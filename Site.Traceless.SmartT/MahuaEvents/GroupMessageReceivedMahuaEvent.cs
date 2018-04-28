using Newbe.Mahua;
using Newbe.Mahua.MahuaEvents;
using Site.Traceless.SmartT.CorP;
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

            _MenuApp.SetSuccesser(_SignApp);
            _SignApp.SetSuccesser(_OverApp);
        }
        private MenuApp _MenuApp;
        private SignApp _SignApp;
        private OverApp _OverApp;

        public void ProcessGroupMessage(GroupMessageReceivedContext context)
        {
            _MenuApp.ProcessRequset(context);
            // 不要忘记在MahuaModule中注册
        }
    }
}
