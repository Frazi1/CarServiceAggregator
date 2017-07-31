using System.Linq;
using Data.Test.Base;
using DataAccess.Repository;
using DataAccess.Repository.RepositoryFile;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Test.Tests
{
    [TestClass]
    public class BinaryDataModelTests : BaseBinaryDataModelTest
    {
        [TestMethod]
        public void BinaryRepositoryModelCreationTest()
        {
            Repository = new BinaryRepository(new BinaryRepositorySettings(BinaryFilePath, FileRepositoryMode.Create));
            AddTestDataToRepository();
            Repository.SaveChanges();
        }

        [TestMethod]
        public void BinaryRepositoryModelLoadTest()
        {
            Repository = new BinaryRepository(new BinaryRepositorySettings(BinaryFilePath, FileRepositoryMode.Create));

            AddTestDataToRepository();
            Repository.SaveChanges();

            Repository = new BinaryRepository(new BinaryRepositorySettings(BinaryFilePath, FileRepositoryMode.Open));

            Assert.IsTrue(Repository.GetCustomers().Any());
            Assert.IsTrue(Repository.GetOrders().Any());
        }
    }
}