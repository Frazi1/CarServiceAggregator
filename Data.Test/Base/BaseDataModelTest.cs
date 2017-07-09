using System;
using DataAccess.Model;
using DataAccess.Repository;
using DataGeneratorLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Test.Base
{
    public abstract class BaseDataModel
    {
        protected DataGenerator DataGenerator { get; private set; }
        protected Random Random { get; private set; }
        protected IRepository Repository { get; set; }

        [TestInitialize]
        public virtual void Initialize()
        {
            DataGenerator = new DataGenerator(true);
            Random = new Random();
            DataGenerator.GenerateCustomer(30, Random);
            DataGenerator.GenerateOrder(50, Random);
        }

        public virtual void SaveData()
        {
            foreach (Customer customer in DataGenerator.Customers)
                Repository.AddCustomer(customer);
            foreach (Order order in DataGenerator.Orders)
                Repository.AddOrder(order);
            Repository.SaveChanges();
        }

        public abstract void LoadData();
    }
}