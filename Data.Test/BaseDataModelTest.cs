using System;
using System.IO;
using DataAccess.Model;
using DataAccess.Repository;
using DataAccess.Repository.RepositoryDb;
using DataAccess.Repository.RepositoryFile;
using DataGeneratorLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Test
{
    public abstract class BaseDataModel
    {
        protected DataGenerator DataGenerator { get; private set; }
        protected Random Random { get; private set; }
        protected IRepository Repository { get; set; }

        [TestInitialize]
        public virtual void Initialize()
        {
            DataGenerator = new DataGenerator();
            Random = new Random();
            DataGenerator.GenerateCustomer(30, Random);
            DataGenerator.GenerateOrder(50, Random);
        }

        public virtual void SaveData()
        {
            foreach (Customer customer in DataGenerator.Customers)
            {
                Repository.AddCustomer(customer);
            }
            foreach (Order order in DataGenerator.Orders)
            {
                Repository.AddOrder(order);
            }
            Repository.SaveChanges();
        }

        public abstract void LoadData();

    }

    public class BaseXmlDataModelTest : BaseDataModel
    {
        protected string XmlFilePath { get; private set; }

        [TestInitialize]
        public override void Initialize()
        {
            XmlFilePath = "test.xml";
            base.Initialize();
        }

        public override void SaveData()
        {
            Repository = new XmlRepository(new XmlRepositorySettings(XmlFilePath, FileMode.Create));
            base.SaveData();
        }

        public override void LoadData()
        {
            Repository = new XmlRepository(new XmlRepositorySettings(XmlFilePath, FileMode.Open));
        }
    }

    public class BaseBinaryDataModelTest : BaseDataModel
    {
        protected string BinaryFilePath { get; private set; }

        [TestInitialize]
        public override void Initialize()
        {
            BinaryFilePath = "test.dat";
            Repository = new BinaryRepository(new BinaryRepositorySettings(BinaryFilePath, FileMode.Create));
            base.Initialize();
        }

        public override void SaveData()
        {
            Repository = new BinaryRepository(new BinaryRepositorySettings(BinaryFilePath, FileMode.Create));
            base.SaveData();
        }

        public override void LoadData()
        {
            Repository = new BinaryRepository(new BinaryRepositorySettings(BinaryFilePath, FileMode.Open));
        }
    }

    public class BaseDatabaseDataModelTest : BaseDataModel
    {
        protected string ConnectionString { get; private set; }

        [TestInitialize]
        public override void Initialize()
        {
            ConnectionString = "server=localhost;port=3306;userid=testuser;password=testpassword;initial catalog=test_db_auto_data";
            base.Initialize();
        }

        public override void SaveData()
        {
            Repository = new DatabaseRepository(new DatabaseRepositorySettings(ConnectionString));
            base.SaveData();
        }

        public override void LoadData()
        {
            Repository = new DatabaseRepository(new DatabaseRepositorySettings(ConnectionString));
        }
    }
}