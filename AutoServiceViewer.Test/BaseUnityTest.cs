using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoServiceViewer.Test
{
    public class BaseUnityTest
    {
        protected IUnityContainer Container { get; private set; }
        protected string XmlFilePath { get; private set; }
        protected string BinaryFilePath { get; private set; }
        protected string ConnectionString { get; private set; }


        [TestInitialize]
        public void Initialize()
        {
            Container = new UnityContainer();
            XmlFilePath = @"../../../DataForTest/AutoService.xml";
            BinaryFilePath = @"../../../DataForTest/AutoService.dat";
            ConnectionString = "server=localhost;port=3306;userid=testuser;password=testpassword;database=autoservicedb";
        }
    }
}