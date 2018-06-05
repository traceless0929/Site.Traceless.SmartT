using Microsoft.VisualStudio.TestTools.UnitTesting;
using Traceless.TExtension.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traceless.TExtension.Tools.Tests
{
    [TestClass()]
    public class WeiboToolTests
    {
        [TestMethod()]
        public void GetWeiBoTopicIdTest()
        {
            //WeiboTool.GetWeiBoTopicContent("剑网3江湖百晓生", "剑网3官方微博");
            var res = WeiboTool.GetWeiBoTopicContentV1(WeiboTool.GetWeiBoTopicId("剑网3江湖百晓生"), "剑网3官方微博");
            Assert.Fail();
        }
    }
}