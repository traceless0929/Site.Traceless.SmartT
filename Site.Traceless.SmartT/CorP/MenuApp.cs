using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newbe.Mahua;
using Newbe.Mahua.MahuaEvents;
using Site.Traceless.SmartT.DAL;

namespace Site.Traceless.SmartT.CorP
{
    internal class MenuApp : Approver
    {
        private IMahuaApi _mahuaApi;
        public MenuApp(IMahuaApi mahuaApi)
        {
            _mahuaApi = mahuaApi;
        }

        public DALMenu DALMenu = new DALMenu();
        public override void ProcessRequset(GroupMessageReceivedContext msg)
        {
            if(msg.Message.Trim()=="菜单")
            {
                _mahuaApi.SendGroupMessage(msg.FromGroup).Text(DALMenu.GetMenuStr()).Face("150").Done();
                return;
            }
            successor.ProcessRequset(msg);
        }

        public override void ProcessRequset(PrivateMessageFromFriendReceivedContext msg)
        {
            if (msg.Message.Trim() == "菜单")
            {
                _mahuaApi.SendPrivateMessage(msg.FromQq).Text(DALMenu.GetMenuStr()).Face("150").Done();
                return;
            }
            successor.ProcessRequset(msg);
        }
    }
}
