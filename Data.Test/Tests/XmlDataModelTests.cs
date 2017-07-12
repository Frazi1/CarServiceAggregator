using System.Linq;
using Data.Test.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Test.Tests
{
    [TestClass]
    public class XmlDataModelTests : BaseXmlDataModelTest
    {
        [TestMethod]
        public void XmlRepositoryModelCreationTest()
        {
            SaveData();
        }

        [TestMethod]
        public void XmlRepositoryModelLoadTest()
        {
            SaveData();
            LoadData();
            Assert.IsTrue(Repository.GetOrders().Any());
            Assert.IsTrue(Repository.GetCustomers().Any());
        }
    }
}