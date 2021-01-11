using JHashimoto.Database2Doc.Schema.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace JHashimoto.Database2Doc.Tests.Schema.Models {
    [TestClass]
    public class TableListTests {
        [TestMethod]
        public void GetViewTest()　{
            const string Name = "CustomerView";
            var l = new TableList() { tableList = new List<Table>() { new Table() { TableName = Name, TableType = "VIEW" } } };
            Assert.AreEqual(Name, l.GetViews().First().TableName);
        }

        [TestMethod]
        public void GetTableTest() {
            const string Name = "Customer";
            var l = new TableList() { tableList = new List<Table>() { new Table() { TableName = Name, TableType = "BASE TABLE" } } };
            Assert.AreEqual(Name, l.GetTables().First().TableName);
        }
    }
}
