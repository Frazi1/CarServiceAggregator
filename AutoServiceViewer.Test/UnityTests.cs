using System.Collections.Generic;
using System.IO;
using System.Linq;
using DataAccess.Model;
using DataAccess.Repository;
using DataAccess.Repository.LazyRepository;
using DataAccess.Repository.RepositoryDb;
using DataAccess.Repository.RepositoryFile;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoServiceViewer.Test
{
    [TestClass]
    public class UnityTests : BaseUnityTest
    {
        [TestMethod]
        public void ConstructorInjectionTest()
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<IRepository, XmlRepository>();
            container.RegisterType<XmlRepositorySettings>(new InjectionConstructor(XmlFilePath, FileMode.Open));
            IRepository repo = container.Resolve<IRepository>();
            Assert.IsNotNull(repo);
        }

        [TestMethod]
        public void LazyXmlRepositoryCreationTest()
        {
            Container.RegisterType<IRepository, LazyRepository<XmlRepository>>();
            Container.RegisterType<RepositorySettings, XmlRepositorySettings>(new InjectionConstructor(XmlFilePath, FileMode.Open));
            IRepository repo = Container.Resolve<IRepository>();
            IEnumerable<Customer> customers = repo.Customers;
            Assert.IsTrue(customers.Any());
        }

        [TestMethod]
        public void LazyBinaryRepositoryCreationTest()
        {
            Container.RegisterType<IRepository, LazyRepository<BinaryRepository>>();
            Container.RegisterType<RepositorySettings, BinaryRepositorySettings>(new InjectionConstructor(BinaryFilePath, FileMode.Open));
            IRepository repo = Container.Resolve<IRepository>();
            IEnumerable<Customer> customers = repo.Customers;
            Assert.IsTrue(customers.Any());
        }

        [TestMethod]
        public void LazyDatabaseRepositoryCreationTest()
        {
            Container.RegisterType<IRepository, LazyRepository<DatabaseRepository>>();
            Container.RegisterType<RepositorySettings, DatabaseRepositorySettings>(new InjectionConstructor(ConnectionString));
            IRepository repo = Container.Resolve<IRepository>();
            IEnumerable<Customer> customers = repo.Customers;
            Assert.IsTrue(customers.Any());
        }
    }
}
