using System.IO;
using System.Xml;
using DataAccess.Repository;
using DataAccess.Repository.RepositoryFile;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoServiceViewer.Test
{
    [TestClass]
    public class UnityTests
    {
        [TestMethod]
        [ExpectedException(typeof(XmlException))]
        public void ConstructorInjectionTest()
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<IRepository, XmlRepository>();
            container.RegisterType<XmlRepositorySettings>(new InjectionConstructor("test.xml", FileMode.Open));
            var repo = container.Resolve<IRepository>();
        }
    }
}