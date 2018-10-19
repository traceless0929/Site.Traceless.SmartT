using Newbe.Mahua;
using Newbe.Mahua.MahuaEvents;
using Site.Traceless.SmartT.DAL;
using System;

namespace Site.Traceless.SmartT.MahuaEvents
{
    /// <summary>
    /// 插件初始化事件
    /// </summary>
    public class InitializationMahuaEvent
        : IInitializationMahuaEvent
    {
        private readonly IMahuaApi _mahuaApi;

        public InitializationMahuaEvent(
            IMahuaApi mahuaApi)
        {
            _mahuaApi = mahuaApi;
        }
        public DAL.DALConfig DALConfig = new DAL.DALConfig();
        public void Initialized(InitializedContext context)
        {
            // todo 填充处理逻辑
            Config.ConfigModel = DALConfig.GetConfig();

            // 不要忘记在MahuaModule中注册
        }
    }
}
