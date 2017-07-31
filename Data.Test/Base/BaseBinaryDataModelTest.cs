using System.IO;
using DataAccess.Repository;
using DataAccess.Repository.RepositoryFile;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Test.Base
{
    public class BaseBinaryDataModelTest : BaseDataModel
    {
        protected string BinaryFilePath { get; private set; }

        [TestInitialize]
        public override void Initialize()
        {
            BinaryFilePath = "test.dat";
            Repository = new BinaryRepository(new BinaryRepositorySettings(BinaryFilePath, FileRepositoryMode.Create));
            base.Initialize();
        }

        [TestCleanup]
        public void CleanUp()
        {
            File.Delete(BinaryFilePath);
        }
    }
}