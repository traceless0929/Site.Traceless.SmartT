using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newbe.Mahua.MahuaEvents;

namespace Site.Traceless.SmartT.CorP
{
    internal abstract class Approver
    {
        /// <summary>
        /// 下级职责人
        /// </summary>
        protected Approver successor;

        /// <summary>
        /// 设置下级职责人
        /// </summary>
        /// <param name="successor"></param>
        public void SetSuccesser(Approver successor)
        {
            this.successor = successor;
        }

        /// <summary>
        /// 群消息处理
        /// </summary>
        /// <param name="msg"></param>
        public abstract void ProcessRequset(GroupMessageReceivedContext msg);

        /// <summary>
        /// 私聊消息处理
        /// </summary>
        /// <param name="msg"></param>
        public abstract void ProcessRequset(PrivateMessageFromFriendReceivedContext msg);
    }
}
