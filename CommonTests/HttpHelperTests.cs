using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Tests
{
    [TestClass()]
    public class HttpHelperTests
    {
        [TestMethod()]
        public void GetTest()
        {
            var ss = HttpHelper.Get("https://localhost:5001/Dictionary/Get").Result;
            Assert.Fail();
        }
    }
}