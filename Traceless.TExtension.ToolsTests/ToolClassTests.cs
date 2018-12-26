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
    public class ToolClassTests
    {
        [TestMethod()]
        public void GetIniTest()
        {
            var list = Traceless.TExtension.Tools.ToolClass.GetIni(@"D:\426187673.ini");
        }

        [TestMethod()]
        public void DownLoadImageTest()
        {
            string url = "http://wx4.sinaimg.cn/large/68ffaf79gy1fyjxy28gfoj20j60vd4dg.jpg";
            string filename = "test" + url.Substring(url.LastIndexOf("."));
            ToolClass.DownLoadImage(url, Path.Combine(Environment.CurrentDirectory,"dayImg", filename));
        }
    }
}