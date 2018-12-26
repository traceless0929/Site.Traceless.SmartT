using Microsoft.VisualStudio.TestTools.UnitTesting;
using Traceless.TExtension.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traceless.TExtension.Tools.Tests
{
    [TestClass()]
    public class BaiDuAiTests
    {
        [TestMethod()]
        public void CustomTest()
        {
            BaiDuAi baiDuAi = new BaiDuAi();
            var image = File.ReadAllBytes("图片文件路径");
            //baiDuAi.Custom()
        }
    }
}