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
    public class ToolClassTests
    {
        [TestMethod()]
        public void GetIniTest()
        {
            var list = Traceless.TExtension.Tools.ToolClass.GetIni(@"D:\426187673.ini");
        }
    }
}