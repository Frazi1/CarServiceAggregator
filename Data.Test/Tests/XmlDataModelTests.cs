using System.IO;
using System.Linq;
using Data.Test.Base;
using DataAccess.Repository.RepositoryFile;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Test.Tests
{
    [TestClass]
    public class XmlDataModelTests : BaseXmlDataModelTest
    {
        [TestMethod]
        public void XmlRepositoryModelCreationTest()
        {
            Repository = new XmlRepository(new XmlRepositorySettings(XmlFilePath, FileMode.Create));
            AddTestDataToRepository();
            Repository.SaveChanges();
        }

        [TestMethod]
        public void XmlRepositoryModelLoadTest()
        {
            Repository = new XmlRepository(new XmlRepositorySettings(XmlFilePath, FileMode.Create));

            AddTestDataToRepository();
            Repository.SaveChanges();

            Repository = new XmlRepository(new XmlRepositorySettings(XmlFilePath, FileMode.Open));

            Assert.IsTrue(Repository.GetOrders().Any());
            Assert.IsTrue(Repository.GetCustomers().Any());
        }
    }
}