using System.Linq;
using Data.Test.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Test.Tests
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
            Assert.IsTrue(Repository.GetCustomers().Any());
            Assert.IsTrue(Repository.GetOrders().Any());
        }
    }
}