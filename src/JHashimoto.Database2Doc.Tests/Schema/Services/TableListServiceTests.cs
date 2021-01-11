using Microsoft.VisualStudio.TestTools.UnitTesting;
using JHashimoto.Database2Doc.Schema.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHashimoto.Database2Doc.Schema.Services.Tests {
    [TestClass()]
    public class TableListServiceTests {
        [TestMethod()]
        public void GetTableListTest() {
            var s = new TableListService();
            var tableList = s.GetTableList();
            Assert.AreEqual("master", tableList.First().Database);
        }
    }
}