using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Test
{
    [TestClass]
    public class BinaryDataModelTests : BaseBinaryDataModelTest
    {
        [TestMethod]
        public void BinaryRepositoryModelCreationTest()
        {
            SaveData();
        }

        [TestMethod]
        public void BinaryRepositoryModelLoadTest()
        {
            SaveData();
            LoadData();
            Assert.IsTrue(Repository.Customers.Any());
            Assert.IsTrue(Repository.Orders.Any());
        }
    }

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
            Assert.IsTrue(Repository.Orders.Any());
            Assert.IsTrue(Repository.Customers.Any());
        }
    }

    [TestClass]
    public class DatabaseDataModelTests : BaseDatabaseDataModelTest
    {
        [TestMethod]
        public void DatabaseRepositoryModelCreationTest()
        {
            SaveData();
        }

        [TestMethod]
        public void DatabaseRepositoryModelLoadTest()
        {
            //SaveData();
            LoadData();
            Assert.IsTrue(Repository.Orders.Any());
            Assert.IsTrue(Repository.Customers.Any());
        }
    }
}