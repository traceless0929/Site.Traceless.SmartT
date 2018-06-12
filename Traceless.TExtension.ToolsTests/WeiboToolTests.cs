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
            var res = WeiboTool.GetWeiBoTopicContentV1("剑网3江湖百晓生", "剑网3官方微博");
            //var res = WeiboTool.GetWeiBoTopicContentV3("100808caa7b601042a88d12fe2d284f3891665", "剑网3官方微博");
            //var res = WeiboTool.GetWeiBoTopicContentV2("剑网3江湖百晓生", "剑网3官方微博");
            Assert.Fail();
        }
    }
}