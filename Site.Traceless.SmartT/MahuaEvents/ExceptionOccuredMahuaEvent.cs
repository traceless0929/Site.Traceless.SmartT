using Newbe.Mahua;
using Newbe.Mahua.MahuaEvents;
using System;

namespace Site.Traceless.SmartT.MahuaEvents
{
    /// <summary>
    /// 运行出现异常事件
    /// </summary>
    public class ExceptionOccuredMahuaEvent
        : IExceptionOccuredMahuaEvent
    {
        private readonly IMahuaApi _mahuaApi;

        public ExceptionOccuredMahuaEvent(
            IMahuaApi mahuaApi)
        {
            _mahuaApi = mahuaApi;
        }

        public void HandleException(ExceptionOccuredContext context)
        {
            _mahuaApi.SendPrivateMessage("415206409").Text(context.Exception.ToString());
            // 不要忘记在MahuaModule中注册
        }
    }
}
