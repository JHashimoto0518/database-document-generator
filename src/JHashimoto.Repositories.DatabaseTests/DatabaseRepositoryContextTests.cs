using Microsoft.VisualStudio.TestTools.UnitTesting;
using JHashimoto.Repositories.Database;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;

namespace JHashimoto.Repositories.Database.Tests {
    [TestClass()]
    public class DatabaseRepositoryContextTests {
        [TestMethod()]
        public void GetDbProviderFactoryTest() {
            var f = DatabaseRepositoryContext.GetDbProviderFactory();
            Assert.IsNotNull(f);
            Assert.AreEqual(f.GetType(), typeof(SqlClientFactory));
        }
    }
}