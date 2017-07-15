using System.IO;
using DataAccess.Repository.RepositoryFile;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Test.Base
{
    public class BaseXmlDataModelTest : BaseDataModel
    {
        protected string XmlFilePath { get; private set; }

        [TestInitialize]
        public override void Initialize()
        {
            XmlFilePath = "test.xml";
            base.Initialize();
        }

        [TestCleanup]
        public void CleanUp()
        {
            File.Delete(XmlFilePath);
        }
    }
}