using System.IO;
using DataAccess.CarServiceAggregatorRepositories;
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
            Repository = new BinaryCustomersOrdersRepository(new BinaryRepositorySettings(BinaryFilePath, FileMode.Create));
            base.Initialize();
        }

        [TestCleanup]
        public void CleanUp()
        {
            File.Delete(BinaryFilePath);
        }

        public override void SaveData()
        {
            Repository = new BinaryCustomersOrdersRepository(new BinaryRepositorySettings(BinaryFilePath, FileMode.Create));
            base.SaveData();
        }

        public override void LoadData()
        {
            Repository = new BinaryCustomersOrdersRepository(new BinaryRepositorySettings(BinaryFilePath, FileMode.Open));
        }
    }
}