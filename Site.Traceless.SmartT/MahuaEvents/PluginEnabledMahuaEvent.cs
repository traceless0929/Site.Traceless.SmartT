using Newbe.Mahua.MahuaEvents;
using Newbe.Mahua;
using System;

namespace Site.Traceless.SmartT.MahuaEvents
{
    /// <summary>
    /// 插件被启用事件
    /// </summary>
    public class PluginEnabledMahuaEvent
        : IPluginEnabledMahuaEvent
    {
        private readonly IMahuaApi _mahuaApi;

        public PluginEnabledMahuaEvent(
            IMahuaApi mahuaApi)
        {
            _mahuaApi = mahuaApi;
        }
        public DAL.DALConfig DALConfig = new DAL.DALConfig();
        public void Enabled(PluginEnabledContext context)
        {

            Config.ConfigModel = DALConfig.GetConfig();
            
            // 不要忘记在MahuaModule中注册
        }
    }
}
