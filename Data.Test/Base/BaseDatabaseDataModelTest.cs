using DataAccess.Repository.RepositoryDb;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Test.Base
{
    public class BaseDatabaseDataModelTest : BaseDataModel
    {
        protected string ConnectionString { get; private set; }

        [TestInitialize]
        public override void Initialize()
        {
            ConnectionString =
                "server=localhost;port=3306;userid=testuser;password=testpassword;initial catalog=test_db_auto_data";
            base.Initialize();
        }
    }
}