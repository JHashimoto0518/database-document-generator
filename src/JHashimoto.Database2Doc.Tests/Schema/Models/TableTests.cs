using JHashimoto.Database2Doc.Schema.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JHashimoto.Database2Doc.Tests.Schema.Models {
    [TestClass]
    public class TableTests {
        [TestMethod]
        public void NewRecord() {
            var t = new Table() { Database = "master", Schema = "dbo", TableName = "customer", TableType = "TABLE BASE" };
            Assert.AreEqual("customer", t.TableName);
        }
    }
}
