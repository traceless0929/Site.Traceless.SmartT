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
    public class CQImageToolTests
    {
        [TestMethod()]
        public void GetCqImgRawUrlTest()
        {
            CQImageTool.GetCqImgRawUrl(@"F7F96197DAEB6B9038E4AD917D318609.jpg");
            Assert.Fail();
        }

        [TestMethod()]
        public void GetCqImgCodeRawUrlTest()
        {
            CQImageTool.GetCqImgCodeRawUrl(@"[CQ:image,file=05DB4DF97D1F958648DAE05B361D02C6.jpg]");
            Assert.Fail();
        }
    }
}